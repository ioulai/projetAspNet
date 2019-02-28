using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Race
    {
        public int Id { get; set; }
        public Category Category { get; set; } //virtual??
        public DateTime DateEnd { get; set; }
        public DateTime DateStart { get; set; }
        public string Description { get; set; }
        public List<Inscription> Inscriptions { get; set; }
        //public List<Poi> Pois { get; set; }
        public float Price { get; set; }
        public string Title { get; set; }
        public string ZipCode { get; set; }
    }
}
