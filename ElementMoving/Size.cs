using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementMoving
{
    public class Size : ReactiveObject
    {
        [Reactive] public double Width { get; set; }
        [Reactive] public double Height { get; set; }

        public Size(double width, double height)
        {
            Width = width;
            Height = height;
        }
    }
}
