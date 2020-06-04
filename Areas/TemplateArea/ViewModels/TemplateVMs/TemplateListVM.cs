using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using YG.Models;


namespace YG.TemplateArea.ViewModels.TemplateVMs
{
    public partial class TemplateListVM : BasePagedListVM<Template_View, TemplateSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("Template", GridActionStandardTypesEnum.Create, Localizer["Create"],"TemplateArea", dialogWidth: 800),
                this.MakeStandardAction("Template", GridActionStandardTypesEnum.Edit, Localizer["Edit"],"TemplateArea", dialogWidth: 800),
                this.MakeStandardAction("Template", GridActionStandardTypesEnum.Delete, Localizer["Delete"], "TemplateArea",dialogWidth: 600),
                this.MakeStandardAction("Template", GridActionStandardTypesEnum.BatchEdit, Localizer["BatchEdit"],"TemplateArea", dialogWidth: 800),
                this.MakeStandardAction("Template", GridActionStandardTypesEnum.BatchDelete, Localizer["BatchDelete"],"TemplateArea", dialogWidth: 800),
                this.MakeStandardAction("Template", GridActionStandardTypesEnum.Import, Localizer["Import"],"TemplateArea", dialogWidth: 800),
                this.MakeStandardAction("Template", GridActionStandardTypesEnum.ExportExcel, Localizer["Export"],"TemplateArea"),
            };
        }

        protected override IEnumerable<IGridColumn<Template_View>> InitGridHeader()
        {
            return new List<GridColumn<Template_View>>{
                this.MakeGridHeader(x => x.Description),
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<Template_View> GetSearchQuery()
        {
            var query = DC.Set<Template>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .Select(x => new Template_View
                {
				    ID = x.ID,
                    Description = x.Description,
                    Name = x.Name,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class Template_View : Template{

    }
}
