using StripsBL.DTOs;
using StripsBL.Model;

namespace StripsREST.Model.Output
{
    public class ReeksRESToutputDTO
    {

        public ReeksRESToutputDTO(string url, int iD, string naam, List<StripDTO> strips)
        {
            URL = $"{url}/reeks/{iD}";
            Naam = naam;
            foreach (StripDTO strip in strips)
            {
                Strips.Add(new StripRESToutputDTO(strip.Nr, strip.Titel, $"{url}/strip/{strip.ID}"));
            }
        }

        public string Naam { get; set; }
        public string URL { get; set; }

        public List<StripRESToutputDTO> Strips { get; set; } = new List<StripRESToutputDTO>();

    }
}