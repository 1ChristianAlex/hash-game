using HashGame.Models;

namespace HashGame.Interface
{
    public interface IPlayerService
    {
        void CreatePlayers(int gameId);
        Player JoinGame(int gameId);
        Player Moviment(int playerId, int positionX, int positionY);

    }
}