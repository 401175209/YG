using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using YG.Models;


namespace YG.WorkArea.ViewModels.WorkKeyValueVMs
{
    public partial class WorkKeyValueApiSearcher : BaseSearcher
    {
        public List<ComboSelectListItem> AllWorks { get; set; }
        [Display(Name = "事务")]
        public Guid? WorkId { get; set; }
        public String Key { get; set; }
        public String Value { get; set; }

        protected override void InitVM()
        {
            AllWorks = DC.Set<Work>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.Name);
        }

    }
}
