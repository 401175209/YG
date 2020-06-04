using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using YG.Models;


namespace YG.AdminArea.ViewModels.AdminVMs
{
    public partial class AdminListVM : BasePagedListVM<Admin_View, AdminSearcher>
    {
        public List<TreeSelectListItem> AllOrgan { get; set; }
        protected override void InitVM()
        {
            AllOrgan = DC.Set<Organ>().GetTreeSelectListItems(LoginUserInfo.DataPrivileges, null, x => x.OrganName);
        }
        protected override List<GridAction> InitGridAction()
        {
            var GA = new List<GridAction> {
                
                this.MakeStandardAction("Admin", GridActionStandardTypesEnum.Create, Localizer["Create"],"AdminArea", dialogWidth: 800),

                this.MakeStandardAction("Admin", GridActionStandardTypesEnum.Edit, Localizer["Edit"],"AdminArea", dialogWidth: 800),
                this.MakeStandardAction("Admin", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "AdminArea",dialogWidth: 800),

                this.MakeStandardAction("Admin", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"],"AdminArea", dialogWidth: 800),
                this.MakeAction("Admin","Reset","密码重置","密码重置",GridActionParameterTypesEnum.SingleIdWithNull,"AdminArea",400).SetShowInRow().SetHideOnToolBar(),

                this.MakeStandardAction("Admin", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"],"AdminArea", dialogWidth: 800),
                this.MakeStandardAction("Admin", GridActionStandardTypesEnum.Import, Localizer["Import"],"AdminArea", dialogWidth: 800),
                this.MakeStandardAction("Admin", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"],"AdminArea"),
            };
           
           if ( LoginUserInfo.Groups.Select(y => y.GroupName).ToSpratedString(null, ",").Contains("印章"))
            {
                GA.Add(


                this.MakeAction("Admin", "Seal", "印章", "印章", GridActionParameterTypesEnum.SingleId, "AdminArea", dialogWidth: 400).SetShowInRow().SetHideOnToolBar()
                    );


            }
            return GA;
        }

        protected override IEnumerable<IGridColumn<Admin_View>> InitGridHeader()
        {
            
            return new List<GridColumn<Admin_View>>{
                this.MakeGridHeader(x => x.OrganName_view),
                this.MakeGridHeader(x => x.ITCode),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Sex),
                this.MakeGridHeader(x => x.CellPhone),
                this.MakeGridHeader(x => x.PhotoId).SetFormat(PhotoIdFormat).SetHeader("签名"),
               
                this.MakeGridHeader(x => x.RoleName_view),
                this.MakeGridHeader(x => x.GroupName_view),
                 this.MakeGridHeader(x => x.MAC),
                 this.MakeGridHeader(x => x.IsValid),
               
                this.MakeGridHeaderAction(width: 250)
            };
        }
        private List<ColumnFormatInfo> PhotoIdFormat(Admin_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
               
                //ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.PhotoId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.PhotoId,640,480)
               
                
                
            };
        }


        public override IOrderedQueryable<Admin_View> GetSearchQuery()
        {
            var query = DC.Set<Admin>()
               
                .CheckContain(Searcher.ITCode, x=>x.ITCode)
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckEqual(Searcher.IsValid, x=>x.IsValid)
                .CheckWhere(Searcher.OrganId,x=>x.OrganId==Searcher.OrganId)///三级查询
                .CheckWhere(Searcher.SelectedUserRolesIDs,x=>DC.Set<FrameworkUserRole>().Where(y=>Searcher.SelectedUserRolesIDs.Contains(y.RoleId)).Select(z=>z.UserId).Contains(x.ID))
                .CheckWhere(Searcher.SelectedUserGroupsIDs,x=>DC.Set<FrameworkUserGroup>().Where(y=>Searcher.SelectedUserGroupsIDs.Contains(y.GroupId)).Select(z=>z.UserId).Contains(x.ID))
                .Select(x => new Admin_View
                {
				    ID = x.ID,
                    OrganName_view = x.Organ.OrganName,
                    MAC = x.MAC,
                    ITCode = x.ITCode,
                    Name = x.Name,
                    Sex = x.Sex,
                    CellPhone = x.CellPhone,
                    PhotoId = x.PhotoId,
                  
                    IsValid = x.IsValid,
                    RoleName_view = x.UserRoles.Select(y=>y.Role.RoleName).ToSpratedString(null,","), 
                    GroupName_view = x.UserGroups.Select(y=>y.Group.GroupName).ToSpratedString(null,","), 
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Admin_View : Admin{
        [Display(Name = "机构名称")]
        public String OrganName_view { get; set; }
        [Display(Name = "角色")]
        public String RoleName_view { get; set; }
        [Display(Name = "用户组")]
        public String GroupName_view { get; set; }

    }
}
