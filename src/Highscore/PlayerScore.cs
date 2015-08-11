namespace Highscore
{
    public struct PlayerScore
    {
        private int score;
        private string name;

        public PlayerScore(int score, string name)
            :this()
        {
            this.Score = score;
            this.Name = name;
        }


        public int Score
        {
            get 
            {
                return this.score; 
            }
            set 
            {
                this.score = value; 
            }
        }

        public string Name
        {
            get 
            {
                return this.name; 
            }
            set 
            {
                this.name = value; 
            }
        }

        public int CompareTo(PlayerScore other)
        {
            return this.Score.CompareTo(other.Score);
        }
    }
}
