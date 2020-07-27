using System.Collections.Generic;

namespace Game.DTO
{
    public class MoveGameDTO
    {
        public int id { get; set; }
        public string player { get; set; }
        public Dictionary<string, int> position { get; set; }

    }
}