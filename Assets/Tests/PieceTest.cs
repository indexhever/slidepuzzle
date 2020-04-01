using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;
using System;

namespace Tests
{
    public class PieceTest : MonoBehaviour
    {
        [Test]
        public void PieceCreation()
        {
            int initialPieceRow = 1;
            int initialPieceColum = 2;

            PieceMover pieceMover = CreatePieceMover();
            pieceMover.SetupRownAndColumn(initialPieceRow, initialPieceColum);
            PieceImplementation piece = new PieceImplementation(pieceMover);

            Assert.AreEqual(initialPieceRow, piece.Row);
            Assert.AreEqual(initialPieceColum, piece.Column);
        }

        [Test]
        public void PieceMoverCreation()
        {
            PieceMover pieceMover = CreatePieceMover();

            Assert.IsNotNull(pieceMover);
        }

        [Test]
        public void SetupPieceMoverRowAndColumn()
        {
            int row = 1;
            int column = 2;
            PieceMover pieceMover = CreatePieceMover();
            pieceMover.SetupRownAndColumn(row, column);

            Assert.AreEqual(row, pieceMover.Row);
            Assert.AreEqual(column, pieceMover.Column);
        }

        [Test]
        public void ChangePiecePosition()
        {
            PieceMover pieceMover = CreatePieceMover();
            Vector2 newPosition = new Vector2(1, 2);

            Vector2 initialPiecePosition = pieceMover.Position;
            pieceMover.Position = newPosition;

            Assert.AreEqual(new Vector2(0, 0), initialPiecePosition);
            Assert.AreEqual(newPosition, pieceMover.Position);
        }

        [Test]
        public void CalculatePieceWidthAndHeightInUnit()
        {
            float spriteWidthInPixel = 30;
            float spriteHeightInPixel = 40;
            float spritePixelPerUnit = 100;

            Piece piece = CreatePieceWithWidthAndHeightInPixelsAndPixelPerUnit(spriteWidthInPixel, spriteHeightInPixel, spritePixelPerUnit);
            //float spriteWidthInUnit = spriteWidthInPixel / spritePixelPerUnit;

            Assert.AreEqual(0.3f, piece.WidthInUnit);
            Assert.AreEqual(0.4f, piece.HeightInUnit);
        }

        private PieceMover CreatePieceMover()
        {
            PieceFactory pieceFactory = CreatePieceFactory();
            GameObject pieceObject = pieceFactory.Create();
            return pieceObject.GetComponent<PieceMover>();
        }

        private Piece CreatePieceWithWidthAndHeightInPixelsAndPixelPerUnit(float widthInPixels, float heightInPixels, float pixelPerUnit)
        {
            PieceFactory pieceFactory = CreatePieceFactory();
            GameObject pieceObject = pieceFactory.Create();
            StubPieceComponent stubPieceComponent = pieceObject.GetComponent<StubPieceComponent>();
            stubPieceComponent.SetWidthAndHeightInPixels(widthInPixels, heightInPixels);
            stubPieceComponent.SetPixelPerUnit(pixelPerUnit);

            return stubPieceComponent;
        }

        private PieceFactory CreatePieceFactory()
        {
            return new StubPieceFactory();
        }
    }
}