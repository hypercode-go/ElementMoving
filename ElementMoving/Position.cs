using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementMoving
{
    public class Position : ReactiveObject
    {
        [Reactive] public double X { get; set; }
        [Reactive] public double Y { get; set; }
    }
}
