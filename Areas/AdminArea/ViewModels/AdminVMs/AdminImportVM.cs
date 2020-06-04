using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using YG.Models;


namespace YG.AdminArea.ViewModels.AdminVMs
{
    public partial class AdminTemplateVM : BaseTemplateVM
    {
        [Display(Name = "所属机构")]
        public ExcelPropety Organ_Excel = ExcelPropety.CreateProperty<Admin>(x => x.OrganId);
        [Display(Name = "MAC地址")]
        public ExcelPropety MAC_Excel = ExcelPropety.CreateProperty<Admin>(x => x.MAC);
        [Display(Name = "Account")]
        public ExcelPropety ITCode_Excel = ExcelPropety.CreateProperty<Admin>(x => x.ITCode);
        [Display(Name = "Password")]
        public ExcelPropety Password_Excel = ExcelPropety.CreateProperty<Admin>(x => x.Password);
        [Display(Name = "Name")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<Admin>(x => x.Name);
        [Display(Name = "Sex")]
        public ExcelPropety Sex_Excel = ExcelPropety.CreateProperty<Admin>(x => x.Sex);
        [Display(Name = "CellPhone")]
        public ExcelPropety CellPhone_Excel = ExcelPropety.CreateProperty<Admin>(x => x.CellPhone);
        [Display(Name = "IsValid")]
        public ExcelPropety IsValid_Excel = ExcelPropety.CreateProperty<Admin>(x => x.IsValid);

	    protected override void InitVM()
        {
            Organ_Excel.DataType = ColumnDataType.ComboBox;
            Organ_Excel.ListItems = DC.Set<Organ>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.OrganName);
        }

    }

    public class AdminImportVM : BaseImportVM<AdminTemplateVM, Admin>
    {

    }

}
