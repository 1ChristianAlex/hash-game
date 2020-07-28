
namespace HashGame.Models
{
    public class Game
    {
        public int id { get; set; }
        public string guid { get; set; }

        public string firstPlayer { get; set; }
        public string currentTurn { get; set; }

        public string gameState { get; set; }
        public string status { get; set; }

    }
}