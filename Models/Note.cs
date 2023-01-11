using System;
using System.Collections.Generic;

namespace AppContactos.Models;

public partial class Note
{
    public int Id { get; set; }

    public string? NoteContent { get; set; }

    public virtual ICollection<UserNote> UserNotes { get; } = new List<UserNote>();
}
