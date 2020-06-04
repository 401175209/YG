﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Mvc;
using WalkingTec.Mvvm.Core.Extensions;
using YG.OrganArea.ViewModels.OrganVMs;

namespace YG.Controllers
{
    [Area("OrganArea")]
    [ActionDescription("机构管理")]
    public partial class OrganController : BaseController
    {
        #region Search
        [ActionDescription("Search")]
        public ActionResult Index()
        {
            var vm = CreateVM<OrganListVM>();
            return PartialView(vm);
        }

        [ActionDescription("Search")]
        [HttpPost]
        public string Search(OrganListVM vm)
        {
            return vm.GetJson(false);
        }

        #endregion

        #region Create
        [ActionDescription("Create")]
        public ActionResult Create()
        {
            var vm = CreateVM<OrganVM>();
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("Create")]
        public ActionResult Create(OrganVM vm)
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
            var vm = CreateVM<OrganVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("Edit")]
        [HttpPost]
        [ValidateFormItemOnly]
        public ActionResult Edit(OrganVM vm)
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
            var vm = CreateVM<OrganVM>(id);
            return PartialView(vm);
        }

        [ActionDescription("Delete")]
        [HttpPost]
        public ActionResult Delete(string id, IFormCollection nouse)
        {
            var vm = CreateVM<OrganVM>(id);
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
            var vm = CreateVM<OrganVM>(id);
            return PartialView(vm);
        }
        #endregion

        #region BatchEdit
        [HttpPost]
        [ActionDescription("BatchEdit")]
        public ActionResult BatchEdit(string[] IDs)
        {
            var vm = CreateVM<OrganBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("BatchEdit")]
        public ActionResult DoBatchEdit(OrganBatchVM vm, IFormCollection nouse)
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
            var vm = CreateVM<OrganBatchVM>(Ids: IDs);
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("BatchDelete")]
        public ActionResult DoBatchDelete(OrganBatchVM vm, IFormCollection nouse)
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
            var vm = CreateVM<OrganImportVM>();
            return PartialView(vm);
        }

        [HttpPost]
        [ActionDescription("Import")]
        public ActionResult Import(OrganImportVM vm, IFormCollection nouse)
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
        public IActionResult ExportExcel(OrganListVM vm)
        {
            vm.SearcherMode = vm.Ids != null && vm.Ids.Count > 0 ? ListVMSearchModeEnum.CheckExport : ListVMSearchModeEnum.Export;
            var data = vm.GenerateExcel();
            return File(data, "application/vnd.ms-excel", $"Export_Organ_{DateTime.Now.ToString("yyyy-MM-dd")}.xls");
        }

    }
}
