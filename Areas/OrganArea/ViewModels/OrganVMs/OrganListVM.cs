using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using YG.Models;


namespace YG.OrganArea.ViewModels.OrganVMs
{
    public partial class OrganListVM : BasePagedListVM<Organ_View, OrganSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Organ", GridActionStandardTypesEnum.Create, Localizer["Create"],"OrganArea", dialogWidth: 800),
                this.MakeStandardAction("Organ", GridActionStandardTypesEnum.Edit, Localizer["Edit"],"OrganArea", dialogWidth: 800),
                this.MakeStandardAction("Organ", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "OrganArea",dialogWidth: 800),
                this.MakeStandardAction("Organ", GridActionStandardTypesEnum.Details, Localizer["Details"],"OrganArea", dialogWidth: 800),
                this.MakeStandardAction("Organ", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"],"OrganArea", dialogWidth: 800),
                this.MakeStandardAction("Organ", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"],"OrganArea", dialogWidth: 800),
                this.MakeStandardAction("Organ", GridActionStandardTypesEnum.Import, Localizer["Import"],"OrganArea", dialogWidth: 800),
                this.MakeStandardAction("Organ", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"],"OrganArea"),
            };
        }

        protected override IEnumerable<IGridColumn<Organ_View>> InitGridHeader()
        {
            return new List<GridColumn<Organ_View>>{
                this.MakeGridHeader(x => x.OrganCode),
                this.MakeGridHeader(x => x.OrganName),
                this.MakeGridHeader(x => x.OrganName_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Organ_View> GetSearchQuery()
        {
            var query = DC.Set<Organ>()
                .CheckContain(Searcher.OrganCode, x=>x.OrganCode)
                .CheckContain(Searcher.OrganName, x=>x.OrganName)
                .CheckEqual(Searcher.ParentId, x=>x.ParentId)
                .Select(x => new Organ_View
                {
				    ID = x.ID,
                    OrganCode = x.OrganCode,
                    OrganName = x.OrganName,
                    OrganName_view = x.Parent.OrganName,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Organ_View : Organ{
        [Display(Name = "机构名称")]
        public String OrganName_view { get; set; }

    }
}
