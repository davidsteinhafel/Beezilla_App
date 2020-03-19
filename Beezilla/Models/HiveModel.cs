using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Beezilla.Models
{
    public class HiveModel
    {
        [Key]
        public int Id { get; set; }
        public string Temperament { get; set; }
        public int Brood { get; set; }
        //Size drop down list; small, med, large
        public string Size { get; set; }
        public int Supers { get; set; }
        public string Species { get; set; }
        public string Mites { get; set; }
        public string HiveType { get; set; }
        public string Propolis { get; set; }
        public string HiveImageUrl { get; set; }
        public int QueenCells { get; set; }
        [ForeignKey("KeeperModel")]
        public KeeperModel KeeperId { get; set; }
        //*weak, average, strong*
        public string HiveStrength { get; set; }
        //*risk to swarm; low, medium, high*
        public string SwarmPotential { get; set; }
    }
}
