using AppContactos.Models;
using AppContactos.Servicios.Contrato;
using Microsoft.EntityFrameworkCore;

namespace AppContactos.Servicios.Implementacion
{
    public class NoteService : INoteService
    {
        private readonly ContactosWebContext _dbContext;

        public NoteService(ContactosWebContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteNote(int id)
        {
            //_context es la representacion de la base de datos y Books es la representacion de la tabla de libros
            var note = await _dbContext.Notes.FindAsync(id);
            _dbContext.Notes.Remove(note);
            //SaveChanges nos devuelve al igual que sqlServer, la cantidad de columas afectadas
            //por esto si no afecta ninguna columna pues se devolverá 0
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Note>> GetAllNotes()
        {
            return await _dbContext.Notes.ToListAsync();
        }

        public async Task<Note> GetNoteDetails(int id)
        {
            return await _dbContext.Notes.FindAsync(id);
        }

        public async Task<bool> InsertNote(Note note)
        {
            _dbContext.Notes.Add(note);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<bool> SaveNote(Note note)
        {
            if (note.Id > 0)
            {
                return await UpdateNote(note);
            }
            else
            {
                return await InsertNote(note);
            }
        }

        public async Task<bool> UpdateNote(Note note)
        {
            _dbContext.Entry(note).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}
