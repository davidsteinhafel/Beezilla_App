using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DisplayName("Total Number of Frames Covered in Bees")]
        public int NumberOfFrames { get; set; }
        [DisplayName("Bee's Temperament")]
        public string Temperament { get; set; }
        [DisplayName("Estimated Total Brood")]
        public int Brood { get; set; }
        [DisplayName("Brood Pattern")]
        public string BroodPattern { get; set; }
        [DisplayName("Estimated Size of Hive Population")]
        public string Size { get; set; }
        //Size drop down list; small, med, large
        [DisplayName("Species of Bee")]
        public string Species { get; set; }
        [DisplayName("Number of Mites From Sugar/Alchohol Test")]
        public int Mites { get; set; }
        [DisplayName("Where's Hive From(eg.Nuc/Wild/Ordered)")]
        public string HiveType { get; set; }
        //drop down list; Nuc, Wild Caught, Out of State, Other etc.
        [DisplayName("Amount of Propolis")]
        public string Propolis { get; set; }
        [DisplayName("Profile Picture")]
        public string HiveImageUrl { get; set; }
        public int QueenCells { get; set; }
        //*weak, average, strong*
        [DisplayName("Strength of Hive")]
        public string HiveStrength { get; set; }
        //*risk to swarm; low, medium, high*
        [DisplayName("Swarming Risk")]
        public string SwarmPotential { get; set; }
        [DisplayName("Latitude")]
        public decimal HiveLat { get; set; }
        [DisplayName("Longitude")]
        public decimal HiveLon { get; set; }
        [ForeignKey("KeeperModel")]
        public int KeeperModelId { get; set; }
        public KeeperModel KeeperModel { get; set; } 
    }
}
