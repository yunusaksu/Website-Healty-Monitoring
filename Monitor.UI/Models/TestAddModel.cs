using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Monitor.UI.Models
{
    public class TestAddModel
    {
        public Guid CustomerId { get; set; }

        [Display(Name = "Test Name")]
        public string TestName { get; set; }

        [Required(ErrorMessage = "Lütfen url adresini girin!")]
        [Display(Name = "URL")]
        public string Url { get; set; }

    }
}