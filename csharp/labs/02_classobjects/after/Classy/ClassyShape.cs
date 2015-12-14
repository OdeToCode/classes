using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;
using Classy.Physics;
using FarseerGames.FarseerPhysics.Dynamics;
using FarseerGames.FarseerPhysics.Mathematics;

namespace Classy
{
    public abstract class ClassyShape
    {
        public ClassyShape(PhysicsCanvas canvas)
        {
            _canvas = canvas;
        }

        public Color Color { get; set; }
        public abstract void Show();

        public virtual void Jump()
        {
            _body.ApplyImpulse(new Vector2(250, -1000f));
        }

        protected Body _body;
        protected PhysicsCanvas _canvas;
    }
}
