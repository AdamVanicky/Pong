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
    public class LeaderBoard
    {
        public List<int> FillLeaderBoard(string fileName)
        {
            List<int> tempList = new List<int>();

            if (File.Exists(fileName))
            {
                string s = File.ReadAllText(fileName);
                string[] Pole = s.Split('*');
                int hodnota = 0;
                for (int j = 0; j < Pole.Length; j++)
                {
                    hodnota = Convert.ToInt32(Pole[j]);
                    tempList.Add(hodnota);
                }
                tempList.Sort();
                tempList.Reverse();
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    tempList.Add(0);
                }
            }
            return tempList;
        }

        public void SetLeaderboard(int[] Pole, RichTextBox rtbLeaderboard)
        {
            rtbLeaderboard.Document.Blocks.Clear();
            rtbLeaderboard.Document.Blocks.Add(new Paragraph(new Run("Žebříček nejlepších")));
            rtbLeaderboard.Document.Blocks.Add(new Paragraph(new Run("===============")));
            #region LongerVersion
            //rtbLeaderboard.Document.Blocks.Add(new Paragraph(new Run($"1. {Pole[0]} b.")));
            //rtbLeaderboard.Document.Blocks.Add(new Paragraph(new Run($"2. {Pole[1]} b.")));
            //rtbLeaderboard.Document.Blocks.Add(new Paragraph(new Run($"3. {Pole[2]} b.")));
            //rtbLeaderboard.Document.Blocks.Add(new Paragraph(new Run($"4. {Pole[3]} b.")));
            //rtbLeaderboard.Document.Blocks.Add(new Paragraph(new Run($"5. {Pole[4]} b.")));
            //rtbLeaderboard.Document.Blocks.Add(new Paragraph(new Run($"6. {Pole[5]} b.")));
            //rtbLeaderboard.Document.Blocks.Add(new Paragraph(new Run($"7. {Pole[6]} b.")));
            //rtbLeaderboard.Document.Blocks.Add(new Paragraph(new Run($"8. {Pole[7]} b.")));
            //rtbLeaderboard.Document.Blocks.Add(new Paragraph(new Run($"9. {Pole[8]} b.")));
            //rtbLeaderboard.Document.Blocks.Add(new Paragraph(new Run($"10. {Pole[9]} b.")));
            #endregion
            for (int i = 0; i < Pole.Length; i++)
            {
                rtbLeaderboard.Document.Blocks.Add(new Paragraph(new Run($"{i + 1}. {Pole[i]} b.")));
            }
        }
    }
}
