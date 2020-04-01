using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;
using System;

namespace Tests
{
    public class StubPieceComponent : MonoBehaviour, PieceMover, Piece
    {
        private float widthInUnit = 5;
        private float heightInUnit = 6;
        private float widthInPixels = 500;
        private float heightInPixels = 600;
        private float pixelPerUnit = 100;

        public int Row { get; private set; }
        public int Column { get; private set; }
        public Vector2 Position
        {
            get
            {
                return transform.position;
            }
            set
            {
                transform.position = value;
            }
        }
        public float WidthInUnit
        {
            get
            {
                return widthInPixels / pixelPerUnit;
            }
        }
        public float HeightInUnit
        {
            get
            {
                return heightInPixels / pixelPerUnit;
            }
        }

        public void SetupRownAndColumn(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public void SetWidthAndHeightInPixels(float widthInPixels, float heightInPixels)
        {
            this.widthInPixels = widthInPixels;
            this.heightInPixels = heightInPixels;
        }

        internal void SetPixelPerUnit(float pixelPerUnit)
        {
            this.pixelPerUnit = pixelPerUnit;
        }
    }
}