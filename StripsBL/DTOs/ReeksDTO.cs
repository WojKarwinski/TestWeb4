using StripsBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.DTOs
{
    public class ReeksDTO
    {
        public ReeksDTO(string naam)
        {
            Naam = naam;
        }
        public ReeksDTO(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
        }
        public int ID { get; set; }
        public string Naam { get; set; }
        public List<StripDTO> Strips { get; set; } = new List<StripDTO>();
    }
}
