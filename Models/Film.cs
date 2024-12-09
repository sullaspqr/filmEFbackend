using System;
using System.Collections.Generic;

namespace filmapp.Models;

public partial class Film
{
    public int Id { get; set; }

    public string Nev { get; set; } = null!;

    public int KiadasEve { get; set; }

    public int Ertekeles { get; set; }

    public string? Kepneve { get; set; }
}
