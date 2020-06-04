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
    public partial class TemplateTemplateVM : BaseTemplateVM
    {
        [Display(Name = "模版编号")]
        public ExcelPropety Description_Excel = ExcelPropety.CreateProperty<Template>(x => x.Description);
        [Display(Name = "模版名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Template>(x => x.Name);
        [Display(Name = "内容")]
        public ExcelPropety Context_Excel = ExcelPropety.CreateProperty<Template>(x => x.Context);

	    protected override void InitVM()
        {
        }

    }

    public class TemplateImportVM : BaseImportVM<TemplateTemplateVM, Template>
    {

    }

}
