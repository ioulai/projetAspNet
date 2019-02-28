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

        [Display(Name = "Date de fin")]
        public DateTime DateEnd { get; set; }

        [Display(Name = "Date de début")]
        public DateTime DateStart { get; set; }

        public string Description { get; set; }

        public List<Inscription> Inscriptions { get; set; }

        public List<Poi> Pois { get; set; }

        [Display(Name = "Prix")]
        public float Price { get; set; }

        [Display(Name = "Titre")]
        public string Title { get; set; }

        [Display(Name = "Code postal")]
        public string ZipCode { get; set; }
    }
}
