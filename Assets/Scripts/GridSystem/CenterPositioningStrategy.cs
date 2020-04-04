using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CenterPositioningStrategy : GridItemPositioningStrategy
    {
        private int amountOfGridColumns;
        private int amountOfGridRows;
        private Vector2 gridOrigin;
        private Vector2 gridItemMeasuresInUnit;
        private float offset;

        public CenterPositioningStrategy(int amountOfGridColumns, int amountOfGridRows, Vector2 gridOrigin, Vector2 gridItemMeasuresInUnit, float offset)
        {
            this.amountOfGridColumns = amountOfGridColumns;
            this.amountOfGridRows = amountOfGridRows;
            this.gridOrigin = gridOrigin;
            this.gridItemMeasuresInUnit = gridItemMeasuresInUnit;
            this.offset = offset;
        }

        public Vector2 GetGridItemPositionByRowAndColum(int row, int column)
        {
            Vector2 firstGridItemPosition = GetFirstGridItemPosition();
            float xTranslation = (gridItemMeasuresInUnit.x + offset) * column;
            float yTranslation = (gridItemMeasuresInUnit.y + offset) * row;
            float gridItemXPosition = firstGridItemPosition.x + xTranslation;
            float gridItemYPosition = firstGridItemPosition.y - yTranslation;

            return new Vector2(gridItemXPosition, gridItemYPosition);
        }

        private Vector2 GetFirstGridItemPosition()
        {
            int amountOfGridItemOnTheLeft = amountOfGridColumns / 2;
            int amountOfGridItemOnTheTop = amountOfGridRows / 2;
            float amountOfColumnsOffsets = amountOfGridColumns - 1;
            float amountOfRowOffsets = amountOfGridRows - 1;
            float amountOfColumnOffsetsOnTheLeft = amountOfColumnsOffsets / 2;
            float amountOfRowOffsetsOnTheTop = amountOfRowOffsets / 2;

            float firstGridItemXPosition = gridOrigin.x - ((gridItemMeasuresInUnit.x * amountOfGridItemOnTheLeft) + (offset * amountOfColumnOffsetsOnTheLeft));
            float firstGridItemYPosition = gridOrigin.y + ((gridItemMeasuresInUnit.y * amountOfGridItemOnTheTop) + (offset * amountOfRowOffsetsOnTheTop));

            float finalPositionX = firstGridItemXPosition;
            float finalPositionY = firstGridItemYPosition;
            if (amountOfGridColumns % 2 == 0)
                finalPositionX = firstGridItemXPosition + gridItemMeasuresInUnit.x / 2;
            if (amountOfGridRows % 2 == 0)
                finalPositionY = firstGridItemYPosition - gridItemMeasuresInUnit.y / 2;
             
            return new Vector2(finalPositionX, finalPositionY);
        }
    }
}