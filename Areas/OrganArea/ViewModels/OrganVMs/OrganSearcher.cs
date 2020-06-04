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
    public partial class OrganSearcher : BaseSearcher
    {
        [Display(Name = "机构编码")]
        public String OrganCode { get; set; }
        [Display(Name = "机构名称")]
        public String OrganName { get; set; }
        public List<ComboSelectListItem> AllParents { get; set; }
        [Display(Name = "上级机构")]
        public Guid? ParentId { get; set; }

        protected override void InitVM()
        {
            AllParents = DC.Set<Organ>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.OrganName);
        }

    }
}
