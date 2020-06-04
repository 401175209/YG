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
    public partial class WorkTemplateVM : BaseTemplateVM
    {

	    protected override void InitVM()
        {
        }

    }

    public class WorkImportVM : BaseImportVM<WorkTemplateVM, Work>
    {

    }

}
