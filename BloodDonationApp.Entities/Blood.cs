using System;
using System.Collections.Generic;

namespace BloodDonationApp.Entities;

public partial class Blood
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<HospitalBlood> HospitalBloods { get; set; } = new List<HospitalBlood>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
