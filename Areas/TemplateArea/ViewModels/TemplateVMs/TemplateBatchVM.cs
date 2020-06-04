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
    public partial class TemplateBatchVM : BaseBatchVM<Template, Template_BatchEdit>
    {
        public TemplateBatchVM()
        {
            ListVM = new TemplateListVM();
            LinkedVM = new Template_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Template_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
