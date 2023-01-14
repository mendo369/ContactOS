using System;
using System.Collections.Generic;

namespace AppContactos.Models;

public partial class Note
{
    public int Id { get; set; }

    public string NoteContent { get; set; } = null!;

    public int IdUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
