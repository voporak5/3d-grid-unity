using System.Collections.Generic;
using System;

namespace CCintron.Grid
{
    public abstract class Node
    {
        const float GRID_LINE_OFFSET = 0.5f;

        List<RowColumnPair> coords = new List<RowColumnPair>();
        bool hasEvenRows;
        bool hasEvenColumns;

        //Assumes input is a valid pattern (x,o,\n)
        //Columns in each row should be consistent as well
        protected void Init(string pattern)
        {
            //Assume that pattern is not null
            string[] rowsString =   pattern.Split('\n');
            int nRows           =   rowsString.Length;
            //Assumes all rows have same number of columns
            int nColumns        =   rowsString[0].Length;
            //Even rows need special shifting to avoid gridlines
            hasEvenRows         =   nRows % 2 == 0;
            hasEvenColumns      =   nColumns % 2 == 0;
            float topLeftRow    =   -(float)Math.Floor(nRows / (float)2);
            float topLeftColumn =   -(float)Math.Floor(nColumns / (float)2);

            topLeftRow += hasEvenRows ? GRID_LINE_OFFSET : 0;
            topLeftColumn += hasEvenColumns ? GRID_LINE_OFFSET : 0;

            float row = topLeftRow;
            for (int i = 0; i < rowsString.Length; i++, row++)
            {
                string rowString = rowsString[i];
                //column needs to resets when row changes
                //like on a typewriter when going to the next line
                float column = topLeftColumn;

                for(int j = 0; j < rowString.Length; j++, column++)
                {
                    if (rowString[j] == 'x') coords.Add(new RowColumnPair(row, column));
                }
            }
        }

        //This will help position the object at the correct center point
        public RowColumnPair GetCenterPointFromMouseCoord(float x, float y)
        {
            //Need to subtract 0.5 for even rows/columns otherwise
            //center will be on gridlines.
            //Ceiling - Offset will put us on the nearest gridline.
            //Round will put us on the center of the nearest tile
            float row = (float)(hasEvenRows ? Math.Ceiling(x) - GRID_LINE_OFFSET : Math.Round(x));
            float column = (float)(hasEvenColumns ? Math.Ceiling(y) - GRID_LINE_OFFSET : Math.Round(y));

            return new RowColumnPair(row, column);
        }

        //This will help show which tiles while be filled
        public RowColumnPair[] GetCoordsFromPoint(float row, float column)
        {
            RowColumnPair[] coordsFromPoint = new RowColumnPair[coords.Count];

            for(int i = 0; i < coords.Count; i++)
            {
                RowColumnPair coord = coords[i];
                coordsFromPoint[i] = new RowColumnPair(coord.Row + row, coord.Column + column);
            }

            return coordsFromPoint;
        }

        public abstract void SetPosition(float x, float y);
    }
}