
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bingo.Models
{
    public class BingoCard
    {
        [Key]
        public int CardNumber { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<BingoNumber> Numbers { get; set; }
    }

    public class BingoNumber
    {
        public int CardNumber { get; set; }
        public int Number { get; set; }
        public virtual BingoCard Card { get; set; }
    }
}