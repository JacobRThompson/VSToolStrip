﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VS.ToolStrip
{
    public interface IPinnable
    {
        event EventHandler? PinnedChanged;

        bool Pinned { get; set; }

    }
}