using System;
using System.Collections.Generic;

namespace Geophisics.Models;

public partial class КоординатыПрофиля
{
    public long Id { get; set; }

    public decimal X { get; set; }

    public decimal Y { get; set; }

    public long IdПрофиля { get; set; }

    public virtual Профили IdПрофиляNavigation { get; set; } = null!;
}
