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
    public partial class AdminBatchVM : BaseBatchVM<Admin, Admin_BatchEdit>
    {
        public AdminBatchVM()
        {
            ListVM = new AdminListVM();
            LinkedVM = new Admin_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Admin_BatchEdit : BaseVM
    {
        public List<ComboSelectListItem> AllOrgans { get; set; }
        [Display(Name = "所属机构")]
        public Guid? OrganId { get; set; }
        [Display(Name = "IsValid")]
        public Boolean? IsValid { get; set; }
        public List<ComboSelectListItem> AllUserRoless { get; set; }
        [Display(Name = "Role")]
        public List<Guid> SelectedUserRolesIDs { get; set; }
        public List<ComboSelectListItem> AllUserGroupss { get; set; }
        [Display(Name = "Group")]
        public List<Guid> SelectedUserGroupsIDs { get; set; }

        protected override void InitVM()
        {
            AllOrgans = DC.Set<Organ>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.OrganName);
            AllUserRoless = DC.Set<FrameworkRole>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.RoleName);
            AllUserGroupss = DC.Set<FrameworkGroup>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.GroupName);
        }

    }

}
