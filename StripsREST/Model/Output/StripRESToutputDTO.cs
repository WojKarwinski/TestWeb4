namespace StripsREST.Model.Output
{
    public class StripRESToutputDTO
    {
        public StripRESToutputDTO(int? nr, string titel, string url)
        {
            Nr = nr;
            Titel = titel;
            Url = url;
        }

        public StripRESToutputDTO(int? nr, string titel)
        {
            Nr = nr;
            Titel = titel;
        }

        public int? Nr { get; set; }
        public string Titel { get; set; }

        public string Url { get; set; }
    }
}
