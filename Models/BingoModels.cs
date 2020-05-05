
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Bingo.Models
{
    public class BingoCard
    {
        public int CardNumber { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<BingoNumber> Numbers { get; set; }

        [NotMapped]
        public IOrderedEnumerable<BingoNumber> OrderedNumbers => Numbers.OrderBy(c => c.Order);
    }

    public class BingoNumber
    {
        public int CardNumber { get; set; }
        public int Number { get; set; }
        public int Order { get; set; }
        public virtual BingoCard Card { get; set; }
    }
}