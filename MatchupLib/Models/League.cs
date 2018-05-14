using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchupLib.Models
{
    public enum LeagueType
    {
        AHL,
        VHL,
        MHL,
        WHL,
        OHL,
        QMJHL,
        SHL,
        Allsvenskan,
    }

    class League
    {
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
    }
}
