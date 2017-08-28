using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Monitor.UI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Lütfen Name alanını boş bırakmayın.")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        
        [Required(ErrorMessage ="Lütfen mail adresinizi girin.")]
        [Display(Name="E-Mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen şifrenizi girin.")]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        public string Password { get; set; }

        public string RegisterErrorMessage { get; set; }

    }
}
