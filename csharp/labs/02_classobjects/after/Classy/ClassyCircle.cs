using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Classy.Physics;

namespace Classy
{
    public class ClassyCircle : ClassyShape
    {
        public ClassyCircle(PhysicsCanvas canvas) : base(canvas)
        {
        }

        public override void Show()
        {
            _body = _canvas.CreateCircleBody(24, (int)_canvas.ActualWidth / 2, 40);
            _canvas.AddCircleToCanvas(_body, Color, 24);
        }
    }    
}
