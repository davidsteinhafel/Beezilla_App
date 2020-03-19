using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Beezilla.Models
{
    public class QueenModel
    {
        [Key]
        public int Id { get; set; }
        public bool Seen { get; set; }
        public bool Marked { get; set; }
        public DateTime QueenStart { get; set; }
        public DateTime QueenEnd { get; set; }
    }
}
