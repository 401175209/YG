using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using YG.Models;


namespace YG.WorkArea.ViewModels.WorkVMs
{
    public partial class WorkVM : BaseCRUDVM<Work>
    {
        public List<ComboSelectListItem> AllStarters { get; set; }
        public List<ComboSelectListItem> AllReceivers { get; set; }
        public List<ComboSelectListItem> AllTemplates { get; set; }

        public WorkVM()
        {
            SetInclude(x => x.Starter);
            SetInclude(x => x.Receiver);
            SetInclude(x => x.Template);
        }

        protected override void InitVM()
        {
            AllStarters = DC.Set<Admin>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.CodeAndName);
            AllReceivers = DC.Set<Admin>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.CodeAndName);
            AllTemplates = DC.Set<Template>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.Name);
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
