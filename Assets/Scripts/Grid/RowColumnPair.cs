namespace CCintron.Grid
{
    public class RowColumnPair
    {
        public float Row { get; private set; }
        public float Column { get; private set; }

        public RowColumnPair(float row, float column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return string.Format("Row:{0} Column:{1}",Row,Column);
        }
    }
}