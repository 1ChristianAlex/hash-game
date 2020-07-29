using API.HashGame.Services.DTO.Game;
using System;
using System.Runtime.Serialization;

namespace API.HashGame.Services.DTO.Player
{
    public class PlayerOutputDto
    {
        [DataMember(Name = "id")]
        public Guid Id { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "isUsed")]
        public bool IsUsed { get; set; }

        [DataMember(Name = "xPosition")]
        public int XPosition { get; set; }

        [DataMember(Name = "yPosition")]
        public int YPosition { get; set; }

    }
}