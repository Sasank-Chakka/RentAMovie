//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.ComponentModel.DataAnnotations;

//namespace RentAMovie.Models
//{
//    public class Movie
//    {

//        public int id { get; set; }

//        [Required]
//        [StringLength(50)]
//        [Display(Name ="Movie Name")]
//        public string name { get; set; }

//        [Required]
//        [Display(Name="ReleaseDate")]
//        [DataType(DataType.Date)]
//        public DateTime ReleaseDate { get; set; }

//        [Required]
//        [Display(Name = "AddDate")]
//        [DataType(DataType.Date)]
//        public DateTime AddDate { get; set; }

//        //creating referance
//        public Genre Genre { get; set; }


//        [Required]
//        [Display(Name = "Stock_Available")]
//        public int Stock_Available { get; set; }

//        //create refernce
//        public Genre genre { get; set; }

       
//        //add referance
//        [Display(Name ="Genreid")]
//        public int Genreid { get; set; }
   

//    }
//}