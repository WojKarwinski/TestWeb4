using StripsBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.DTOs
{
    public class StripDTO
    {
        public StripDTO()
        {
        }
        public StripDTO(int iD, string titel, int? nr)
        {
            ID = iD;
            Titel = titel;
            Nr = nr;
        }

        public int ID { get; set; }
        public string Titel { get; set; }
        public int? Nr { get; set; }
    }
}
