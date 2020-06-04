using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using YG.Models;


namespace YG.OrganArea.ViewModels.OrganVMs
{
    public partial class OrganVM : BaseCRUDVM<Organ>
    {
        public List<ComboSelectListItem> AllParents { get; set; }

        public OrganVM()
        {
            SetInclude(x => x.Parent);
        }

        protected override void InitVM()
        {
            AllParents = DC.Set<Organ>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.OrganName);
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
