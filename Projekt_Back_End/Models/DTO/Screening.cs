namespace Projekt_Back_End.Models.DTO
{
    public class Screening
    {
        public Guid Id { get; set; }
        public DateTime Time_Of_Start { get; set; }
        public DateTime Time_Of_End { get; set; }

        //Navigation


        public Guid MovieId { get; set; }
        public Guid RoomId { get; set; }
    }
}
