namespace JackalEngine
{
    public class CharInfo
    {
        private CharInfo()
        {
        }

        public CharInfo(int gold, int death, bool withGold)
        {
            Death = death;
            Gold = gold;
            WithGold = withGold;
        }

        public int Death { get; private set; }
        public int Gold { get; private set; }
        public bool WithGold { get; private set; }
    }
}