using System;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WalkingTec.Mvvm.Mvc;
using YG.ViewModels.HomeVMs;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using YG.Models;

namespace YG.Controllers
{
    public class LoginController : BaseController
    {
        [Public]
        [ActionDescription("Login")]
        public IActionResult Login()
        {
            LoginVM vm = CreateVM<LoginVM>();
            vm.Redirect = HttpContext.Request.Query["Redirect"];
            if (ConfigInfo.IsQuickDebug == true)
            {
                vm.ITCode = "admin";
                vm.Password = "000000";
            }
            return View(vm);
        }
        [Public]
        [ActionDescription("检查Mac")]
        public bool CheckBindMAC(string mac)
        {
            var user = DC.Set<Admin>()
            .Where(x => x.ITCode.ToLower() == LoginUserInfo.ITCode && x.IsValid)
            .SingleOrDefault();

            if (user.MAC == null || user.MAC == "")
            {
                return true;
            }
            else
            {
                if (user.MAC.Contains(mac))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }

        [Public]
        [HttpPost]
        public async Task<ActionResult> Login(LoginVM vm)
        {
            //if (ConfigInfo.IsQuickDebug == false)
            //{
            //    var verifyCode = HttpContext.Session.Get<string>("verify_code");
            //    if (string.IsNullOrEmpty(verifyCode) || verifyCode.ToLower() != vm.VerifyCode.ToLower())
            //    {
            //        vm.MSD.AddModelError("", "验证码不正确");
            //        return View(vm);
            //    }
            //}

            var user = vm.DoLogin();

            if (user == null)
            {
                return View(vm);
            }
            else
            {
                LoginUserInfo = user;

                string url = string.Empty;
                if (!string.IsNullOrEmpty(vm.Redirect))
                {
                    url = vm.Redirect;
                }
                else
                {
                    url = "/";
                }

                AuthenticationProperties properties = null;
                // if (vm.RememberLogin)
                //{
                properties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(30))
                };
                //}
                var claims = new[] { new Claim("OrganCode", user.Memo) };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);




                var principal = user.CreatePrincipal();
                principal.AddIdentity(claimsIdentity);
                // 在上面注册AddAuthentication时，指定了默认的Scheme，在这里便可以不再指定Scheme。
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);

                return Redirect(HttpUtility.UrlDecode(url));
            }
        }

        [Public]
        [HttpGet]
        public async Task<ActionResult> LoginToken(string username, string token)
        {
            if (token != "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiI1NDM5ZTZjZi1mOTg4LTRhMDEtYWZmZS1jNGQxMzBiNjQ3ZjEiLCJuYW1lIjoi55uR566h5oC76ZifIiwiZXhwIjoxNTc0Nzg4MzA0LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdCJ9.CHjdXipgpAPSTtNKC9PeLGihONnnIe27W7yKmJvvlIA") return Redirect(HttpUtility.UrlDecode("/Login/Login"));

            //根据用户名和密码查询用户
            var user = DC.Set<Admin>()
             .Include(x => x.UserRoles).Include(x => x.UserGroups)
             .Where(x => x.ITCode.ToLower() == username.ToLower() && x.IsValid)
             .SingleOrDefault();

            //如果没有找到则输出错误
            if (user == null)
            {

                return Redirect(HttpUtility.UrlDecode("/Login/Login"));
            }

            var organ = DC.Set<Organ>().SingleOrDefault(x => x.ID == user.OrganId);


            var roleIDs = user.UserRoles.Select(x => x.RoleId).ToList();
            var groupIDs = user.UserGroups.Select(x => x.GroupId).ToList();
            //查找登录用户的数据权限
            var dpris = DC.Set<DataPrivilege>()
                .Where(x => x.UserId == user.ID || (x.GroupId != null && groupIDs.Contains(x.GroupId.Value)))
                .Distinct()
                .ToList();

            //生成并返回登录用户信息
            LoginUserInfo rv = new LoginUserInfo
            {
                Id = user.ID,
                ITCode = user.ITCode,
                Name = user.Name,
                Memo = organ.OrganCode,
                PhotoId = user.PhotoId,
                Roles = DC.Set<FrameworkRole>().Where(x => user.UserRoles.Select(y => y.RoleId).Contains(x.ID)).ToList(),
                Groups = DC.Set<FrameworkGroup>().Where(x => user.UserGroups.Select(y => y.GroupId).Contains(x.ID)).ToList(),
                DataPrivileges = dpris
            };

            //查找登录用户的页面权限
            var pris = DC.Set<FunctionPrivilege>()
                .Where(x => x.UserId == user.ID || (x.RoleId != null && roleIDs.Contains(x.RoleId.Value)))
                .Distinct()
                .ToList();
            rv.FunctionPrivileges = pris;




            LoginUserInfo = rv;


            AuthenticationProperties properties = null;
            // if (vm.RememberLogin)
            //{
            properties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(30))
            };
            //}
            var claims = new[] { new Claim("OrganCode", rv.Memo) };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);




            var principal = rv.CreatePrincipal();
            principal.AddIdentity(claimsIdentity);
            // 在上面注册AddAuthentication时，指定了默认的Scheme，在这里便可以不再指定Scheme。
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, properties);

            return Redirect(HttpUtility.UrlDecode("/Home/Index?HideHeader=true"));

        }


        [AllRights]
        [ActionDescription("Logout")]
        public async Task Logout()
        {
            
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Redirect("/");
        }

        [AllRights]
        [ActionDescription("ChangePassword")]
        public ActionResult ChangePassword()
        {
            var vm = CreateVM<ChangePasswordVM>();
            vm.ITCode = LoginUserInfo.ITCode;
            return PartialView(vm);
        }

        [AllRights]
        [HttpPost]
        [ActionDescription("ChangePassword")]
        public ActionResult ChangePassword(ChangePasswordVM vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                vm.DoChange();
                return FFResult().CloseDialog().Alert(Localizer["ChangePasswordSuccess"]);
            }
        }

    }
}
