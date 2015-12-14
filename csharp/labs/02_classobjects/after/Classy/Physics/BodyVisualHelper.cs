using System.Windows;
using FarseerGames.FarseerPhysics.Dynamics;

namespace Classy.Physics
{
    public class BodyVisualHelper
    {
        private FrameworkElement visual;
        public FrameworkElement Visual
        {
            get { return visual; }
        }

        private Body body;
        public Body Body
        {
            get { return body; }
        }

        public BodyVisualHelper(FrameworkElement visual, Body body)
        {
            this.visual = visual;
            this.body = body;

            //update when moves/rotates or resized
            body.Updated += delegate { Update(); };
            visual.SizeChanged += delegate { Update(); };
        }

        public void Update()
        {
            PhysicsCanvas.CenterAround(visual, body.Position);
            PhysicsCanvas.SetRotation(visual, Body.Rotation);
        }
    }
}