using AppContactos.Models;

namespace AppContactos.Servicios.Contrato
{
    public interface INoteService
    {
        Task<IEnumerable<Note>> GetAllNotes();
        Task<Note> GetNoteDetails(int id);
        Task<bool> InsertNote(Note note);
        Task<bool> UpdateNote(Note note);
        Task<bool> DeleteNote(int id);
        Task<bool> SaveNote(Note note);
    }
}
