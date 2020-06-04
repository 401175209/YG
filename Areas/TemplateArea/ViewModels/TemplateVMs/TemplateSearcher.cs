using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using YG.Models;


namespace YG.TemplateArea.ViewModels.TemplateVMs
{
    public partial class TemplateSearcher : BaseSearcher
    {
        [Display(Name = "模版名称")]
        public String Name { get; set; }

        protected override void InitVM()
        {
        }

    }
}
