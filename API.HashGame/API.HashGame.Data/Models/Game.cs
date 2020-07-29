using API.HashGame.Data.Enumerator;
using System;
using System.Collections.Generic;

namespace API.HashGame.Data.Models
{
    public class Game
    {
        #region Constructor
        public Game()
        {
            Id = Guid.NewGuid();
            Players = new List<Player>();
            CreateDate = DateTime.Now;
        }
        #endregion

        #region Properties

        public Guid Id { get; set; }
        public string CurrentTurn { get; set; }
        public string GameState { get; set; }

        public DateTime CreateDate { get; set; }
        public StatusEnum Status { get; set; }

        public virtual List<Player> Players { get; set; }
        #endregion
    }
}