using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    internal class dbManager
    {
        public static void AddPlayer(int id, string name, string username)
        {
            SnakeEntities1 context = new SnakeEntities1();
            Player p = new Player();
            p.id = id;
            p.name = name;
            p.username = username;

            context.Players.Add(p);
            context.SaveChanges();
        }

        public static void AddScore(int id, int playerId, int score, DateTime date)
        {
            SnakeEntities1 context = new SnakeEntities1();
            Score s = new Score();
            s.id = id;
            s.player_id = playerId;
            s.score = score;
            s.date = date;

            context.Scores.Add(s);
            context.SaveChanges();
        }

        public static List<Player> GetPlayers()
        {
            SnakeEntities1 context = new SnakeEntities1();

            var query = from Player in context.Players
                        select Player;

            var result = query.ToList();

            return result;
        }

        public static List<Score> GetScores()
        {
            SnakeEntities1 context = new SnakeEntities1();

            var query = from Score in context.Scores
                        select Score;

            var result = query.ToList();

            return result;

        }

    }
}
