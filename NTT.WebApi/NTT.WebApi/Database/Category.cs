using System;
using System.Collections.Generic;

namespace NTT.WebApi.Database;

public partial class Category
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Descr { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
