using System;
using System.Collections.Generic;

namespace BloodDonationApp.Entities;

public partial class HospitalBlood
{
    public int BloodId { get; set; }

    public int HospitalId { get; set; }

    public int Quantity { get; set; }

    public virtual Blood Blood { get; set; } = null!;

    public virtual Hospital Hospital { get; set; } = null!;
}
