using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Beezilla.Models
{
    public class QueenModel
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Queen Accounted For?")]
        public bool Seen { get; set; }
        [DisplayName(("Queen Marked?"))]
        public bool Marked { get; set; }
        [DisplayName("Date Queen Started")]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString ="{0:d}")]
        public DateTime Start { get; set; }
        [DisplayName("Date Queen Stopped")]
        public DateTime End { get; set; }
        [DisplayName("Queen Job Performance?")]
        public string Job { get; set; }
        //dropdown list? poor, good, great
        [ForeignKey("Hive #")]
        public int HiveModelId { get; set; }
        public HiveModel HiveModel { get; set; }
    }
}
