using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class Grid
    {
        private int width;
        private int height;
        private PieceFactory pieceFactory;
        private float offsetBetweenPieces;
        private PiecePositioningStrategy positioningStrategy;

        public Grid(int width, int height, PieceFactory pieceFactory, float offsetBetweenPieces, Vector2 origin)
        {
            this.width = width;
            this.height = height;
            this.pieceFactory = pieceFactory;
            this.offsetBetweenPieces = offsetBetweenPieces;
            Origin = origin;
            PieceObjects = new List<GameObject>();

            positioningStrategy = CreatePositioningStrategy();
            CreatePieces();
        }

        public int Width
        {
            get
            {
                return width;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }
        }
        public Vector2 Position
        {
            get;
            private set;
        }
        public List<GameObject> PieceObjects { get; private set; }
        public Vector2 Origin { get; private set; }

        private PiecePositioningStrategy CreatePositioningStrategy()
        {
            float pieceWidthInUnit = pieceFactory.PieceWidthInUnit;
            float pieceHeightInUnit = pieceFactory.PieceHeightInUnit;
            Vector2 pieceMeasuresInUnit = new Vector2(pieceWidthInUnit, pieceHeightInUnit);

            return new CenterPositioningStrategy
            (
                Width,
                Height,
                Origin,
                pieceMeasuresInUnit,
                offsetBetweenPieces
            );
        }

        private void CreatePieces()
        {
            for(int row = 0; row < Height; row++)
            {
                for(int column = 0; column < Width; column++)
                {
                    CreatePieceToRowAndColumn(column, row);
                }
            }
        }

        private void CreatePieceToRowAndColumn(int column, int row)
        {
            GameObject pieceObject = pieceFactory.Create();
            pieceObject.name = row + "x" + column;
            PieceMover pieceMover = pieceObject.GetComponent<PieceMover>();

            pieceMover.Position = positioningStrategy.GetPiecePositionByRowAndColum(row, column);
            pieceMover.SetupRownAndColumn(row, column);
            PieceObjects.Add(pieceObject);
        }
    }
}