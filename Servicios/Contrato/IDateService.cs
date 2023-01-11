using AppContactos.Models;

namespace AppContactos.Servicios.Contrato
{
    public interface IDateService
    {
        Task<IEnumerable<ImportantDate>> GetAllDates();
        Task<ImportantDate> GetIDateDetails(int id);
        Task<bool> InsertIDate(ImportantDate iDate);
        Task<bool> UpdateIDate(ImportantDate iDate);
        Task<bool> DeleteIDate(int id);
        Task<bool> SaveIDate(ImportantDate iDate);
    }
}
