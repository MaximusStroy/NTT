using System;
using System.Collections.Generic;

namespace NTT.WebApi.Database;

public partial class VProdCat
{
    public int ProductId { get; set; }

    public string ProductName { get; set; }

    public string ProductDescr { get; set; }

    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public string CtegoryDescr { get; set; }
}
