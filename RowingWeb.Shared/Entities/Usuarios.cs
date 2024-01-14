﻿using System.ComponentModel.DataAnnotations;

namespace RowingWeb.Shared.Entities
{
    public class Usuario
    {
        [Key]
        public int IDUsuario { get; set; }
        public string Login { get; set; }
        public string CodigoCausante { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int? AutorWOM { get; set; }
        public byte Estado { get; set; }
        public int? HabilitaAPP { get; set; }
        public int? HabilitaFotos { get; set; }
        public int? HabilitaReclamos { get; set; }
        public int? HabilitaSSHH { get; set; }
        public int? HabilitaRRHH { get; set; }
        public int? HabilitaMedidores { get; set; }
        public string HabilitaFlotas { get; set; }
        public int? ReHabilitaUsuarios { get; set; }
        public string Modulo { get; set; }
        public string CODIGOGRUPO { get; set; }
        public int? FechaCaduca { get; set; }
        public int? IntentosInvDiario { get; set; }
        public int? OpeAutorizo { get; set; }
        public int? HabilitaNuevoSuministro { get; set; }
        public int? HabilitaVeredas { get; set; }
        public int? HabilitaJuicios { get; set; }
        public int? HabilitaPresentismo { get; set; }
        public int? HabilitaSeguimientoUsuarios { get; set; }
        public int? HabilitaVerObrasCerradas { get; set; }
        public int? HabilitaElementosCalle { get; set; }
        public byte? CONCEPTOMOVA { get; set; }
        public int? LimitarGrupo { get; set; }
        public byte? RUBRO { get; set; }
        public string FirmaUsuario { get; set; }
        public string FirmaUsuarioImageFullPath => string.IsNullOrEmpty(FirmaUsuario)
      ? $"http://190.111.249.225/RowingAppApi/images/ObrasSuministros/noimage.png"
      : $"http://190.111.249.225/RowingAppApi{FirmaUsuario.Substring(1)}";
    }
}
