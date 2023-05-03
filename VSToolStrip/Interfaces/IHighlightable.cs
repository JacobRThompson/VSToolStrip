using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI
{
    public interface IHighlightable
    {

        public event EventHandler HighlightedChanged;

        
        public bool Highlighted { get; set; }

        public Color ForeColor { get; set; }

        public Color BackColor { get; set; }

    }

    public static class IHighlightableExtensions
    {
        public static Color GetForeColor(this IHighlightable obj) => obj.Highlighted ? SystemColors.HighlightText.ToAlpha(obj.ForeColor.A) : obj.ForeColor;

        public static Color GetBackColor(this IHighlightable obj) => obj.Highlighted ? SystemColors.Highlight.ToAlpha(obj.BackColor.A) : obj.BackColor;

    }
}
