namespace Projekt_Back_End.Models.Domain
{
    public class Screening
    {
        public Guid Id { get; set; }
        public DateTime Time_Of_Start { get; set; }
        public DateTime Time_Of_End { get; set; }
        
        //Navigation


        public Movie Movie { get; set; }   
        public Screening_Room Room { get; set; }

    }
}
