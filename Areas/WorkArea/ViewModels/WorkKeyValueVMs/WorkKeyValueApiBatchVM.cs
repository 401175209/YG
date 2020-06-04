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
    public partial class WorkKeyValueApiBatchVM : BaseBatchVM<WorkKeyValue, WorkKeyValueApi_BatchEdit>
    {
        public WorkKeyValueApiBatchVM()
        {
            ListVM = new WorkKeyValueApiListVM();
            LinkedVM = new WorkKeyValueApi_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class WorkKeyValueApi_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
