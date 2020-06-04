using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using YG.Models;


namespace YG.WorkArea.ViewModels.WorkHistoryVMs
{
    public partial class WorkHistoryApiListVM : BasePagedListVM<WorkHistoryApi_View, WorkHistoryApiSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("WorkHistory", GridActionStandardTypesEnum.Create, Localizer["Create"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("WorkHistory", GridActionStandardTypesEnum.Edit, Localizer["Edit"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("WorkHistory", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "WorkArea",dialogWidth: 800),
                this.MakeStandardAction("WorkHistory", GridActionStandardTypesEnum.Details, Localizer["Details"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("WorkHistory", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("WorkHistory", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("WorkHistory", GridActionStandardTypesEnum.Import, Localizer["Import"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("WorkHistory", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"],"WorkArea"),
            };
        }

        protected override IEnumerable<IGridColumn<WorkHistoryApi_View>> InitGridHeader()
        {
            return new List<GridColumn<WorkHistoryApi_View>>{
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.CodeAndName_view),
                this.MakeGridHeader(x => x.Advice),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<WorkHistoryApi_View> GetSearchQuery()
        {
            var query = DC.Set<WorkHistory>()
                .CheckEqual(Searcher.WorkId, x=>x.WorkId)
                .CheckEqual(Searcher.ReceiverId, x=>x.ReceiverId)
                .CheckContain(Searcher.Advice, x=>x.Advice)
                .Select(x => new WorkHistoryApi_View
                {
				    ID = x.ID,
                    Name_view = x.Work.Name,
                    CodeAndName_view = x.Receiver.CodeAndName,
                    Advice = x.Advice,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class WorkHistoryApi_View : WorkHistory{
        [Display(Name = "事务")]
        public String Name_view { get; set; }
        [Display(Name = "User")]
        public String CodeAndName_view { get; set; }

    }
}
