﻿using apiServicio.Models;

namespace apiServicio.Services.Contracts
{
    public interface IUsuarioService
    {
        Task<Usuario> GetNombreUsuario(string nombreusuario);
        string CrearPasswordHash(string password, string salt);
        string GenerarToken(DateTime fechaEmision, Usuario usuario, TimeSpan tiempoExpiracion,
                                    string claveFirma, string audiencia, string emisor);
    }
}
