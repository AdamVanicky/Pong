using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    public class DrawingSetup
    {
       
        public void SetUp(Line linMid, Rectangle recBall, Rectangle recRacketPlayer, Rectangle recRacketAI)
        {
          
            linMid.X1 = 310;
            linMid.Y1 = 0;
            linMid.X2 = 310;
            linMid.Y2 = 380;
            SolidColorBrush scb = new SolidColorBrush();
            scb.Color = Colors.White;
            linMid.Fill = scb;


            scb.Color = Colors.Red;
            recBall.Fill = scb;
            Canvas.SetTop(recBall, 200);
            Canvas.SetLeft(recBall, 300);


            Canvas.SetTop(recRacketPlayer, 180);
            Canvas.SetLeft(recRacketPlayer, 0);

            Canvas.SetTop(recRacketAI, 180);
            Canvas.SetLeft(recRacketAI, 580);
        }
        public int Score = 0;
        public bool Start = true;
        public double X=20, Y=-20;
        public double LastX, LastY;

        
        public void GameTick(Panel panGame, Rectangle recBall, Rectangle recRacketPlayer, Rectangle recRacketAI, DispatcherTimer timer, Line linMid,TextBlock tbScore, List<int> liTopScores)
        { 
            if(Start == true) { Score = 0; Start = false; }
            LastX = Canvas.GetLeft(recBall);
            LastY = Canvas.GetTop(recBall);
            
            if (Canvas.GetTop(recBall) <= 0 || Canvas.GetTop(recBall) >= panGame.Height - 20)
            {
                Y *= -1;
                
            }

            if (Canvas.GetLeft(recBall) == panGame.Width - 20) { LastX = 300; LastY = 200; tbScore.Text = Convert.ToString(++Score); }

            if (Canvas.GetLeft(recBall) == 0) { LastX = 300 - X; LastY = 200 - Y; timer.Stop(); MessageBox.Show("Konec hry"); Start = true;
                int i = liTopScores.Count - 1;
                liTopScores[i] = Score;
                liTopScores.Sort();
                liTopScores.Reverse();
            } //vrátit se sem při řešení tabulky leaderboard

            if (Canvas.GetLeft(recBall) - 20 == Canvas.GetLeft(recRacketPlayer) && Canvas.GetTop(recBall)  == Canvas.GetTop(recRacketPlayer) - 20) 
            {
                tbScore.Text = Convert.ToString(++Score);
                Y = -20;
                X = +20;

            }
            else if (Canvas.GetLeft(recBall) - 20 == Canvas.GetLeft(recRacketPlayer) && Canvas.GetTop(recBall) == Canvas.GetTop(recRacketPlayer)) { if (Y == 0) { Y = -20; }  X *= -1;  tbScore.Text = Convert.ToString(++Score); }
            else if (Canvas.GetLeft(recBall) - 20 == Canvas.GetLeft(recRacketPlayer) && Canvas.GetTop(recBall) == Canvas.GetTop(recRacketPlayer) + 20) { X = +20; Y = 0; tbScore.Text = Convert.ToString(++Score); }
            else if (Canvas.GetLeft(recBall) - 20 == Canvas.GetLeft(recRacketPlayer) && Canvas.GetTop(recBall) == Canvas.GetTop(recRacketPlayer) + 40) { if (Y == 0) { Y = 20; }  X *= -1; tbScore.Text = Convert.ToString(++Score); }
            else if (Canvas.GetLeft(recBall) - 20 == Canvas.GetLeft(recRacketPlayer) && Canvas.GetTop(recBall) == Canvas.GetTop(recRacketPlayer) + 60)
            {
                Y = 20;
                X = +20;
                tbScore.Text = Convert.ToString(++Score);
            }

            if (Canvas.GetLeft(recBall) + 20 == Canvas.GetLeft(recRacketAI) && Canvas.GetTop(recBall)  == Canvas.GetTop(recRacketAI) - 20)
            {
                Y = -20;
                X = -20;
            }
            else if (Canvas.GetLeft(recBall) + 20 == Canvas.GetLeft(recRacketAI) && Canvas.GetTop(recBall) == Canvas.GetTop(recRacketAI)) { if (Y == 0) { Y = -20; } X *= -1; }
            else if (Canvas.GetLeft(recBall) + 20 == Canvas.GetLeft(recRacketAI) && Canvas.GetTop(recBall)  == Canvas.GetTop(recRacketAI) + 20) { X = -20; Y = 0; }
            else if (Canvas.GetLeft(recBall) + 20 == Canvas.GetLeft(recRacketAI) && Canvas.GetTop(recBall)  == Canvas.GetTop(recRacketAI) + 40) { if (Y == 0) { Y = 20; } X *= -1; }
            else if (Canvas.GetLeft(recBall) + 20 == Canvas.GetLeft(recRacketAI) && Canvas.GetTop(recBall)  == Canvas.GetTop(recRacketAI) + 60)
            {
                Y = 20;
                X = -20;
            }





            Canvas.SetTop(recBall, LastY + Y);
            Canvas.SetLeft(recBall, LastX + X);

            Canvas.SetTop(recRacketAI, LastY);


        }
    }
}
