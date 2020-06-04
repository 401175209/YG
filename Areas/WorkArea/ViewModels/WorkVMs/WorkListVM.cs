using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using YG.Models;


namespace YG.WorkArea.ViewModels.WorkVMs
{
    public partial class WorkListVM : BasePagedListVM<Work_View, WorkSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Work", GridActionStandardTypesEnum.Create, Localizer["Create"],"WorkArea", dialogWidth: 1000),
                this.MakeStandardAction("Work", GridActionStandardTypesEnum.Edit, Localizer["Edit"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("Work", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "WorkArea",dialogWidth: 800),
                this.MakeStandardAction("Work", GridActionStandardTypesEnum.Details, Localizer["Details"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("Work", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("Work", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("Work", GridActionStandardTypesEnum.Import, Localizer["Import"],"WorkArea", dialogWidth: 800),
                this.MakeStandardAction("Work", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"],"WorkArea"),
            };
        }

        protected override IEnumerable<IGridColumn<Work_View>> InitGridHeader()
        {
            return new List<GridColumn<Work_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.WithDraw),
                this.MakeGridHeader(x => x.CodeAndName_view),
                this.MakeGridHeader(x => x.CodeAndName_view2),
                this.MakeGridHeader(x => x.WorkStatus),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Work_View> GetSearchQuery()
        {
            var query = DC.Set<Work>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckEqual(Searcher.WithDraw, x=>x.WithDraw)
                .CheckEqual(Searcher.WorkStatus, x=>x.WorkStatus)
                .Select(x => new Work_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    WithDraw = x.WithDraw,
                    CodeAndName_view = x.Starter.CodeAndName,
                    CodeAndName_view2 = x.Receiver.CodeAndName,
                    WorkStatus = x.WorkStatus,
                    Name_view = x.Template.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Work_View : Work{
        [Display(Name = "申请人")]
        public String CodeAndName_view { get; set; }
        [Display(Name = "审批人")]
        public String CodeAndName_view2 { get; set; }
        [Display(Name = "模版名称")]
        public String Name_view { get; set; }

    }
}
