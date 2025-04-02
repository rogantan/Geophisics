using System;
using System.Collections.Generic;

namespace Geophisics.Models;

public partial class Администраторы
{
    public long Id { get; set; }

    public string Фио { get; set; } = null!;

    public string Почта { get; set; } = null!;

    public string Логин { get; set; } = null!;

    public string Пароль { get; set; } = null!;

    public virtual ICollection<Проекты> Проектыs { get; set; } = new List<Проекты>();
}
