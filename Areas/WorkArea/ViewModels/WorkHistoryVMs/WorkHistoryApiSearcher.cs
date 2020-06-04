using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using YG.Models;


namespace YG.WorkArea.ViewModels.WorkHistoryVMs
{
    public partial class WorkHistoryApiSearcher : BaseSearcher
    {
        public List<ComboSelectListItem> AllWorks { get; set; }
        [Display(Name = "事务")]
        public Guid? WorkId { get; set; }
        public List<ComboSelectListItem> AllReceivers { get; set; }
        [Display(Name = "接受人")]
        public Guid? ReceiverId { get; set; }
        [Display(Name = "意见")]
        public String Advice { get; set; }

        protected override void InitVM()
        {
            AllWorks = DC.Set<Work>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.Name);
            AllReceivers = DC.Set<Admin>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.CodeAndName);
        }

    }
}
