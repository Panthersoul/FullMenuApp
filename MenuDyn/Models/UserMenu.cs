using System;
using System.Collections.Generic;

namespace MenuDyn.Models;

public partial class UserMenu
{
    public int UsrId { get; set; }

    public string UsrName { get; set; } = null!;

    public string UsrSurname { get; set; } = null!;

    public DateTime? UsrBirthdate { get; set; }

    public string UsrAddress { get; set; } = null!;

    public string UsrTelephone { get; set; } = null!;

    public string UsrEmail { get; set; } = null!;

    public string UsrProfilePic { get; set; } = null!;

    public string UsrSuscription { get; set; } = null!;

    public string UsrRut { get; set; } = null!;

    public string UsrFairyName { get; set; } = null!;

    public string UsrEnterpriseName { get; set; } = null!;

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();
}
