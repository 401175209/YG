using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core.Extensions;
using YG.TemplateArea.ViewModels.TemplateVMs;
using WalkingTec.Mvvm.Mvc.Binders;
using System.Collections.Generic;
using ce.office.extension;
using Spire.Doc;
using Spire.Doc.Documents;
using Spire.Doc.Fields;
namespace YG.Controllers
{
    
    [Area("TemplateArea")]
    [ActionDescription("模版管理")]
    public partial class TemplateController : BaseController
    {
        [ActionDescription("GetContext")]
        public List<string> GetContext(string id)
        {
           // WordHelper.ToHtml();
            var vm = CreateVM<TemplateVM>(id);
            var context= vm.Entity.Context;
           var list= context.Split("@{{");
            List<string> kvs = new List<string>();
           foreach(var kv in list)
            {
                if(kv.Contains("}}@"))
                {
                   var res= kv.Split("}}@");
                    kvs.Add(res[0]);
                }

            }
            return kvs;
        }
        #region Search
        [ActionDescription("Search")]
        public ActionResult Index()
        {
            var vm = CreateVM<TemplateListVM>();
            return PartialView(vm);
        }

        [ActionDescription("Search")]
        [HttpPost]
        public string Search(TemplateListVM vm)
        {
            return vm.GetJson(false);
        }

        #endregion

        #region Create
        [ActionDescription("Create")]
        public ActionResult Create()
        {
            var vm = CreateVM<TemplateVM>();
            Document document = new Document();
            document.LoadFromFile("wwwroot/templates/请假条.docx");
            document.SaveToFile("wwwroot/templates/Wordto.html", FileFormat.Html);
            vm.Entity.Context = "wwwroot/templates/Wordto.html";
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("Create")]
        [StringNeedLTGT]
        public ActionResult Create(TemplateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                vm.DoAdd();
                if (!ModelState.IsValid)
                {
                    vm.DoReInit();
                    return PartialView(vm);
                }
                else
                {
                    return FFResult().CloseDialog().RefreshGrid();
                }
            }
        }
        #endregion

        #region Edit
        [ActionDescription("Edit")]
        public ActionResult Edit(string id)
        {
            var vm = CreateVM<TemplateVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("Edit")]
        [HttpPost]
        [ValidateFormItemOnly]
        [StringNeedLTGT]
        public ActionResult Edit(TemplateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                vm.DoEdit();
                if (!ModelState.IsValid)
                {
                    vm.DoReInit();
                    return PartialView(vm);
                }
                else
                {
                    return FFResult().CloseDialog().RefreshGridRow(vm.Entity.ID);
                }
            }
        }
        #endregion

        #region Delete
        [ActionDescription("Delete")]
        public ActionResult Delete(string id)
        {
            var vm = CreateVM<TemplateVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("Delete")]
        [HttpPost]
        public ActionResult Delete(string id, IFormCollection nouse)
        {
            var vm = CreateVM<TemplateVM>(id);
            vm.DoDelete();
            if (!ModelState.IsValid)
            {
                return PartialView(vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid();
            }
        }
        #endregion

        #region Details
        [ActionDescription("Details")]
        public ActionResult Details(string id)
        {
            var vm = CreateVM<TemplateVM>(id);
            return PartialView(vm);
        }
       
        #endregion

        #region BatchEdit
        [HttpPost]
        [ActionDescription("BatchEdit")]
        public ActionResult BatchEdit(string[] IDs)
        {
            var vm = CreateVM<TemplateBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("BatchEdit")]
        public ActionResult DoBatchEdit(TemplateBatchVM vm, IFormCollection nouse)
        {
            if (!ModelState.IsValid || !vm.DoBatchEdit())
            {
                return PartialView("BatchEdit",vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert("操作成功，共有"+vm.Ids.Length+"条数据被修改");
            }
        }
        #endregion

        #region BatchDelete
        [HttpPost]
        [ActionDescription("BatchDelete")]
        public ActionResult BatchDelete(string[] IDs)
        {
            var vm = CreateVM<TemplateBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("BatchDelete")]
        public ActionResult DoBatchDelete(TemplateBatchVM vm, IFormCollection nouse)
        {
            if (!ModelState.IsValid || !vm.DoBatchDelete())
            {
                return PartialView("BatchDelete",vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert("操作成功，共有"+vm.Ids.Length+"条数据被删除");
            }
        }
        #endregion

        #region Import
		[ActionDescription("Import")]
        public ActionResult Import()
        {
            var vm = CreateVM<TemplateImportVM>();
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("Import")]
        public ActionResult Import(TemplateImportVM vm, IFormCollection nouse)
        {
            if (vm.ErrorListVM.EntityList.Count > 0 || !vm.BatchSaveData())
            {
                return PartialView(vm);
            }
            else
            {
                return FFResult().CloseDialog().RefreshGrid().Alert("成功导入 " + vm.EntityList.Count.ToString() + " 行数据");
            }
        }
        #endregion

        [ActionDescription("Export")]
        [HttpPost]
        public IActionResult ExportExcel(TemplateListVM vm)
        {
            vm.SearcherMode = vm.Ids != null && vm.Ids.Count > 0 ? ListVMSearchModeEnum.CheckExport : ListVMSearchModeEnum.Export;
            var data = vm.GenerateExcel();
            return File(data, "application/vnd.ms-excel", $"Export_Template_{DateTime.Now.ToString("yyyy-MM-dd")}.xls");
        }

    }
   
}
