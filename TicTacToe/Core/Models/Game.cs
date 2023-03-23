﻿namespace Core.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int IdFirstPlayer { get; set; }
        public int IdSecondPlayer { get; set; }
        public int Steps { get; set; }
        public int[] Field { get; set; } = new int[0];
        public string Winner { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;

    }
}
