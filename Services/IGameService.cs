using HashGame.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HashGame.Interface
{
    public interface IGameService

    {
        string CreateGame(int id);
    }
}