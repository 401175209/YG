using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core.Extensions;
using YG.WorkArea.ViewModels.WorkVMs;
using YG.TemplateArea.ViewModels.TemplateVMs;

namespace YG.Controllers
{
    [Area("WorkArea")]
    [ActionDescription("事务管理")]
    public partial class WorkController : BaseController
    {
       
        #region Search
        [ActionDescription("Search")]
        public ActionResult Index()
        {
            var vm = CreateVM<WorkListVM>();
            return PartialView(vm);
        }

        [ActionDescription("Search")]
        [HttpPost]
        public string Search(WorkListVM vm)
        {
            return vm.GetJson(false);
        }

        #endregion

        #region Create
        [ActionDescription("Create")]
        public ActionResult Create()
        {
            var vm = CreateVM<WorkVM>();
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("Create")]
        public ActionResult Create(WorkVM vm)
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
            var vm = CreateVM<WorkVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("Edit")]
        [HttpPost]
        [ValidateFormItemOnly]
        public ActionResult Edit(WorkVM vm)
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
            var vm = CreateVM<WorkVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("Delete")]
        [HttpPost]
        public ActionResult Delete(string id, IFormCollection nouse)
        {
            var vm = CreateVM<WorkVM>(id);
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
            var vm = CreateVM<WorkVM>(id);
            return PartialView(vm);
        }
        #endregion

        #region BatchEdit
        [HttpPost]
        [ActionDescription("BatchEdit")]
        public ActionResult BatchEdit(string[] IDs)
        {
            var vm = CreateVM<WorkBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("BatchEdit")]
        public ActionResult DoBatchEdit(WorkBatchVM vm, IFormCollection nouse)
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
            var vm = CreateVM<WorkBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("BatchDelete")]
        public ActionResult DoBatchDelete(WorkBatchVM vm, IFormCollection nouse)
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
            var vm = CreateVM<WorkImportVM>();
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("Import")]
        public ActionResult Import(WorkImportVM vm, IFormCollection nouse)
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
        public IActionResult ExportExcel(WorkListVM vm)
        {
            vm.SearcherMode = vm.Ids != null && vm.Ids.Count > 0 ? ListVMSearchModeEnum.CheckExport : ListVMSearchModeEnum.Export;
            var data = vm.GenerateExcel();
            return File(data, "application/vnd.ms-excel", $"Export_Work_{DateTime.Now.ToString("yyyy-MM-dd")}.xls");
        }

    }
}
