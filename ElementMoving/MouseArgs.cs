using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementMoving
{
    public class MouseArgs
    {
        public Position Pos { get; set; }
        public bool IsLeftPressed { get; set; }
        public bool IsRightPressed { get; set; }

        public MouseArgs()
        {
            Pos = new Position { X = 0, Y = 0 };
            this.IsLeftPressed = false;
            this.IsRightPressed = false;
        }

        public MouseArgs(Position pos, bool isLeftPressed, bool isRightPressed)
        {
            Pos = pos;
            this.IsLeftPressed = isLeftPressed;
            this.IsRightPressed = isRightPressed;
        }
    }
}
