using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilkioPersonalPage.Models
{
    public class SubResponce
    {
        [Required(ErrorMessage ="Введите имя")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Введите почту")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Неккоректно указан почтовый адрес")]
        public string EMail { get; set; }
        [Required(ErrorMessage ="Введите номер телефона")]
        public string Phone { get; set; }
    }
}
