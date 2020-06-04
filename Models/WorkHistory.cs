using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace YG.Models
{
  
   
    public class WorkHistory : PersistPoco
    {
        [Display(Name = "事务")]
        public Work Work { get; set; }
        [Display(Name = "事务")]
        public Guid? WorkId { get; set; }
        [Display(Name = "接受人")]
        public Admin Receiver { get; set; }
        [Display(Name = "接受人")]
        public Guid? ReceiverId { get; set; }
        [Display(Name = "意见")]
        public string Advice { get; set; }

    }
}