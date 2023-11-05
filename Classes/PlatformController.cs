using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Doodle_Jump.Classes
{
    public class PlatformController
    {
        public static int typeOperation;
        public static List<Platform> platforms;
        public static List<Bullet> bullets = new List<Bullet>();
        public static List<Enemy> enemies = new List<Enemy>();
        public static List<Bonus> bonuses = new List<Bonus>();
        public static int startPlatformPositionY = 400;
        public static int score = 0;

        public static void AddPlatform(PointF position)
        {
            Platform platform = new Platform(position);
            platforms.Add(platform);
        }

        public static void CreateBullet(PointF position)
        {
            var bullet = new Bullet(position);
            bullets.Add(bullet);
        }

        public static void GenereteStartSequence()
        {
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
            {
                int x = rand.Next(0, 270);
                int y = rand.Next(50, 60);
                startPlatformPositionY -= y;
                PointF position = new PointF(x, startPlatformPositionY);
                Platform platform = new Platform(position);
                platforms.Add(platform);
            }
        }

        public static void GenerateRandomPlatform()
        {
            ClearPlatform();
            Random rand = new Random();
            int x = rand.Next(0, 270);
            PointF position = new PointF(x, startPlatformPositionY);
            Platform platform = new Platform(position);
            platforms.Add(platform);

            var c = rand.Next(1, 3);
            switch (c)
            {
                case 1:
                    c = rand.Next(1, 10);
                    if(c == 1)
                    {
                        CreateEnemy(platform);
                    }
                    break;
                case 2:
                    c = rand.Next(1, 10);
                    if (c == 1)
                    {
                        CreateBonus(platform);
                    }
                    break;
            }

        }

        public static void CreateBonus(Platform platform)
        {
            Random rand = new Random();
            var bonusType = rand.Next(1, 5);
    
            switch (bonusType)
            {
                case 1:
                    var spring = new Bonus(new PointF(platform.transform.position.X + platform.sizeX / 2 - 8, platform.transform.position.Y - 15), bonusType);
                    bonuses.Add(spring);
                    break;
                case 2:
                    var hatHelicopter = new Bonus(new PointF(platform.transform.position.X + platform.sizeX / 2 - 10, platform.transform.position.Y - 15), bonusType);
                    bonuses.Add(hatHelicopter);
                    break;
                case 3:
                    var jetPac = new Bonus(new PointF(platform.transform.position.X + platform.sizeX / 2 - 12, platform.transform.position.Y - 35), bonusType);
                    bonuses.Add(jetPac);
                    break;
                case 4:
                    var trampoline = new Bonus(new PointF(platform.transform.position.X + platform.sizeX / 2 - 12, platform.transform.position.Y - 12), bonusType);
                    bonuses.Add(trampoline);
                    break;
            }
        }

        public static void CreateEnemy(Platform platform)
        {
            Random rand = new Random();
            var enemyType = rand.Next(1, 13);

                switch (enemyType)
                {
                    case 1:
                        var enemy1 = new Enemy(new PointF(platform.transform.position.X + (platform.sizeX / 2) / 3 - 8, platform.transform.position.Y - 37), enemyType);
                        enemies.Add(enemy1);
                        break;
                    case 2:
                        var enemy2 = new Enemy(new PointF(platform.transform.position.X + (platform.sizeX / 2) / 3 - 8, platform.transform.position.Y - 37), enemyType);
                        enemies.Add(enemy2);
                        break;
                    case 3:
                        var enemy3 = new Enemy(new PointF(platform.transform.position.X + (platform.sizeX / 2) / 3 - 3, platform.transform.position.Y - 55), enemyType);
                        enemies.Add(enemy3);
                        break;
                    case 4:
                        var enemy4 = new Enemy(new PointF(platform.transform.position.X, platform.transform.position.Y - 100), enemyType);
                        enemies.Add(enemy4);
                        break;
                    case 5:
                        var enemy5 = new Enemy(new PointF(platform.transform.position.X + (platform.sizeX / 2) / 3, platform.transform.position.Y - 38), enemyType);
                        enemies.Add(enemy5);
                        break;
                    case 6:
                        var enemy6 = new Enemy(new PointF(platform.transform.position.X + (platform.sizeX / 2) / 3 - 6, platform.transform.position.Y - 45), enemyType);
                        enemies.Add(enemy6);
                        break;
                    case 7:
                        var enemy7 = new Enemy(new PointF(platform.transform.position.X + (platform.sizeX / 2) / 3 - 6, platform.transform.position.Y - 45), enemyType);
                        enemies.Add(enemy7);
                        break;
                    case 8:
                        var enemy8 = new Enemy(new PointF(platform.transform.position.X + (platform.sizeX / 2) / 3 - 6, platform.transform.position.Y - 35), enemyType);
                        enemies.Add(enemy8);
                        break;
                    case 9:
                        var enemy9 = new Enemy(new PointF(platform.transform.position.X, platform.transform.position.Y - 100), enemyType);
                        enemies.Add(enemy9);
                        break;
                    case 10:
                        var enemy10 = new Enemy(new PointF(platform.transform.position.X + (platform.sizeX / 2) / 3 - 6, platform.transform.position.Y - 100), enemyType);
                        enemies.Add(enemy10);
                        break;
                    case 11:
                        var enemy11 = new Enemy(new PointF(platform.transform.position.X + (platform.sizeX / 2) / 3 - 6, platform.transform.position.Y - 100), enemyType);
                        enemies.Add(enemy11);
                        break;
                    case 12:
                        var enemy12 = new Enemy(new PointF(platform.transform.position.X + (platform.sizeX / 2) / 3 - 6, platform.transform.position.Y - 50), enemyType);
                        enemies.Add(enemy12);
                        break;

            }
            
        }
        public static void RemoveEnemy(int i)
        {
            enemies.RemoveAt(i);
        }

        public static void RemoveBullet(int i)
        {
            bullets.RemoveAt(i);
        }


        public static void ClearPlatform()
        {
            for (int i = 0; i < platforms.Count; i++)
            {
                if (platforms[i].transform.position.Y >= 700)
                {
                    platforms.RemoveAt(i);
                }
            }
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].physics.transform.position.Y >= 700)
                {
                    enemies.RemoveAt(i);
                }
            }
            for (int i = 0; i < bonuses.Count; i++)
            {
                if (bonuses[i].physics.transform.position.Y >= 700)
                {
                    bonuses.RemoveAt(i);
                }
            }

        }
    }
}
