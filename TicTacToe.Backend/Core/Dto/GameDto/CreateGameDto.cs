namespace Core.Dto.GameDto
{
    public class CreateGameDto
    {
        public int IdFirstPlayer { get; set; }
        public int IdSecondPlayer { get; set; }
        public int Steps { get; set; }
        public string Field { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
