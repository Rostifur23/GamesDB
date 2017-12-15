using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DBGames.Models
{
    public class Game
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Mode { get; set; }

        public int? DeveloperId { get; set; }
        public virtual Developer Developer { get; set; }
        public int? EngineId { get; set; }
        public virtual Engine Engine { get; set; }
        public int? PlatformId { get; set; }
        public virtual Platform Platform { get; set; }
    }
}