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
    public partial class WorkBatchVM : BaseBatchVM<Work, Work_BatchEdit>
    {
        public WorkBatchVM()
        {
            ListVM = new WorkListVM();
            LinkedVM = new Work_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Work_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
