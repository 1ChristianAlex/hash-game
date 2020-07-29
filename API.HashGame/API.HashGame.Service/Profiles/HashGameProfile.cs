using API.HashGame.Data.Models;
using API.HashGame.Services.DTO.Game;
using API.HashGame.Services.DTO.Player;
using AutoMapper;

namespace API.HashGame.Services.Profiles
{
    public class HashGameProfile : Profile
    {
        public HashGameProfile()
        {
            CreateMap<Game, GameOutputDto>().ReverseMap();
            CreateMap<GameOutputDto, Game>().ReverseMap();

            CreateMap<Player, PlayerOutputDto>().ReverseMap();
            CreateMap<PlayerOutputDto, Player>().ReverseMap();
        }
    }
}
