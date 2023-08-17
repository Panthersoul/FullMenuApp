using System;
using System.Collections.Generic;

namespace MenuDyn.Models;

public partial class SuscriptionsType
{
    public int SuscriptionId { get; set; }

    public string SuscriptionName { get; set; } = null!;

    public int SuscriptionType { get; set; }

    public string SuscriptionPrice { get; set; } = null!;

    public string SuscriptionDescription { get; set; } = null!;

    public bool SuscriptionActive { get; set; }

    public virtual ICollection<Suscription> Suscriptions { get; set; } = new List<Suscription>();
}
