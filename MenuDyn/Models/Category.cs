using System;
using System.Collections.Generic;

namespace MenuDyn.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public virtual ICollection<Submenu> Submenus { get; set; } = new List<Submenu>();
}
