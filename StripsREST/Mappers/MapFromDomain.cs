using StripsBL.DTOs;
using StripsREST.Model.Output;

namespace StripsREST.Mappers
{
    public static class MapFromDomain
    {
        public static ReeksRESToutputDTO MapFromReeksDTODomain(string url, ReeksDTO reeks)
        {
            ReeksRESToutputDTO reeksDTO = new ReeksRESToutputDTO(url, reeks.ID, reeks.Naam, reeks.Strips);
            return reeksDTO;
        }
    }
}
