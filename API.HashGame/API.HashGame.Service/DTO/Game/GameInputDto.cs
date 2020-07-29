using API.HashGame.Data.Enumerator;
using System;
using System.Runtime.Serialization;

namespace API.HashGame.Services.DTO.Game
{
    public class GameInputDto
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "currentTurn")]
        public string CurrentTurn { get; set; }

        [DataMember(Name = "gameState")]
        public string GameState { get; set; }

        [DataMember(Name = "status")]
        public StatusEnum Status { get; set; }
    }
}