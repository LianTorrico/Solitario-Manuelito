using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitarioClassi
{
    public class GestoreSalvataggi
    {
        private string _leaderboardPath;
        public GestoreSalvataggi()
        {
            _leaderboardPath = "leaderboard.txt";
        }
        private void CreaFileSeNonEsistente()
        {
            if (!File.Exists(_leaderboardPath))
            {
                File.Create(_leaderboardPath).Close();
            }
        }
        public int? LeggiRecord()
        {
            CreaFileSeNonEsistente();
            string line;
            using (StreamReader sr = new StreamReader(_leaderboardPath))
            {
                line= sr.ReadLine();
            }
            if (line == null) return null;
            string[] lineaSpezzata = line.Split(' ');
            return Convert.ToInt32(lineaSpezzata[0]);
        }
        public string? LeggiNomeRecord()
        {
            string line;
            using (StreamReader sr = new StreamReader(_leaderboardPath))
            {
                line = sr.ReadLine();
            }
            if (line == "null") return null;
            string[] lineaSpezzata = line.Split(' ');
            return lineaSpezzata[1];
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
