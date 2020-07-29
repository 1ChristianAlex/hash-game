using API.HashGame.Services.DTO.Game;
using API.HashGame.Services.DTO.Player;
using System;

namespace API.HashGame.Services.Services.Interfaces
{
    public interface IPlayerService
    {
        GameOutputDto CreatePlayers(Guid gameId);
        PlayerOutputDto JoinGame(Guid gameId);

        PlayerOutputDto UnJoinGame(PlayerInputDto player);
        PlayerOutputDto Moviment(PlayerInputDto play);

        
    }
}
