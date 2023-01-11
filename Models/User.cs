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

    public virtual ICollection<UserContact> UserContacts { get; } = new List<UserContact>();

    public virtual ICollection<UserDate> UserDates { get; } = new List<UserDate>();

    public virtual ICollection<UserNote> UserNotes { get; } = new List<UserNote>();
}
