using Microsoft.EntityFrameworkCore;
using AppContactos.Models;
using AppContactos.Servicios.Contrato;

namespace AppContactos.Servicios.Implementacion
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ContactosWebContext _dbContext;

        public UsuarioService(ContactosWebContext dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuarioEncontrado = await _dbContext.Usuarios.Where(u => u.Correo == correo && u.Clave == clave).FirstOrDefaultAsync();

            return usuarioEncontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }
    }
}
