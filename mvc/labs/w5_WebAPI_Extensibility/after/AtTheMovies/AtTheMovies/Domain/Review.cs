namespace AtTheMovies.Domain
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Reviewer { get; set; }
        public string Summary { get; set; }
        public Movie Movie { get; set; }
    }

}