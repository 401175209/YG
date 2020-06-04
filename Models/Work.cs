using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace YG.Models
{
    public enum WorkStatusEnum
    {
       
        [Display(Name = "已驳回")]
        Undo,
        [Display(Name = "待审批")]
        Doing,
        [Display(Name = "流转中")]
        Sending,
        [Display(Name = "已审批")]
        Done,
        [Display(Name = "已完结")]
        Finish,
    }
   
    public class Work : PersistPoco
    {

        [Display(Name = "事务")]
        [StringLength(50, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }
       
        [Display(Name = "是否撤回")]

        public bool WithDraw { get; set; }

        [Display(Name = "发起人")]
        public Admin Starter { get; set; }
        [Display(Name = "发起人")]
        public Guid? StarterId { get; set; }
        [Display(Name = "接受人")]
        public Admin Receiver { get; set; }
        [Display(Name = "接受人")]
        public Guid? ReceiverId { get; set; }
        [Display(Name = "状态")]
        public WorkStatusEnum WorkStatus { get; set; }
        [Display(Name = "模版")]
        public Template Template { get; set; }
        [Display(Name = "模版")]
        public Guid? TemplateId { get; set; }
        [Display(Name = "流程")]
        public List<WorkHistory> WorkHistories { get; set; }
        [Display(Name = "字段值")]
        public List<WorkKeyValue> WorkKeyValues { get; set; }

    }
    public class WorkKeyValue : TopBasePoco
    {
        [Display(Name = "事务")]
        public Work Work { get; set; }
        [Display(Name = "事务")]
        public Guid? WorkId { get; set; }
        public string Key { get; set; }

        public string Value { get; set; }


    }
}