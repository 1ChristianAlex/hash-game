using System.Collections.Generic;
using HashGame.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HashGame.Interface
{
    public interface IGameService

    {
        Game CreateGame();
        List<Game> GetAll();
    }
}