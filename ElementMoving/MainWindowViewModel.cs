using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;
using System.Reactive;
using ReactiveUI.Fody;
using ReactiveUI.Fody.Helpers;
using System.Diagnostics;

namespace ElementMoving
{
    public class MainWindowViewModel : ReactiveObject
    {
        [Reactive] public string Title { get; set; }
        [Reactive] public Position CardTransformPosition { get; set; }
        [Reactive] public Position PressedPosition { get; set; }
        [Reactive] public bool IsPressed { get; set; }

        [Reactive] public Size WindowSize { get; set; }
        [Reactive] public Size CardSize { get; set; }

        //commands
        public ReactiveCommand<Unit, Unit> MyCommand { get; }
        public ReactiveCommand<MouseArgs, Unit> CardPressed { get; }
        public ReactiveCommand<MouseArgs, Unit> CardMove { get; }

        public MainWindowViewModel()
        {
            CardTransformPosition = new Position { X = 0, Y = 0 };
            PressedPosition = new Position { X = 0, Y = 0 };

            WindowSize = new Size(0, 0);
            CardSize = new Size(0, 0);

            Title = "Hello World!";

            MyCommand = ReactiveCommand.Create(() =>
            {
                Title = "Hello World! " + DateTime.Now;
            });

            CardPressed = ReactiveCommand.Create<MouseArgs>(args =>
            {
                PressedPosition = args.Pos;
            });

            CardMove = ReactiveCommand.Create<MouseArgs>(args =>
            {
                if (args.IsLeftPressed)
                {
                    var newX = CardTransformPosition.X + args.Pos.X - PressedPosition.X;
                    var newY = CardTransformPosition.Y + args.Pos.Y - PressedPosition.Y;

                    // 윈도우 범위를 벗어나지 않도록 X 위치 조정
                    newX = Math.Max(-(WindowSize.Width - CardSize.Width) / 2, newX); // 왼쪽 경계를 넘지 않도록
                    newX = Math.Min((WindowSize.Width - CardSize.Width) / 2, newX); // 오른쪽 경계를 넘지 않도록

                    // 윈도우 범위를 벗어나지 않도록 Y 위치 조정
                    newY = Math.Max(-(WindowSize.Height - CardSize.Height) / 2, newY); // 상단 경계를 넘지 않도록
                    newY = Math.Min((WindowSize.Height - CardSize.Height) / 2, newY); // 하단 경계를 넘지 않도록

                    CardTransformPosition.X = newX;
                    CardTransformPosition.Y = newY;
                    PressedPosition = args.Pos;

                    Debug.WriteLine(CardTransformPosition.X + " " + CardTransformPosition.Y);
                }
            });
        }
    }
}
