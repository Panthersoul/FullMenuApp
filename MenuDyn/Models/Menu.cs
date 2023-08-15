using System;
using System.Collections.Generic;

namespace MenuDyn.Models;

public partial class Menu
{
    public int MenuId { get; set; }

    public bool MenuActive { get; set; }

    public string MenuLogo { get; set; } = null!;

    public string MenuBarName { get; set; } = null!;

    public string MenuAddress { get; set; } = null!;

    public string MenuTelephone { get; set; } = null!;

    public string MenuEmail { get; set; } = null!;

    public string MenuSocial { get; set; } = null!;

    public string? MenuObs { get; set; }

    public int FkMenuUser { get; set; }

    public virtual UserMenu FkMenuUserNavigation { get; set; } = null!;

    public virtual ICollection<Submenu> Submenus { get; set; } = new List<Submenu>();
}
