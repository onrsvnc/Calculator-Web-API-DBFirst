using System;
using System.Collections.Generic;

namespace Calc.Models;

public partial class CalculationHistory
{
    public int CalculationId { get; set; }

    public decimal A { get; set; }

    public decimal B { get; set; }

    public decimal Result { get; set; }

    public string? Operation { get; set; }
}
