using System;

namespace API.HashGame.Data.Models
{
    public class Player
    {
        #region Construtor
        public Player()
        {
            Id = Guid.NewGuid();
           
        }

        #endregion

        #region Properties

        public Guid Id { get; set; }
        public Guid GameId { get; set; }
        public string Name { get; set; }
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public bool IsUsed { get; set; }

        #endregion

        #region Foreing Key
        public virtual Game Game { get; set; }

        #endregion
    }
}