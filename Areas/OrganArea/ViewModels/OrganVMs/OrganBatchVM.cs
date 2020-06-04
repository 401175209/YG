using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using YG.Models;


namespace YG.OrganArea.ViewModels.OrganVMs
{
    public partial class OrganBatchVM : BaseBatchVM<Organ, Organ_BatchEdit>
    {
        public OrganBatchVM()
        {
            ListVM = new OrganListVM();
            LinkedVM = new Organ_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Organ_BatchEdit : BaseVM
    {
        public List<ComboSelectListItem> AllParents { get; set; }
        [Display(Name = "上级机构")]
        public Guid? ParentId { get; set; }

        protected override void InitVM()
        {
            AllParents = DC.Set<Organ>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.OrganName);
        }

    }

}
