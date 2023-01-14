using System;
using System.Collections.Generic;

namespace AppContactos.Models;

public partial class UserContact
{
    public int Id { get; set; }

    public int IdUser { get; set; }

    public int IdContact { get; set; }
}
