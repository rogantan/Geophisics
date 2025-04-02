using System;
using System.Collections.Generic;

namespace Geophisics.Models;

public partial class Измерения
{
    public long Id { get; set; }

    public DateOnly Дата { get; set; }

    public long IdОборудования { get; set; }

    public long IdИсследователя { get; set; }

    public long IdПрофиля { get; set; }

    public decimal X { get; set; }

    public decimal Y { get; set; }

    public float Значение { get; set; }

    public virtual Исследователи IdИсследователяNavigation { get; set; } = null!;

    public virtual Оборудования IdОборудованияNavigation { get; set; } = null!;

    public virtual Профили IdПрофиляNavigation { get; set; } = null!;
}
