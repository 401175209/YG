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
    public partial class WorkKeyValueApiTemplateVM : BaseTemplateVM
    {

	    protected override void InitVM()
        {
        }

    }

    public class WorkKeyValueApiImportVM : BaseImportVM<WorkKeyValueApiTemplateVM, WorkKeyValue>
    {

    }

}
