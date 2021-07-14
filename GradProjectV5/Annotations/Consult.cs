using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradProjectV5.Models
{

    [MetadataType(typeof(ConsultAnnotations))]
    public partial class Consult
    {

    }

    public class ConsultAnnotations
    {
        [Required(ErrorMessage = "يتطلب ادخال حقل عنوان الإستشارة")]
        [Display(Name = "عنوان الإستشارة")]

        public string ConsultQuestionTitle { get; set; }
        [Required(ErrorMessage = "يتطلب ادخال حقل الإستشارة")]

        [Display(Name = "الإستشارة ")]
        [DataType(DataType.MultilineText)]
        public string ConsultQuestionName { get; set; }
    }
}