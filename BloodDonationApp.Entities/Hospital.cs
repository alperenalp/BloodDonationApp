using System;
using System.Collections.Generic;

namespace BloodDonationApp.Entities;

public partial class Hospital
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public int UserId { get; set; }

    public virtual ICollection<HospitalBlood> HospitalBloods { get; set; } = new List<HospitalBlood>();

    public virtual User User { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
