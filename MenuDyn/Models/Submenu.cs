using System;
using System.Collections.Generic;

namespace MenuDyn.Models;

public partial class Submenu
{
    public int SubmenuId { get; set; }

    public string SubmenuName { get; set; } = null!;

    public bool SubmenuActive { get; set; }

    public int FkMenuId { get; set; }

    public virtual Menu FkMenu { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
