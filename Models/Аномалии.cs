using System;
using System.Collections.Generic;

namespace Geophisics.Models;

public partial class Аномалии
{
    public long Id { get; set; }

    public string Название { get; set; } = null!;

    public string Описание { get; set; } = null!;

    public long IdГеофизика { get; set; }

    public virtual Геофизики IdГеофизикаNavigation { get; set; } = null!;
}
