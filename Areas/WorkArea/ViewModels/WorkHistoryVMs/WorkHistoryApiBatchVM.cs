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
    public partial class WorkHistoryApiBatchVM : BaseBatchVM<WorkHistory, WorkHistoryApi_BatchEdit>
    {
        public WorkHistoryApiBatchVM()
        {
            ListVM = new WorkHistoryApiListVM();
            LinkedVM = new WorkHistoryApi_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class WorkHistoryApi_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
