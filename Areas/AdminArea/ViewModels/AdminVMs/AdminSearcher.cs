using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using YG.Models;


namespace YG.AdminArea.ViewModels.AdminVMs
{
    public partial class AdminSearcher : BaseSearcher
    {
       
        [Display(Name = "所属机构")]
        public Guid? OrganId { get; set; }
        [Display(Name = "账号")]
        public String ITCode { get; set; }
        [Display(Name = "姓名")]
        public String Name { get; set; }
        [Display(Name = "是否有效")]
        public Boolean? IsValid { get; set; }
        public List<ComboSelectListItem> AllUserRoless { get; set; }
        [Display(Name = "角色")]
        public List<Guid> SelectedUserRolesIDs { get; set; }
        public List<ComboSelectListItem> AllUserGroupss { get; set; }
        [Display(Name = "用户组")]
        public List<Guid> SelectedUserGroupsIDs { get; set; }
       
        protected override void InitVM()
        {
            AllUserRoless = DC.Set<FrameworkRole>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.RoleName);
            AllUserGroupss = DC.Set<FrameworkGroup>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.GroupName);
        }

    }
}
