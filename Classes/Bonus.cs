using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Doodle_Jump.Classes
{
    public class Bonus
    {
        public Physics physics;
        public Image sprite;
        public int type;

        public Bonus(PointF position, int type)
        {

            switch (type)
            {
                case 1:
                    sprite = Properties.Resources.Spring;
                    physics = new Physics(position, new Size(20, 20));
                    break;
                case 2:
                    sprite = Properties.Resources.HatHelicopter;
                    physics = new Physics(position, new Size(25, 25));
                    break;
                case 3:
                    sprite = Properties.Resources.JetPac;
                    physics = new Physics(position, new Size(30, 40));
                    break;
                case 4:
                    sprite = Properties.Resources.Trampoline;
                    physics = new Physics(position, new Size(30, 20));
                    break;
            }
            this.type = type;
        }
        public void DrawSprite(Graphics g)
        {
            g.DrawImage(sprite, physics.transform.position.X, physics.transform.position.Y, physics.transform.size.Width, physics.transform.size.Height);
        }
    }
}
