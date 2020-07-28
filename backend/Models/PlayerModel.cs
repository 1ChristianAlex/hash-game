using System.ComponentModel.DataAnnotations;
namespace HashGame.Models
{
    public class Player
    {
        public int id { get; set; }
        public string guid { get; set; }

        public string player { get; set; }

        public int xPosition { get; set; }
        public int yPosition { get; set; }
        public int gameId { get; set; }
        public bool login { get; set; }
    }
}