using System;
using System.Collections.Generic;
using System.Text;

namespace ezBet.WebAPI.Model.Entities
{
    public class Bet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Score { get; set; }
        public int GameId { get; set; }
    }
}
