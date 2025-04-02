using System;
using System.Collections.Generic;

namespace Geophisics.Models;

public partial class Оборудования
{
    public long Id { get; set; }

    public string Название { get; set; } = null!;

    public DateOnly ДатаКалибровки { get; set; }

    public virtual ICollection<Измерения> Измеренияs { get; set; } = new List<Измерения>();
}
