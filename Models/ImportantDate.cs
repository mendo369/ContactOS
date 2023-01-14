using System;
using System.Collections.Generic;

namespace AppContactos.Models;

public partial class ImportantDate
{
    public int Id { get; set; }

    public string Month { get; set; } = null!;

    public int Day { get; set; }

    public string? Description { get; set; }

    public int IdUser { get; set; }

    public virtual User IdUserNavigation { get; set; } = null!;
}
