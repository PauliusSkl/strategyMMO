﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models.Strategy
{
    public interface IEffectStrategy
    {
        void ApplyEffect(Unit unit);
        string GetName();
    }

}
