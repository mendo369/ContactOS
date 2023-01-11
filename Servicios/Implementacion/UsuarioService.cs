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

        public async Task<User> GetUsuario(string correo, string clave)
        {
            User usuarioEncontrado = await _dbContext.Users.Where(u => u.Email == correo && u.Password == clave).FirstOrDefaultAsync();

            return usuarioEncontrado;
        }

        public async Task<User> SaveUsuario(User usuario)
        {
            _dbContext.Users.Add(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }
    }
}
