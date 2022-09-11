namespace Projekt_Back_End.Models.Domain
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public string Image { get; set; }

        //Navigation

        public IEnumerable<Movie_Key> Keys { get; set; }

    }
}
