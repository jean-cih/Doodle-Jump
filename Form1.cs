using Doodle_Jump.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Doodle_Jump
{
    public partial class Form1 : Form
    {
        public Player player;
        public Timer timer1;
        public Transform transform;
        float gravity;
        float a;

        public float dx;
        bool userHelicopter = false;
        bool userJetPac = false;

        public Form1()
        {

            InitializeComponent();

            this.BackgroundImage = Properties.Resources.frontPastelSky6001;
            buttonStart.Visible = true;
            buttonControl.Visible = true;
            labelScore.Visible = false;
            buttonExit.Visible = false;
            buttonRestart.Visible = false;
            labelLose.Visible = false;
            labelWin.Visible = false;
            KeyPreview = true;


            //Системные звуки
            //SoundPlayer simpleSound = new SoundPlayer(@"C:\Windows\Media\Alarm01.wav");
            //simpleSound.Play();

        }
        public void Init()
        {
            PlatformController.platforms = new System.Collections.Generic.List<Platform>();
            PlatformController.AddPlatform(new System.Drawing.PointF(100, 400));
            PlatformController.startPlatformPositionY = 400;
            PlatformController.score = 0;
            PlatformController.GenereteStartSequence();
            PlatformController.bullets.Clear();
            PlatformController.enemies.Clear();
            PlatformController.bonuses.Clear();
            player = new Player();
        }

        private void OnKeyboardUp(object sender, KeyEventArgs e)
        {
            player.physics.dx = 0;

            if (userHelicopter)
            {
                player.sprite = Properties.Resources.DoodleHelicopter;
            }
            else if (userJetPac)
            {
                player.sprite = Properties.Resources.DoodleJetPac;
            }
            else
            {
                player.sprite = Properties.Resources.DoodleLeft;
            }

            if (player.physics.transform.position.Y <= PlatformController.platforms[0].transform.position.Y - 900)
            {
                userHelicopter = false;
            }
            if (player.physics.transform.position.Y <= PlatformController.platforms[0].transform.position.Y - 2000)
            {
                userJetPac = false;
            }

            switch (e.KeyCode)
            {
                case Keys.Up:
                    PlatformController.CreateBullet(new PointF(player.physics.transform.position.X + player.physics.transform.size.Width / 2, player.physics.transform.position.Y));
                    break;
            }
        }

        private void OnKeyboardPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Right:
                    player.sprite = Properties.Resources.DoodleRight;           
                    player.physics.dx = 6;
                    break;
                case Keys.Left:
                    player.sprite = Properties.Resources.DoodleLeft;   
                    player.physics.dx = -6;
                    break;
                case Keys.Up:
                    player.sprite = Properties.Resources.DoodleShot;
                    break;
            }

            if (player.physics.transform.position.X < -10)
            {
                player.physics.transform.position.Y -= 10;
                player.physics.transform.position.X = 305;
            }
            if (player.physics.transform.position.X > 310)
            {
                player.physics.transform.position.Y -= 10;
                player.physics.transform.position.X = 0;
            }
        }

        private void Update(object sender, EventArgs e) 
        {
            this.Text = "Score: " + PlatformController.score + "/10000";

            if(PlatformController.score >= 10000)
            {
                labelWin.Visible = true;
                buttonRestart.Visible = true;
                buttonRestart.Text = "Play";
                PlatformController.bullets.Clear();
            }


            if ((player.physics.transform.position.Y >= PlatformController.platforms[0].transform.position.Y + 300) || player.physics.StandardCollidePlayerWithObjects(true, false)) 
            {
                buttonRestart.Text = "Play again";
                labelLose.Visible = true;
                labelScore.Visible = true;
                buttonRestart.Visible = true;
                labelScore.Text = "Score: " + PlatformController.score;
                PlatformController.bullets.Clear();

            }
            player.physics.StandardCollidePlayerWithObjects(false, true);

            if (PlatformController.bullets.Count > 0)
            {
                for (int i = 0; i < PlatformController.bullets.Count; i++)
                {
                    if (Math.Abs(PlatformController.bullets[i].physics.transform.position.Y - player.physics.transform.position.Y) > 500)
                    {
                        PlatformController.RemoveBullet(i);
                        continue;
                    }
                    PlatformController.bullets[i].MoveUp();
                }
            }
            if (PlatformController.enemies.Count > 0)
            {
                for (int i = 0; i < PlatformController.enemies.Count; i++)
                {
                    if (PlatformController.enemies[i].physics.StandartCollide())
                    {
                        PlatformController.score += 50;
                        this.Text = "Doodle Jump: Score - " + PlatformController.score;
                        PlatformController.RemoveEnemy(i);
                        break;
                    }
                }
                for (int i = 0; i < PlatformController.bonuses.Count; i++)
                {
                    var bonus = PlatformController.bonuses[i];
                    PointF deltas = new PointF();
                    deltas.X = (player.physics.transform.position.X + player.physics.transform.size.Width / 2) - (bonus.physics.transform.position.X + bonus.physics.transform.size.Width / 2);
                    deltas.Y = (player.physics.transform.position.Y + player.physics.transform.size.Height / 2) - (bonus.physics.transform.position.Y + bonus.physics.transform.size.Height / 2);
                    if (Math.Abs(deltas.X) <= player.physics.transform.size.Width / 2 + bonus.physics.transform.size.Width / 2)
                    {
                        if (Math.Abs(deltas.Y) <= player.physics.transform.size.Height / 2 + bonus.physics.transform.size.Height / 2)
                        {
                            userHelicopter = false;
                            userJetPac = false;
                            for (int j = 0; j < PlatformController.enemies.Count; j++)
                            {
                                PlatformController.enemies.Clear();
                            }
                        }
                    }
                }
            }
            if(PlatformController.bonuses.Count > 0)
            {
                for (int i = 0; i < PlatformController.bonuses.Count; i++)
                {
                    var bonus = PlatformController.bonuses[i];
                    PointF deltas = new PointF();
                    deltas.X = (player.physics.transform.position.X + player.physics.transform.size.Width / 2) - (bonus.physics.transform.position.X + bonus.physics.transform.size.Width / 2);
                    deltas.Y = (player.physics.transform.position.Y + player.physics.transform.size.Height/ 2) - (bonus.physics.transform.position.Y + bonus.physics.transform.size.Height / 2);
                    if (Math.Abs(deltas.X) <= player.physics.transform.size.Width / 2 + bonus.physics.transform.size.Width / 2)
                    {
                        if (Math.Abs(deltas.Y) <= player.physics.transform.size.Height / 2 + bonus.physics.transform.size.Height / 2)
                        {
                            if (bonus.type == 1)
                            {
                                PlatformController.score += 100;
                                this.Text = "Doodle Jump: Score - " + PlatformController.score;
                            }
                            if (bonus.type == 2)
                            {
                                PlatformController.score += 300;
                                userHelicopter = true;
                                player.sprite = Properties.Resources.DoodleHelicopter;
                                this.Text = "Doodle Jump: Score - " + PlatformController.score;
                            }
                            if (bonus.type == 3)
                            {
                                PlatformController.score += 400;
                                userJetPac = true;
                                player.sprite = Properties.Resources.DoodleJetPac;
                                this.Text = "Doodle Jump: Score - " + PlatformController.score;
                            }
                            if (bonus.type == 4)
                            {
                                PlatformController.score += 200;
                                this.Text = "Doodle Jump: Score - " + PlatformController.score;
                            }
                           
                        }
                    }
                    
                }
            }

            player.physics.ApplyPhysics();
            FollowPlayer();

            Invalidate();
        }

        public void FollowPlayer()
        {
            int offset = 400 - (int)player.physics.transform.position.Y;
            player.physics.transform.position.Y += offset;

            for(int i = 0; i < PlatformController.platforms.Count; i++)
            {
                var platform = PlatformController.platforms[i];
                platform.transform.position.Y += offset;
            }
            for (int i = 0; i < PlatformController.bullets.Count; i++)
            {
                var bullet = PlatformController.bullets[i];
                bullet.physics.transform.position.Y += offset;
            }
            for (int i = 0; i < PlatformController.enemies.Count; i++)
            {
                var enemy = PlatformController.enemies[i];
                enemy.physics.transform.position.Y += offset;
            }
            for (int i = 0; i < PlatformController.bonuses.Count; i++)
            {
                var bonus = PlatformController.bonuses[i];
                bonus.physics.transform.position.Y += offset;
            }
        }

        private void OnRepaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if(PlatformController.platforms.Count > 0)
            {
                for (int i = 0; i < PlatformController.platforms.Count; i++)
                {
                    PlatformController.platforms[i].DrawSprite(g);
                }
            }
            if (PlatformController.bullets.Count > 0)
            {
                for (int i = 0; i < PlatformController.bullets.Count; i++)
                {
                    PlatformController.bullets[i].DrawSprite(g);
                }
            }
            if (PlatformController.enemies.Count > 0)
            {
                for (int i = 0; i < PlatformController.enemies.Count; i++)
                {
                    PlatformController.enemies[i].DrawSprite(g);
                }
            }
            if (PlatformController.bonuses.Count > 0)
            {
                for (int i = 0; i < PlatformController.bonuses.Count; i++)
                {
                    PlatformController.bonuses[i].DrawSprite(g);
                }
            }
            player.DrawSprite(g);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {    
            Init();
            timer1 = new Timer();
            timer1.Interval = 15;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
            this.KeyDown += new KeyEventHandler(OnKeyboardPressed);
            this.KeyUp += new KeyEventHandler(OnKeyboardUp);
            this.BackgroundImage = Properties.Resources.PastelSky600;
            this.Height = 600;
            this.Width = 350;
            this.Paint += new PaintEventHandler(OnRepaint);
            buttonStart.Visible = false;
            buttonControl.Visible = false;
        }

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            buttonRestart.Visible = false;
            labelLose.Visible = false;
            labelScore.Visible = false;
            labelWin.Visible = false;
            Init();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            this.BackgroundImage = Properties.Resources.SettingsBack;
            buttonStart.Visible = false;
            buttonControl.Visible = false;
            buttonExit.Visible = true;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            buttonStart.Visible = true;
            buttonControl.Visible = true;
            buttonExit.Visible = false;
            this.BackgroundImage = Properties.Resources.frontPastelSky6001;
        }
    }
}
