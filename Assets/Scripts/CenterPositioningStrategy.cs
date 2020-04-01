using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class CenterPositioningStrategy : PiecePositioningStrategy
    {
        private int amountOfGridColumns;
        private int amountOfGridRows;
        private Vector2 gridOrigin;
        private Vector2 piceMeasuresInUnit;
        private float offset;

        public CenterPositioningStrategy(int amountOfGridColumns, int amountOfGridRows, Vector2 gridOrigin, Vector2 piceMeasuresInUnit, float offset)
        {
            this.amountOfGridColumns = amountOfGridColumns;
            this.amountOfGridRows = amountOfGridRows;
            this.gridOrigin = gridOrigin;
            this.piceMeasuresInUnit = piceMeasuresInUnit;
            this.offset = offset;
        }

        public Vector2 GetPiecePositionByRowAndColum(int row, int column)
        {
            Vector2 firstPiecePosition = GetFirstPiecePosition();
            float xTranslation = (piceMeasuresInUnit.x + offset) * column;
            float yTranslation = (piceMeasuresInUnit.y + offset) * row;
            float pieceXPosition = firstPiecePosition.x + xTranslation;
            float pieceYPosition = firstPiecePosition.y - yTranslation;

            return new Vector2(pieceXPosition, pieceYPosition);
        }

        private Vector2 GetFirstPiecePosition()
        {
            //float firstPieceXPosition = gridOrigin.x - (piceMeasuresInUnit.x * amountOfGridColumns / 2 + (int)(amountOfGridColumns / 2f * offset));
            //float firstPieceYPosition = gridOrigin.y + (piceMeasuresInUnit.y * amountOfGridRows / 2 + (int)(amountOfGridRows / 2f * offset));

            //float firstPieceXPosition = gridOrigin.x - ((piceMeasuresInUnit.x + offset) * ((int)(amountOfGridColumns / 2f)));
            //float firstPieceYPosition = gridOrigin.y + ((piceMeasuresInUnit.y + offset) * ((int)(amountOfGridRows / 2f)));

            int amountOfPiecesOnTheLeft = amountOfGridColumns / 2;
            int amountOfPiecesOnTheTop = amountOfGridRows / 2;
            float amountOfColumnsOffsets = amountOfGridColumns - 1;
            float amountOfRowOffsets = amountOfGridRows - 1;
            float amountOfColumnOffsetsOnTheLeft = amountOfColumnsOffsets / 2;
            float amountOfRowOffsetsOnTheTop = amountOfRowOffsets / 2;

            float firstPieceXPosition = gridOrigin.x - ((piceMeasuresInUnit.x * amountOfPiecesOnTheLeft) + (offset * amountOfColumnOffsetsOnTheLeft));
            float firstPieceYPosition = gridOrigin.y + ((piceMeasuresInUnit.y * amountOfPiecesOnTheTop) + (offset * amountOfRowOffsetsOnTheTop));

            float finalPositionX = firstPieceXPosition;
            float finalPositionY = firstPieceYPosition;
            if (amountOfGridColumns % 2 == 0)
                finalPositionX = firstPieceXPosition + piceMeasuresInUnit.x / 2;
            if (amountOfGridRows % 2 == 0)
                finalPositionY = firstPieceYPosition - piceMeasuresInUnit.y / 2;
             
            return new Vector2(finalPositionX, finalPositionY);
        }
    }
}