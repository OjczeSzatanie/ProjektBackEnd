namespace Projekt_Back_End.Models.DTO
{
    public class UpdateKeyRequest
    {
        public DateTime Time_Of_Start { get; set; }
        public DateTime Time_Of_End { get; set; }
        public Guid MovieId { get; set; }

    }
}
