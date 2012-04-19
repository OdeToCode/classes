using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Windows.Media;
using Classy.Physics;

namespace Classy
{
    public class Playground : PhysicsCanvas
    {
        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.D1:
                    CreateRectangle();
                    break;

                case Key.D2:
                    CreateCircle();
                    break;

                case Key.D3:
                    JumpShapes();
                    break;
            }

            base.OnKeyDown(e);
        }

        private void JumpShapes()
        {
            foreach(ClassyShape shape in _shapes)
            {
                shape.Jump();
            }
        }

        private void CreateRectangle()
        {
            ClassyRectangle rectangle = new ClassyRectangle(this);
            rectangle.Color = Colors.Green;
            _shapes.Add(rectangle);
            rectangle.Show();
        }

        private void CreateCircle()
        {
            ClassyCircle circle = new ClassyCircle(this);
            circle.Color = Colors.Red;
            _shapes.Add(circle);
            circle.Show();
        }

        private List<ClassyShape> _shapes = new List<ClassyShape>();
    }
}