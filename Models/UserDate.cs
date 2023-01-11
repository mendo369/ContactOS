using System;
using System.Collections.Generic;

namespace AppContactos.Models;

public partial class UserDate
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdDate { get; set; }

    public virtual ImportantDate IdDateNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
