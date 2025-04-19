namespace Entities.RequestFeatures
{
    public class PostParameters : RequestParameters {

        public string? SearchTerm { get; set; }
        public PostParameters()
        {
            OrderBy = "id";
        }

    }
}