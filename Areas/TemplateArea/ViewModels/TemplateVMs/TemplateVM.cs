using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using YG.Models;


namespace YG.TemplateArea.ViewModels.TemplateVMs
{
    public partial class TemplateVM : BaseCRUDVM<Template>
    {

        public TemplateVM()
        {

        }

        protected override void InitVM()
        {

        }

        public override void DoAdd()
        {

           //Entity.Context = "< div style = 'width:100%;height:100%;' > " + Entity.Context + " </ div >";
            
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
