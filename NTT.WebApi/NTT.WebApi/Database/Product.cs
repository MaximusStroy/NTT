using System;
using System.Collections.Generic;

namespace NTT.WebApi.Database;

public partial class Product
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Descr { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; }
}
