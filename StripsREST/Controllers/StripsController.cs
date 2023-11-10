using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StripsBL.DTOs;
using StripsBL.Exceptions;
using StripsBL.Managers;
using StripsBL.Model;
using StripsREST.Exceptions;
using StripsREST.Mappers;
using StripsREST.Model.Output;

namespace StripsREST.Controllers
{
    [Route("api/[controller]/beheer")]
    [ApiController]
    public class StripsController : ControllerBase
    {
        private StripsManager stripsManager;
        private string url = $"http://localhost:5008/api/strips/beheer";

        public StripsController(StripsManager stripsManager)
        {
            this.stripsManager = stripsManager;
        }

        [HttpGet("Reeks/{id}")]
        public ActionResult<ReeksRESToutputDTO> GetReeks(int id)
        {
            try
            {
                ReeksDTO reeks = stripsManager.GetReeks(id);
                if (reeks == null)
                {
                    return NotFound();
                }

               return MapFromDomain.MapFromReeksDTODomain(url, reeks);
            }
            catch (StripException e)
            {
                return BadRequest($"Fout tijdens ophalen: {e.Message}");
            }
        }
        
    }
}
