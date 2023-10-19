using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doodle_Jump.Classes
{
    public class Enemy : Player
    {
        public Enemy(PointF position, int type)
        {
            switch (type) 
            {
                case 1:
                    sprite = Properties.Resources.Blot;
                    physics = new Physics(position, new Size(60, 40));
                    break;
                case 2:
                    sprite = Properties.Resources.BlueBlot;
                    physics = new Physics(position, new Size(60, 40));
                    break;
                case 3:
                    sprite = Properties.Resources.MonsterDragonfly;
                    physics = new Physics(position, new Size(50, 50));
                    break;
                case 4:
                    sprite = Properties.Resources.MonsterFly;
                    physics = new Physics(position, new Size(50, 25));
                    break;
                case 5:
                    sprite = Properties.Resources.MonsterOne_eyed;
                    physics = new Physics(position, new Size(40, 40));
                    break;
                case 6:
                    sprite = Properties.Resources.MonsterThree_eyed;
                    physics = new Physics(position, new Size(50, 50));
                    break;
                case 7:
                    sprite = Properties.Resources.SpiderMonster;
                    physics = new Physics(position, new Size(50, 50));
                    break;
                case 8:
                    sprite = Properties.Resources.FlateMonster;
                    physics = new Physics(position, new Size(70, 35));
                    break;
                case 9:
                    sprite = Properties.Resources.OvalMonster;
                    physics = new Physics(position, new Size(50, 50));
                    break;
                case 10:
                    sprite = Properties.Resources.ParrotMonster;
                    physics = new Physics(position, new Size(80, 50));
                    break;
                case 11:
                    sprite = Properties.Resources.BirdMonster;
                    physics = new Physics(position, new Size(70, 50));
                    break;
                case 12:
                    sprite = Properties.Resources.AwfulMonster;
                    physics = new Physics(position, new Size(50, 50));
                    break;
            }
        }
    }
}
