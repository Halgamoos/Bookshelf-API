namespace Bookshelf_API.Model
{
    /// <summary>
    /// This class is used to generate the response model for the API based on the final requirements.
    public class Response<Generic>
    {
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; } = string.Empty;
        public Generic? Items { get; set; }

        public Response(int status_code, string status_description, Generic? items)
            => (StatusCode, StatusDescription, Items) = (status_code, status_description, items);
    }
}