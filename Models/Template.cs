using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using WalkingTec.Mvvm.Core;

namespace YG.Models
{

    public class Template : PersistPoco
    {
        [Display(Name = "模版编号")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Description { get; set; }
        [Display(Name = "模版名称")]
        [StringLength(50, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string Name { get; set; }
        [Display(Name = "模版内容")]
        public string Context { get; set; }
    }
   
   
}

