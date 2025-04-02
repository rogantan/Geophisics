using System;
using System.Collections.Generic;

namespace Geophisics.Models;

public partial class Площади
{
    public long Id { get; set; }

    public long IdПроекта { get; set; }

    public virtual Проекты IdПроектаNavigation { get; set; } = null!;

    public virtual ICollection<КоординатыПлощади> КоординатыПлощадиs { get; set; } = new List<КоординатыПлощади>();

    public virtual ICollection<Профили> Профилиs { get; set; } = new List<Профили>();
}
