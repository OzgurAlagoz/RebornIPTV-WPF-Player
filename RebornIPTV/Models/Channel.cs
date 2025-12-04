using System;
using System.Collections.Generic;
using System.Text;

namespace RebornIPTV.Models;

public class Channel
{
    public string Name { get; set; }
    public string StreamUrl { get; set; }
    public string Group { get; set; }
    public override string ToString()
    {
        return Name;
    }
}
