using StripsBL.DTOs;
using StripsBL.Exceptions;
using StripsBL.Interfaces;
using StripsBL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StripsBL.Managers
{
    public class StripsManager
    {
        private IStripsRepository stripsRepository;

        public StripsManager(IStripsRepository stripsRepository)
        {
            this.stripsRepository = stripsRepository;
        }

        public ReeksDTO GetReeks(int id)
        {
            try
            {
                Reeks reeks =  stripsRepository.GetReeks(id);
                ReeksDTO reeksDTO = new ReeksDTO(reeks.ID, reeks.Naam);
                foreach (Strip strip in reeks.Strips)
                {
                    reeksDTO.Strips.Add(new StripDTO(strip.ID, strip.Titel, strip.Nr));
                }
                return reeksDTO;

            }
            catch (StripsManagerException e)
            {
                throw new StripsManagerException(e.Message);
            }
        }
    }
}
