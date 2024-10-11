using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNO
{
    public class Players
    {
        public int playernumber { get; set; }
        public string playername { get; set; }
        public List<Cards> playerhand {  get; set; }
    }
}
