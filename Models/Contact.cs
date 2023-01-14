using System;
using System.Collections.Generic;

namespace AppContactos.Models;

public partial class Contact
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public int IdUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
