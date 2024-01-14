using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RowingWeb.API.Data;
using RowingWeb.Shared.DTOs;
using RowingWeb.Shared.Responses;

namespace RowingWeb.API.Controllers
{
    [ApiController]
    [Route("/api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly DataContext _context;

        public UsuariosController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("GetUserByUsuario")]
        public async Task<IActionResult> GetUserByUsuario(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _context.Usuarios.FirstOrDefaultAsync(o => o.Login.ToLower() == loginDTO.Usuario.ToLower());

            if (user == null)
                {
                    return BadRequest("El Usuario no existe.");
                }
            
            var response = new UsuarioAppResponse
            {
                IDUsuario = user.IDUsuario,
                CodigoCausante = user.CodigoCausante,
                Login = user.Login,
                Contrasena = user.Contrasena,
                Nombre = user.Nombre,
                Apellido = user.Apellido,
                AutorWOM = user.AutorWOM,
                Estado = user.Estado,
                HabilitaAPP = user.HabilitaAPP,
                HabilitaFotos = user.HabilitaFotos,
                HabilitaReclamos = user.HabilitaReclamos,
                HabilitaSSHH = user.HabilitaSSHH,
                HabilitaRRHH = user.HabilitaRRHH,
                Modulo = user.Modulo,
                HabilitaMedidores = user.HabilitaMedidores,
                HabilitaFlotas = user.HabilitaFlotas,
                ReHabilitaUsuarios = user.ReHabilitaUsuarios,
                CODIGOGRUPO = user.CODIGOGRUPO,
                FechaCaduca = user.FechaCaduca,
                IntentosInvDiario = user.IntentosInvDiario,
                OpeAutorizo = user.OpeAutorizo,
                HabilitaNuevoSuministro = user.HabilitaNuevoSuministro,
                HabilitaVeredas = user.HabilitaVeredas,
                HabilitaJuicios = user.HabilitaJuicios,
                HabilitaPresentismo = user.HabilitaPresentismo,
                HabilitaSeguimientoUsuarios = user.HabilitaSeguimientoUsuarios,
                HabilitaVerObrasCerradas = user.HabilitaVerObrasCerradas,
                HabilitaElementosCalle = user.HabilitaElementosCalle,
                CONCEPTOMOVA = user.CONCEPTOMOVA,
                LimitarGrupo = user.LimitarGrupo,
                FirmaUsuario = user.FirmaUsuario,
                RUBRO = user.RUBRO,
            };
            return Ok(response);
        }
    }
}
