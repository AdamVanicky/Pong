using System;
using System.Collections.Generic;
using System.IO;
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
        public List<int> TopScores = new List<int> ();
        LeaderBoard lb = new LeaderBoard();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void butSetup_Click(object sender, RoutedEventArgs e)
        {
            lb.SetLeaderboard(TopScores.ToArray(), rtbLeaderboard);
            timer.Stop();
            DrawingSetup ds = new DrawingSetup();
            ds.SetUp(linMid, recBall, recRacketPlayer, recRacketAI);
        }
        private void butStart_Click(object sender, RoutedEventArgs e)
        {
            tbScore.Text = "00";
            timer = new DispatcherTimer();
            switch (cbDifficulty.Text)
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

        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            double d = Canvas.GetTop(recRacketPlayer);
            if (e.Key == Key.Up) { if(d > 0) { Canvas.SetTop(recRacketPlayer, d - 20); }  }
            else { if (d < panGame.Height - 60) Canvas.SetTop(recRacketPlayer, d + 20); }
        }
        DrawingSetup gn = new DrawingSetup();
        
        void timer_Tick(object sender, EventArgs e)
        {
            
            lb.SetLeaderboard(TopScores.ToArray(),rtbLeaderboard);
            gn.GameTick(panGame, recBall, recRacketPlayer, recRacketAI, timer, linMid, tbScore,TopScores);

        }

        

        private void GameClose(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FileStream fs = new FileStream("Scores.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            sw.Write($"{TopScores[0]}*{TopScores[1]}*{TopScores[2]}*{TopScores[3]}*{TopScores[4]}*{TopScores[5]}*{TopScores[6]}*{TopScores[7]}*{TopScores[8]}*{TopScores[9]}");
            sw.Close();
            fs.Close();
        }

        private void GameLoad(object sender, RoutedEventArgs e)
        {
            #region MyIdea
            //if (File.Exists("Scores.txt"))
            //{
            //    FileStream fs = new FileStream("Scores.txt", FileMode.OpenOrCreate);
            //    StreamReader sr = new StreamReader(fs);
            //    string s = sr.ReadToEnd();
            //    string[] Pole = s.Split('*');
            //    int[] P = new int[Pole.Length];
            //    for (int j = 0; j < Pole.Length; j++)
            //    {
            //        P[j] = Convert.ToInt32(Pole[j]);
            //    }
            //    for (int i = 0; i < P.Length; i++)
            //    {
            //        TopScores.Add(P[i]);
            //    }
            //    TopScores.Sort();
            //    TopScores.Reverse();
            //    SetLeaderboard(P);
            //    sr.Close();
            //    fs.Close();
            //}
            //else
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        TopScores.Add(0);
            //    }
            //    SetLeaderboard(TopScores.ToArray());
            //}
            #endregion

            TopScores = lb.FillLeaderBoard("Scores.txt");
            lb.SetLeaderboard(TopScores.ToArray(),rtbLeaderboard);
        }

        
    }
}
