using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradProjectV5.Models
{
    [MetadataType(typeof(AspNetUserAnnotations))]
    public partial class AspNetUser
    {
    }
    public class AspNetUserAnnotations
    {
        [Required(ErrorMessage = "يتطلب ادخال هذا الحقل ")]
        [Display(Name = "البريد الإلكتروني")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(ErrorMessage = "يتطلب ادخال هذا الحقل ")]
        [Display(Name = "الرقم السري")]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }


    }


    
}