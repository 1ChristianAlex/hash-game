using API.HashGame.Data.Enumerator;
using API.HashGame.Services.DTO.Player;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace API.HashGame.Services.DTO.Game
{
    public class GameOutputDto
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "currentTurn")]
        public string CurrentTurn { get; set; }

        [DataMember(Name = "gameState")]
        public string GameState { get; set; }

        [DataMember(Name = "status")]
        public StatusEnum Status { get; set; }

        [DataMember(Name = "players")]
        public ICollection<PlayerOutputDto> Players { get; set; }
    }
}
