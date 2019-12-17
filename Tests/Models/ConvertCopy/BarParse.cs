using SimpleMapper.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Models.ConvertCopy
{
    [MapDestination(typeof(FooParse))]
    public class BarParse
    {
        public string FirstName { get; set; }
        public string Age { get; set; }
        public string SecondsAlive { get; set; }
        public string MoneyToTheWallet { get; set; }
        public string GPA { get; set; }
        public DateTime Birthdate { get; set; }
        public TimeSpan TimeSpanAlive { get; set; }
        public bool IsHappy { get; set; }
    }
}
