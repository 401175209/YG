using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using YG.Models;


namespace YG.OrganArea.ViewModels.OrganVMs
{
    public partial class OrganTemplateVM : BaseTemplateVM
    {
        [Display(Name = "机构编码")]
        public ExcelPropety OrganCode_Excel = ExcelPropety.CreateProperty<Organ>(x => x.OrganCode);
        [Display(Name = "机构名称")]
        public ExcelPropety OrganName_Excel = ExcelPropety.CreateProperty<Organ>(x => x.OrganName);
        [Display(Name = "上级机构")]
        public ExcelPropety Parent_Excel = ExcelPropety.CreateProperty<Organ>(x => x.ParentId);

	    protected override void InitVM()
        {
            Parent_Excel.DataType = ColumnDataType.ComboBox;
            Parent_Excel.ListItems = DC.Set<Organ>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.OrganName);
        }

    }

    public class OrganImportVM : BaseImportVM<OrganTemplateVM, Organ>
    {

    }

}
