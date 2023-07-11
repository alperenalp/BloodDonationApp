using System;
using System.Collections.Generic;

namespace BloodDonationApp.Entities;

public partial class HospitalBlood
{
    public int HospitalId { get; set; }

    public int BloodId { get; set; }

    public int Quantity { get; set; }

    public int MinRequired { get; set; }

    public virtual Blood Blood { get; set; } = null!;

    public virtual Hospital Hospital { get; set; } = null!;
}
