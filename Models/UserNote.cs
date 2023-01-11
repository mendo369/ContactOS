using System;
using System.Collections.Generic;

namespace AppContactos.Models;

public partial class UserNote
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdNote { get; set; }

    public virtual Note IdNoteNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
