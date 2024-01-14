using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RowingWeb.API.Data;
using RowingWeb.API.Helpers;
using RowingWeb.Shared.DTOs;

namespace RowingWeb.API.Controllers
{
    [ApiController]
    [Route("/api/obras")]
    public class ObrasController : ControllerBase
    {
        private readonly DataContext _context;

        public ObrasController(DataContext context)
        {
            _context = context;
        }
           
        [HttpGet]
        [Route("GetObras/{ProyectoModulo}")]
        public async Task<IActionResult> GetAsync(string ProyectoModulo,[FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Obras
                //.Include(p => p.ObrasDocumentos)
                .Where(o => (o.Finalizada == 0 && o.ULTIMAACTA == 0)
                    && (o.Modulo == ProyectoModulo))
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.NombreObra!.ToLower().Contains(pagination.Filter.ToLower())
                || x.ELEMPEP!.ToLower().Contains(pagination.Filter.ToLower())
                || x.CodigoEstado!.ToLower().Contains(pagination.Filter.ToLower())
                || x.CodigoSubEstado!.ToLower().Contains(pagination.Filter.ToLower())

                );
            }


            return Ok(await queryable
                .OrderBy(o => o.NroObra)
                .Paginate(pagination)
                .ToListAsync());
        }

        [HttpGet]
        [Route("totalPages/{ProyectoModulo}")]
        public async Task<ActionResult> GetPages(string ProyectoModulo, [FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Obras
                //.Include(p => p.ObrasDocumentos)
                .Where(o => (o.Finalizada == 0 && o.ULTIMAACTA == 0)
                    && (o.Modulo == ProyectoModulo))
                    .AsQueryable();

            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.NombreObra!.ToLower().Contains(pagination.Filter.ToLower())
                || x.ELEMPEP!.ToLower().Contains(pagination.Filter.ToLower())
                || x.CodigoEstado!.ToLower().Contains(pagination.Filter.ToLower())
                || x.CodigoSubEstado!.ToLower().Contains(pagination.Filter.ToLower()));
            }

            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }

    }
}
