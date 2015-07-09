namespace JackalEngine
{
    public class Cell
    {
        public Cell()
        {
            Type = CellType.Hidden;
        }

        public Cell(CellType type)
        {
            Type = type;
        }

        public int XCoord { get; internal set; }
        public int YCoord { get; internal set; }
        public CellType Type { get; private set; }

        public override string ToString()
        {
            return "-------------" + Type + "\n";
        }
    }
}