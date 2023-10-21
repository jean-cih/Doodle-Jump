using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doodle_Jump.Classes
{
    public class Physics
    {
        public Transform transform;
        Player player;
        float gravity;
        float a;

        public float dx;
        bool usedBonus = false;

        public Physics(PointF position, Size size)
        {
            transform = new Transform(position, size);
            gravity = 0;
            a = 0.4f;
            dx = 0;
        }



        public bool StandartCollide()
        {
            for (int i = 0; i < PlatformController.bullets.Count; i++)
            {
                var bullet = PlatformController.bullets[i];
                PointF delta = new PointF();
                delta.X = (transform.position.X + transform.size.Width / 2) - (bullet.physics.transform.position.X + bullet.physics.transform.size.Width / 2);
                delta.Y = (transform.position.Y + transform.size.Height / 2) - (bullet.physics.transform.position.Y + bullet.physics.transform.size.Height / 2);
                if (Math.Abs(delta.X) <= transform.size.Width / 2 + bullet.physics.transform.size.Width / 2)
                {
                    if (Math.Abs(delta.Y) <= transform.size.Height / 2 + bullet.physics.transform.size.Height / 2)
                    {
                        PlatformController.RemoveBullet(i);
                        return true;
                    }
                }
            }
            return false;
        }

        public void CalculatePhysics()
        {
            if (dx != 0)
            {
                transform.position.X += dx;
            }
            if (transform.position.Y < 700)
            {
                transform.position.Y += gravity;
                gravity += a;

                Collide();
            }
            if (gravity > -19 && usedBonus)
            {
                for (int i = 0; i < PlatformController.platforms.Count; i++)
                {
                    PlatformController.platforms.RemoveAt(i);
                }
                for (int i = 0; i < PlatformController.bonuses.Count; i++)
                {
                    PlatformController.bonuses.Clear();
                }
                PlatformController.startPlatformPositionY = 150;
                PlatformController.GenereteStartSequence();
                PlatformController.startPlatformPositionY = -50;
                PlatformController.GenerateRandomPlatform();

                usedBonus = false;
            }

        }
        public void ApplyPhysics()
        {
            CalculatePhysics();
        }
        public void Collide()
        {
            for (int i = 0; i < PlatformController.platforms.Count; i++)
            {
                var platform = PlatformController.platforms[i];
                if (transform.position.X + transform.size.Width / 2 >= platform.transform.position.X && transform.position.X + transform.size.Width / 2 <= platform.transform.position.X + platform.transform.size.Width)
                {
                    if (transform.position.Y + transform.size.Height >= platform.transform.position.Y && transform.position.Y + transform.size.Height <= platform.transform.position.Y + platform.transform.size.Height)
                    {
                        if (gravity > 0)
                        {
                            AddForce();
                            if (!platform.isTouchedByPlayer)
                            {
                                PlatformController.score += 20;
                                PlatformController.GenerateRandomPlatform();
                                platform.isTouchedByPlayer = true;
                            }

                        }
                    }
                }
            }
        }

        public void AddForce(int force = -10)
        {
            gravity = force;
        }
        public bool StandardCollidePlayerWithObjects(bool forMonsters, bool forBonuses)
        {
            if (forMonsters)
            {
                for (int i = 0; i < PlatformController.enemies.Count; i++)
                {
                    var enemy = PlatformController.enemies[i];
                    PointF delta = new PointF();
                    delta.X = (transform.position.X + transform.size.Width / 2) - (enemy.physics.transform.position.X + enemy.physics.transform.size.Width / 2);
                    delta.Y = (transform.position.Y + transform.size.Height / 2) - (enemy.physics.transform.position.Y + enemy.physics.transform.size.Height / 2);
                    if (Math.Abs(delta.X) <= transform.size.Width / 2 + enemy.physics.transform.size.Width / 2)
                    {
                        if (Math.Abs(delta.Y) <= transform.size.Height / 2 + enemy.physics.transform.size.Height / 2)
                        {
                            return true;
                        }
                    }
                } 
            }
            if (forBonuses)
            {
                for (int i = 0; i < PlatformController.bonuses.Count; i++)
                {
                    var bonus = PlatformController.bonuses[i];
                    PointF delta = new PointF();
                    delta.X = (transform.position.X + transform.size.Width / 2) - (bonus.physics.transform.position.X + bonus.physics.transform.size.Width / 2);
                    delta.Y = (transform.position.Y + transform.size.Height / 2) - (bonus.physics.transform.position.Y + bonus.physics.transform.size.Height / 2);
                    if (Math.Abs(delta.X) <= transform.size.Width / 2 + bonus.physics.transform.size.Width / 2)
                    {
                        if (Math.Abs(delta.Y) <= transform.size.Height / 2 + bonus.physics.transform.size.Height / 2)
                        {
                            if (bonus.type == 1 && !usedBonus)
                            {
                                usedBonus = true;
                                AddForce(-20);
                            }
                            if (bonus.type == 2 && !usedBonus)
                            {
                                usedBonus = true;

                                AddForce(-40);
                            }
                            if (bonus.type == 3 && !usedBonus)
                            {
                                usedBonus = true;
                                AddForce(-50);
                            }
                            if (bonus.type == 4 && !usedBonus)
                            {
                                usedBonus = true;
                                AddForce(-30);
                            }
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
