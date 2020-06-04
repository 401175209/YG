using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace YG.Models
{
    public class Organ : PersistPoco,ITreeData<Organ>
    {
        [Display(Name = "机构编码")]
        [Required(ErrorMessage = "{0}是必填项")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "{0}必须是数字")]
        public string OrganCode { get; set; }
        [Display(Name = "机构名称")]
        [StringLength(50, ErrorMessage = "{0}最多输入{1}个字符")]
        [Required(ErrorMessage = "{0}是必填项")]
        public string OrganName { get; set; }
        public List<Organ> Children { get; set; }
        [Display(Name = "上级机构")]
        public Organ Parent { get; set; }
        [Display(Name = "上级机构")]
        public Guid? ParentId { get; set ; }
    }
}
