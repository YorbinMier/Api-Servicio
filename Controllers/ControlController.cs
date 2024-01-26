using apiServicio.Models;
using apiServicio.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace apiServicio.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ControlController : ControllerBase
    {
        private readonly IConfiguration _configuration; 
        private readonly IUsuarioService _IUsuarioService;

        public ControlController(IConfiguration configuration, IUsuarioService UsuarioService)
        {
            _IUsuarioService = UsuarioService;
            _configuration = configuration;
        }
        [HttpPost("CrearToken")]
        public async Task<TokenModelo> PostToken(string login, string password) 
        { 
            TokenModelo token = new TokenModelo();

            try 
            {
                var usuario = await _IUsuarioService.GetNombreUsuario(login);
                if (usuario != null) 
                {
                    var hashedPassword = _IUsuarioService.CrearPasswordHash(password, usuario.Salt);
                    if(hashedPassword == usuario.Clave) 
                    {
                        var currentDate = DateTime.UtcNow;
                        var expirationTime = TimeSpan.FromMinutes(10);
                        var expireDateTime = currentDate.Add(expirationTime);
                        var authSettings = _configuration.GetSection("AuthentificationSettings");
                        string issuer = authSettings["Issuer"];
                        string audience = authSettings["Audence"];
                        string signingKey = authSettings["SigningKey"];
                        token.token = _IUsuarioService.GenerarToken(currentDate, usuario, expirationTime,
                                        signingKey, audience, issuer); token.tiempoExpira = expireDateTime;
                    }
                    else 
                    { 
                    
                    }
                }
                else 
                { 
                
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine($"Error en la generacion del token:{ex.Message}");
            }
            return token;
        }

    }
}
