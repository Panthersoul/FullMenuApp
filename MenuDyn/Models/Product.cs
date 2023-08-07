using System;
using System.Collections.Generic;

namespace MenuDyn.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string ProductPrice { get; set; } = null!;

    public string ProductDescription { get; set; } = null!;

    public string ProductPicture { get; set; } = null!;

    public string? ProductOffers { get; set; }

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
