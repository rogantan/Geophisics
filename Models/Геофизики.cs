using System;
using System.Collections.Generic;

namespace Geophisics.Models;

public partial class Геофизики
{
    public long Id { get; set; }

    public string Фио { get; set; } = null!;

    public string Логин { get; set; } = null!;

    public string Пароль { get; set; } = null!;

    public virtual ICollection<Аномалии> Аномалииs { get; set; } = new List<Аномалии>();
}
