using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using YG.Models;


namespace YG.WorkArea.ViewModels.WorkKeyValueVMs
{
    public partial class WorkKeyValueApiListVM : BasePagedListVM<WorkKeyValueApi_View, WorkKeyValueApiSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("WorkKeyValue", GridActionStandardTypesEnum.Create, Localizer["Create"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("WorkKeyValue", GridActionStandardTypesEnum.Edit, Localizer["Edit"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("WorkKeyValue", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "WorkArea",dialogWidth: 800),
                this.MakeStandardAction("WorkKeyValue", GridActionStandardTypesEnum.Details, Localizer["Details"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("WorkKeyValue", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("WorkKeyValue", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("WorkKeyValue", GridActionStandardTypesEnum.Import, Localizer["Import"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("WorkKeyValue", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"],"WorkArea"),
            };
        }

        protected override IEnumerable<IGridColumn<WorkKeyValueApi_View>> InitGridHeader()
        {
            return new List<GridColumn<WorkKeyValueApi_View>>{
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.Key),
                this.MakeGridHeader(x => x.Value),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<WorkKeyValueApi_View> GetSearchQuery()
        {
            var query = DC.Set<WorkKeyValue>()
                .CheckEqual(Searcher.WorkId, x=>x.WorkId)
                .CheckContain(Searcher.Key, x=>x.Key)
                .CheckContain(Searcher.Value, x=>x.Value)
                .Select(x => new WorkKeyValueApi_View
                {
				    ID = x.ID,
                    Name_view = x.Work.Name,
                    Key = x.Key,
                    Value = x.Value,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class WorkKeyValueApi_View : WorkKeyValue{
        [Display(Name = "事务")]
        public String Name_view { get; set; }

    }
}
