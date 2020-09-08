using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GameStoreClietUI.Models
{
    public class GameCreateViewModel
    {
      
        public int Id { get; set; }
        [Display(Name="Game name:")]
        [Required(ErrorMessage ="Please enter game name",AllowEmptyStrings =true)]
        [MinLength(2)]
        [StringLength(100)]
        //[RegularExpression("")]
        public string Name { get; set; }
        [Display(Name="Price")]
        [Required(ErrorMessage ="Enter price")]
        public int Price { get; set; }
        [Display(Name = "Year:")]
        [Range(1980,2020,ErrorMessage ="Year not valid")]
        [Required(ErrorMessage = "Please enter year")]
        public int Year { get; set; }

        [Display(Name = "Desc:")]
        [Required(ErrorMessage = "Please enter game description")]
        public string Description { get; set; }

        [Display(Name = "Image:")]
        public string Image { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        [ForeignKey("Developer")]
        public int DeveloperId { get; set; }
        [Display(Name = "Genre:")]
        [Required(ErrorMessage = "Please chouse game genre")]
        public string  Genre { get; set; }

        [Display(Name = "Developer:")]
        [Required(ErrorMessage = "Please chouse game developer")]
        public string  Developer { get; set; }
    }
}