using Microsoft.EntityFrameworkCore;
using AppContactos.Models;

namespace AppContactos.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string correo, string clave);
        Task<Usuario> SaveUsuario(Usuario usuario);
    }
}
