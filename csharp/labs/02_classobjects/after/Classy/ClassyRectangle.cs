using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Classy.Physics;
using FarseerGames.FarseerPhysics.Mathematics;

namespace Classy
{
    public class ClassyRectangle : ClassyShape 
    {
        public ClassyRectangle(PhysicsCanvas canvas)
            : base(canvas)
        {
        }

        public override void Jump()
        {
            _body.ApplyImpulse(new Vector2(-250, -1000f));
        }

        public override void Show()
        {
            _body = _canvas.CreateRectangleBody(16, 32, (int)_canvas.ActualWidth / 2, 40);
            _canvas.AddRectangleToCanvas(_body, Color, new Vector2(16, 32));
        }
    }
}
