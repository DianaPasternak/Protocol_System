using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProtocolSystem.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не вказаний Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не вказаний Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не вказаний Surname")]
        public string Surname { get; set; }

        public string DrivingLicenceId { get; set; }

        [Required(ErrorMessage = "Не вказаний DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Не вказаний Address")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Не вказаний DrivingLicenceDate")]
        public string DrivingLicenceDate { get; set; }

        [Required(ErrorMessage = "Не вказаний Citizenship")]
        public string Citizenship { get; set; }

        [Required(ErrorMessage = "Не вказаний PlaceOfWork")]
        public string PlaceOfWork { get; set; }

        [Required(ErrorMessage = "Не вказаний PassportData")]
        public string PassportData { get; set; }

        [Required(ErrorMessage = "Не вказаний Post")]
        public string Post { get; set; }

        [Required(ErrorMessage = "Не вказаний пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введений неправильно")]
        public string ConfirmPassword { get; set; }
    }
}
