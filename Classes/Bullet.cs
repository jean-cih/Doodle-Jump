using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doodle_Jump.Classes
{
    public class Bullet
    {
        public Physics physics;
        public Image sprite;

        public Bullet(PointF position)
        {
            sprite = Properties.Resources.Bullet;
            physics = new Physics(position, new Size(10, 10));
        }

        public void MoveUp(int speed = 25)
        {
            physics.transform.position.Y -= speed;
        }
        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
        }
    }
}
