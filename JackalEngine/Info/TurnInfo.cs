namespace JackalEngine
{
    public class TurnInfo
    {
        private TurnInfo()
        {
        }

        public TurnInfo(int charId, Side moveTo)
        {
            CharacterId = charId;
            MovingSide = moveTo;
        }

        public int CharacterId { get; set; }
        public Side MovingSide { get; set; }
    }
}