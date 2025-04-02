using System;
using System.Collections.Generic;

namespace Geophisics.Models;

public partial class Проекты
{
    public long Id { get; set; }

    public string Название { get; set; } = null!;

    public string Описание { get; set; } = null!;

    public DateOnly ДатаНачала { get; set; }

    public DateOnly ДатаОкончания { get; set; }

    public long IdАдминистратора { get; set; }

    public long IdЗаказчика { get; set; }

    public virtual Администраторы IdАдминистратораNavigation { get; set; } = null!;

    public virtual Заказчики IdЗаказчикаNavigation { get; set; } = null!;

    public virtual ICollection<Площади> Площадиs { get; set; } = new List<Площади>();
}
