using System;
using System.Collections.Generic;

namespace Geophisics.Models;

public partial class Профили
{
    public long Id { get; set; }

    public string Направление { get; set; } = null!;

    public long IdПлощади { get; set; }

    public int Длина { get; set; }

    public virtual Площади IdПлощадиNavigation { get; set; } = null!;

    public virtual ICollection<Измерения> Измеренияs { get; set; } = new List<Измерения>();

    public virtual ICollection<КоординатыПрофиля> КоординатыПрофиляs { get; set; } = new List<КоординатыПрофиля>();
}
