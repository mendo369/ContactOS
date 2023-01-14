using System;
using System.Collections.Generic;

namespace AppContactos.Models;

public partial class User
{
    public int Id { get; set; }

    public string? UserName { get; set; }

    public string? Email { get; set; }

    public int? Phone { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Contact> Contacts { get; } = new List<Contact>();

    public virtual ICollection<ImportantDate> ImportantDates { get; } = new List<ImportantDate>();

    public virtual ICollection<Note> Notes { get; } = new List<Note>();
}
