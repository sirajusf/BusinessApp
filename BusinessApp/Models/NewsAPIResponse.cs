namespace BusinessApp.Models
{
    public class NewsAPIResponse
    {
        public string? status { get; set; }
        public int totalResults { get; set; }
        public List<Headline> articles { get; set; }


    }
}
