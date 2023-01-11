using System;
using System.Collections.Generic;

namespace AppContactos.Models;

public partial class Contact
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<UserContact> UserContacts { get; } = new List<UserContact>();
}
