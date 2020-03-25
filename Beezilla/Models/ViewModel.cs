using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beezilla.Models
{
    public class ViewModel
    {
        public HiveModel HiveModel { get; set; }
        public KeeperModel KeeperModel { get; set; }
        public QueenModel QueenModel { get; set; }
    }
}
