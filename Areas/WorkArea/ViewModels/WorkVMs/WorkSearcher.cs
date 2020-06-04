using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using YG.Models;


namespace YG.WorkArea.ViewModels.WorkVMs
{
    public partial class WorkSearcher : BaseSearcher
    {
        [Display(Name = "事务")]
        public String Name { get; set; }
        [Display(Name = "是否撤回")]
        public Boolean? WithDraw { get; set; }
        [Display(Name = "状态")]
        public WorkStatusEnum? WorkStatus { get; set; }

        protected override void InitVM()
        {
        }

    }
}
