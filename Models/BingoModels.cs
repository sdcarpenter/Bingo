
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
        public List<string> OrderedNumbers
        {
            get
            {
                if (_orderedNumbers != null)
                    return _orderedNumbers;

                _orderedNumbers = Numbers
                    .OrderBy(c => c.Order)
                    .Select(c => c.Number.ToString())
                    .ToList();

                _orderedNumbers.Insert(12, "FREE");

                return _orderedNumbers;
            }
        }

        private List<string> _orderedNumbers;
    }

    public class BingoNumber
    {
        public int CardNumber { get; set; }
        public int Number { get; set; }
        public int Order { get; set; }
        public virtual BingoCard Card { get; set; }
    }

    public class BingoGame
    {
        public int GameNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public virtual ICollection<BingoGameNumber> Numbers { get; set; }
    }

    public class BingoGameNumber
    {
        public int GameNumber { get; set; }
        public int Number { get; set; }
        public DateTime DrawTime { get; set; }
        public virtual BingoGame Game { get; set; }
    }


}