using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SAC_Web_Application.Models.AccountViewModels
{
    public class SubscriptionsViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Surame")]
        public string Surname { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Address1")]
        public string Address1 { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Address2")]
        public string Address2 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "County")]
        public string County { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Province")]
        public string Province { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }       

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "County of Birth")]
        public string CountyofBirth { get; set; }
    }
}
