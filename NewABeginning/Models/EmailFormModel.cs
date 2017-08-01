using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NewABeginning.Models
{
    public class EmailFormModel
    {
        [Required, Display(Name = "Your Full Name")]
        public string FromName { get; set; }
        [Required, Display(Name = "Your EmailAddress"), EmailAddress]
        public string FromEmail { get; set; }
        [Required, Display(Name = "Subject")]
        public string Subject { get; set; }
        [Required]
        public string Message { get; set; }
        public HttpPostedFileBase Upload { get; set; }
    }
}