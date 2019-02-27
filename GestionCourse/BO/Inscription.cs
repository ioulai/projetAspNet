using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Inscription
    {
        public int Id { get; set; } // l'id de l'inscription

        public float Amount { get; set; } // ??? 

        public int IdentityModelId { get; set; } // l'id de la personne qui s'inscrit

        public int RaceId { get; set; } // l'id de la course  laquelle la personne s'inscrit

        public int TypeInscriptionId { get; set; } // // l'id correspondant au type d'inscription (la personne s'inscrit en tant que compétiteur ou organisateur)

        // atributs à étudier : "Number", "Positions" -> correspondent à quoi?
    }
}
