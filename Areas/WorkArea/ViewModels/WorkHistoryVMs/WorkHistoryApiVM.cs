using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using YG.Models;


namespace YG.WorkArea.ViewModels.WorkHistoryVMs
{
    public partial class WorkHistoryApiVM : BaseCRUDVM<WorkHistory>
    {

        public WorkHistoryApiVM()
        {
            SetInclude(x => x.Work);
            SetInclude(x => x.Receiver);
        }

        protected override void InitVM()
        {
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
