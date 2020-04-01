using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;
using System;

namespace Tests
{
    public class GridGenerationTest : MonoBehaviour
    {
        [Test]
        public void GridCreation()
        {
            Vector2 originPosition = new Vector2(0, 0);
            Game.Grid grid = CreateGrid(3, 3, 1, originPosition);

            Assert.AreEqual(3, grid.Width);
            Assert.AreEqual(3, grid.Height);
            Assert.IsNotNull(grid.PieceObjects);
            Assert.AreEqual(9, grid.PieceObjects.Count);
        }

        [Test]
        public void FirstAndSecondPieceAreNotNull()
        {
            Vector2 originPosition = new Vector2(0, 0);
            Game.Grid grid = CreateGrid(3, 3, 2, originPosition);

            GameObject firstPieceObject = grid.PieceObjects[0];
            GameObject secondPieceObject = grid.PieceObjects[1];

            Assert.IsNotNull(firstPieceObject);
            Assert.IsNotNull(secondPieceObject);
        }

        [Test]
        public void GetCreatedPieces()
        {
            Vector2 originPosition = new Vector2(0, 0);
            Game.Grid grid = CreateGrid(3, 3, 2, originPosition);

            GameObject firstPieceObject = grid.PieceObjects[0];
            GameObject secondPieceObject = grid.PieceObjects[1];
            GameObject thirdPieceObject = grid.PieceObjects[2];

            PieceMover firstPieceMover = firstPieceObject.GetComponent<PieceMover>();
            Piece firstPiece = firstPieceObject.GetComponent<Piece>();
            PieceMover secondPieceMover = secondPieceObject.GetComponent<PieceMover>();
            Piece secondPiece = secondPieceObject.GetComponent<Piece>();
            PieceMover thirdPieceMover = thirdPieceObject.GetComponent<PieceMover>();
            Piece thirdPiece = thirdPieceObject.GetComponent<Piece>();

            Assert.AreEqual(5, firstPiece.WidthInUnit);
            Assert.AreEqual(6, firstPiece.HeightInUnit);
            Assert.AreNotEqual(secondPieceMover.Position, thirdPieceMover.Position);
            Assert.AreNotEqual(firstPieceMover.Position, secondPieceMover.Position);            
            //Assert.AreEqual(new Vector2(-10.5f, 12), firstPieceMover.Position);
            Assert.AreEqual(firstPieceMover.Position + new Vector2(secondPiece.WidthInUnit + 2, 0), secondPieceMover.Position);
            Assert.AreEqual(secondPieceMover.Position + new Vector2(thirdPiece.WidthInUnit + 2, 0), thirdPieceMover.Position);
        }

        [Test]
        public void CreatePieaceAndSetItsPosition()
        {
            float offset = 2;
            Vector2 originPosition = new Vector2(0, 0);
            Game.Grid grid = CreateGrid(3, 3, offset, originPosition);
            PieceFactory pieceFactory = CreatePieceFactory();

            float pieceWidthInUnit = pieceFactory.PieceWidthInUnit;
            float pieceHeightInUnit = pieceFactory.PieceHeightInUnit;
            int amountOfGridColumns = grid.Width;
            int amountOfGridRows = grid.Height;
            Vector2 gridOrigin = grid.Position;
            Vector2 piceMeasuresInUnit = new Vector2(pieceWidthInUnit, pieceHeightInUnit);
            
            PiecePositioningStrategy positioningStrategy = CreateCenterPositioningStrategy
            (
                amountOfGridColumns, 
                amountOfGridRows, 
                gridOrigin, 
                piceMeasuresInUnit, 
                offset
            );

            GameObject pieceObject = pieceFactory.Create();
            Piece piece = pieceObject.GetComponent<Piece>();
            PieceMover pieceMover = pieceObject.GetComponent<PieceMover>();

            Assert.IsNotNull(piece);
            Assert.IsNotNull(pieceMover);

            pieceMover.Position = positioningStrategy.GetPiecePositionByRowAndColum(0, 0);

            Assert.AreEqual(pieceWidthInUnit, piece.WidthInUnit);
            Assert.AreEqual(pieceHeightInUnit, piece.HeightInUnit);
            //Assert.AreEqual(new Vector2(-10.5f, 12), pieceMover.Position);
        }

        private Game.Grid CreateGrid(int width, int height, float offset, Vector2 originPosition)
        {
            PieceFactory pieceFactory = CreatePieceFactory();
            return new Game.Grid(width, height, pieceFactory, offset, originPosition);
        }

        private PieceFactory CreatePieceFactory()
        {
            return new StubPieceFactory();
        }

        private PiecePositioningStrategy CreateCenterPositioningStrategy(int amountOfGridColumns, int amountOfGridRows, Vector2 gridOrigin, Vector2 piceMeasuresInUnit, float offset)
        {
            return new CenterPositioningStrategy(amountOfGridColumns, amountOfGridRows, gridOrigin, piceMeasuresInUnit, offset);
        }
    }
}
