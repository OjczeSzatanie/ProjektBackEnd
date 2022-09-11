namespace Projekt_Back_End.Models.DTO
{
    public class AddMovieRequest
    {
        public string Title { get; set; }
        public int Duration { get; set; }
        public string Genre { get; set; }
        public string Image { get; set; }

        public IEnumerable<Movie_Key> Keys { get; set; }

    }
}