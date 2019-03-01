using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BO
{
    public class Race
    {
        public int Id { get; set; }

        [Display(Name = "Catégorie")]
        public Category Category { get; set; } //virtual??

        [Required]
        [Display(Name = "Date de fin")]
        public DateTime DateEnd { get; set; }

        [Required]
        [Display(Name = "Date de début")]
        public DateTime DateStart { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "La Description doit contenir entre 5 et 200 caractères")]
        public string Description { get; set; }

        public List<Inscription> Inscriptions { get; set; }

        public List<Poi> Pois { get; set; }

        [Required]
        [Display(Name = "Prix")]
        public float Price { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Le Titre doit contenir entre 5 et 25 caractères")]
        [Display(Name = "Titre")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Code postal")]
        public string ZipCode { get; set; }
    }
}
