using System.Collections.Generic;

namespace CCintron.Grid
{
    public abstract class Node
    {
        List<RowColumnPair> coords = new List<RowColumnPair>();

        protected void Init(string pattern)
        {
            string[] rows = pattern.Split('\n');

            for(int i = 0; i < rows.Length; i++)
            {
                string row = rows[i];

                for(int j = 0; j < row.Length; j++)
                {
                    if (row[j] == 'x') coords.Add(new RowColumnPair(i, j));

                }
            }
        }

        public RowColumnPair[] GetCoordsFromPoint(int row, int column)
        {
            RowColumnPair[] coordsFromPoint = new RowColumnPair[coords.Count];

            for(int i = 0; i < coords.Count; i++)
            {
                RowColumnPair coord = coords[i];
                coordsFromPoint[i] = new RowColumnPair(coord.Row + row, coord.Column + column);
            }

            return coordsFromPoint;
        }
    }
}