using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RentAMovie.Models
{
    public class Customer
    {
        public int id { get; set; }
        [Required(ErrorMessage ="no no don't leave me")]

        [StringLength(100)]
        [Display(Name ="Customer Name")]
        public string name { get; set; }


        [Required]
        [Display(Name ="Birth Date")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        //Referencing a Table
        public MembershipType MembershipType { get; set; }
        [Required]
        //referancing a column
        [Display(Name ="Membership Type")]
        public int MembershipTypeId { get; set; }
    }

}