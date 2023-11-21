using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Luceed.ClientApp.Models
{
    public class QueryInputData
    {
        [Display(Name = "Item description")]
        public string FieldQ1F1 { get; set; }




        [Display(Name = "Item UID")]
        public string FieldQ2F1 { get; set; }
        [Display(Name = "Date from")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FieldQ2F2 { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date to")]
        public DateTime FieldQ2F3 { get; set; }



        [Display(Name = "Item UID")]
        public string FieldQ3F1 { get; set; }
        [Display(Name = "Date from")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FieldQ3F2 { get; set; }
        [Display(Name = "Date to")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FieldQ3F3 { get; set; }

        
    }
}