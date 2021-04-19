using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradProjectV5.Models
{
    [MetadataType(typeof(MemberData))]
    public partial class Member
    {

    }
    public class MemberData
    {
        [Required(ErrorMessage = "يتطلب ادخال الإسم ")]
        [Display(Name = "الاسم بالكامل")]
        public string FullName { get; set; }
        //[Required(ErrorMessage = "يتطلب ادخال هذا الحقل ")]
        //[Display(Name = "الرقم القومي")]
        //public string NationalId { get; set; }


        //[Required(ErrorMessage = "يتطلب ادخال هذا الحقل ")]
        //[DataType(DataType.EmailAddress)]
        //[Display(Name = "البريد الإلكتروني")]
        //public string Email { get; set; }

        //[Required(ErrorMessage = "يتطلب ادخال هذا الحقل ")]
        //[Display(Name = "رقم الهاتف")]
        //[DataType(DataType.PhoneNumber)]
        //public string PhoneNo { get; set; }
        //public Nullable<int> CityId { get; set; }
        //[Required(ErrorMessage = "يتطلب ادخال هذا الحقل ")]
        //[Display(Name = "العنوان")]
        //public string Address { get; set; }

        [Required(ErrorMessage = "يتطلب ادخال العمر ")]
        [Display(Name = "العمر ")]
        public Nullable<int> Age { get; set; }

        
    }
}