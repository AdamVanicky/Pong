using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Pong
{
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void butSetup_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            DrawingSetup ds = new DrawingSetup();
            ds.SetUp(linMid, recBall, recRacketPlayer, recRacketAI);
        }
        public int Score;
        private void butStart_Click(object sender, RoutedEventArgs e)
        {
            Score=0;
            tbScore.Text = "00";
            timer = new DispatcherTimer();
            switch(cbDifficulty.Text)
            {
                case "Lehká":
                    timer.Interval = TimeSpan.FromMilliseconds(300);
                    break;
                case "Střední":
                    timer.Interval = TimeSpan.FromMilliseconds(250);
                    break;
                case "Těžká":
                    timer.Interval = TimeSpan.FromMilliseconds(125);
                    break;
            }
            
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void Hra_Pong___Vanický_KeyUp(object sender, KeyEventArgs e)
        {
            double d = Canvas.GetTop(recRacketPlayer);
            if (e.Key == Key.Up) { if(d > 0) { Canvas.SetTop(recRacketPlayer, d - 20); }  }
            else { if (d < panGame.Height - 60) Canvas.SetTop(recRacketPlayer, d + 20); }
        }
        DrawingSetup gn = new DrawingSetup();
        
        void timer_Tick(object sender, EventArgs e)
        {
            gn.GameTick(panGame, recBall, recRacketPlayer, recRacketAI,timer,linMid,tbScore);
        }
    }
}
