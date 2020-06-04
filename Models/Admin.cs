using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WalkingTec.Mvvm.Core;

namespace YG.Models
{
    [Table("FrameworkUsers")]
    public class Admin : FrameworkUserBase
    {
        [Display(Name = "所属机构")]
        public Guid OrganId { get; set; }
        [Display(Name = "所属机构")]
        public Organ Organ { get; set; }
        [Display(Name = "MAC地址")]
        public string MAC { get; set; }
        [Display(Name = "印章1")]
        public Guid? Seal1Id { get; set; }
        [Display(Name = "印章1")]
        public FileAttachment Seal1 { get; set; }
        [Display(Name = "印章2")]
        public Guid? Seal2Id { get; set; }
        [Display(Name = "印章2")]
        public FileAttachment Seal2 { get; set; }
        [Display(Name = "印章3")]
        public Guid? Seal3Id { get; set; }
        [Display(Name = "印章3")]
        public FileAttachment Seal3 { get; set; }
        [Display(Name = "印章4")]
        public Guid? Seal4Id { get; set; }
        [Display(Name = "印章4")]
        public FileAttachment Seal4 { get; set; }

    }
}
