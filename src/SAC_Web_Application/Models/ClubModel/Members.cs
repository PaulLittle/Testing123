using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SAC_Web_Application.Models.ClubModel
{
    [Table("Member")]
    public class Members
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MemberID { get; set; }
        [ForeignKey("AspNetUsers")]        
        public string Email { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateRegistered { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Column(TypeName = "date")]
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string TeamName { get; set; }
        public string CountyOfBirth { get; set; }
        public string Province { get; set; }
        public bool MembershipPaid { get; set; }

        public virtual ApplicationUser AspNetUsers { get; set; }
    }
}
