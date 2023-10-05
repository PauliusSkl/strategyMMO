﻿namespace Shared.Models;
public class Unit
{
    
    public int Health { get; set; }

    public int MaxHealth { get; set; }

    public int Attack { get; set; }

    public int Range { get; set; }

    public int X { get; set; }

    public int Y { get; set; }

    public int Speed { get; set; }

    public bool speedRaised { get; set; } = false;

    public bool attackRaised { get; set; } = false;
    public bool Upgraded { get; set; } = false;
    public string Color { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public int Kills { get; set; }


}
