using Microsoft.EntityFrameworkCore;
using AppContactos.Models;

namespace AppContactos.Servicios.Contrato
{
    public interface IUsuarioService
    {
        Task<User> GetUsuario(string correo, string clave);
        Task<User> SaveUsuario(User usuario);
    }
}
