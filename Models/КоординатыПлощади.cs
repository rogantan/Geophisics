using System;
using System.Collections.Generic;

namespace Geophisics.Models;

public partial class КоординатыПлощади
{
    public long Id { get; set; }

    public decimal X { get; set; }

    public decimal Y { get; set; }

    public long IdПлощади { get; set; }

    public virtual Площади IdПлощадиNavigation { get; set; } = null!;
}
