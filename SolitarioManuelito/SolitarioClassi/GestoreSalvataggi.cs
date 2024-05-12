using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitarioClassi
{
    public class GestoreSalvataggi
    {
        private string _recordPath;
        private string _leaderboardPath;
        public GestoreSalvataggi()
        {
            _recordPath = "record.txt";
            _leaderboardPath = "leaderboard.txt";
        }
        public int? LeggiRecord()
        {
            string line;
            using (StreamReader sr = new StreamReader(_recordPath))
            {
                line= sr.ReadLine();
            }
            if (line == "null") return null; 
            return Convert.ToInt32(line);
        }
        public void ScriviRecord(int record)
        {
            using (StreamWriter sw = new StreamWriter(_recordPath))
            {
                sw.WriteLine(record.ToString());
            }
        }
        public void AggiornaLeaderboard(string nome, int punteggio)
        {
            List<(int, string)> leaderboard=LeggiLeaderboard();
            leaderboard.Add((punteggio, nome));
            leaderboard.Sort();
            using (StreamWriter sw = new StreamWriter(_leaderboardPath))
            {
                foreach ((int, string) p in leaderboard)
                {
                    sw.WriteLine(p.Item1.ToString() + " " + p.Item2);
                }
            }
        }
        public List<(int, string)> LeggiLeaderboard()
        {
            
            string? line;
            List<(int, string)> leaderboard = new List<(int, string)>();
            using (StreamReader sr = new StreamReader(_leaderboardPath))
            {
                while(!string.IsNullOrEmpty(line = sr.ReadLine()))
                {                   
                    string[] lineaSpezzata = line.Split(' ');
                    (int, string) nuovoPunteggio = (Convert.ToInt32(lineaSpezzata[0]), lineaSpezzata[1]);
                    leaderboard.Add(nuovoPunteggio);
                }
            }
            leaderboard.Sort();
            return leaderboard;
        }
    }
}
