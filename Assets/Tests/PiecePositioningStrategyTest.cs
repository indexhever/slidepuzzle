using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;
using System;

namespace Tests
{
    public class PiecePositioningStrategyTest
    {
        private Vector2 gridOrigin;
        private int amountOfGridColumns;
        private int amountOfGridRows;
        private Vector2 piceMeasuresInUnit;
        private float offset;
        private PiecePositioningStrategy positioningStrategy;

        [SetUp]
        public void Setup()
        {
            gridOrigin = new Vector2(0, 0);
            amountOfGridColumns = 3;
            amountOfGridRows = 3;
            piceMeasuresInUnit = new Vector2(5, 6);
            offset = 2;
            positioningStrategy = CreateCenterPositioningStrategy(amountOfGridColumns, amountOfGridRows, gridOrigin, piceMeasuresInUnit, offset);
        }

        [Test]
        public void GetFirstPiecePosition()
        {
            float firstPieceXPosition = gridOrigin.x - (piceMeasuresInUnit.x + offset);
            float firstPieceYPosition = gridOrigin.y + (piceMeasuresInUnit.y + offset);
            Vector2 positionFirstPieceShouldBe = new Vector2(firstPieceXPosition, firstPieceYPosition);

            Vector2 firstPiecePosition = positioningStrategy.GetPiecePositionByRowAndColum(0, 0);

            Assert.AreEqual(positionFirstPieceShouldBe, firstPiecePosition);                    
        }

        [Test]
        public void GetSecondPosition()
        {
            Vector2 firstPosition = positioningStrategy.GetPiecePositionByRowAndColum(0, 0);
            float xPositionItShoudHave = firstPosition.x + piceMeasuresInUnit.x + offset;
            float yPositionItShoudHave = firstPosition.y;
            Vector2 positionThatShouldBe = new Vector2(xPositionItShoudHave, yPositionItShoudHave);
            int row = 0;
            int column = 1;

            Vector2 resultedPiecePosition = positioningStrategy.GetPiecePositionByRowAndColum(row, column);

            Assert.AreEqual(positionThatShouldBe, resultedPiecePosition);
            //Assert.AreEqual(new Vector2(-3.5f, 12), resultedPiecePosition);
        }

        [Test]
        public void GetFourthPiecePosition()
        {
            Vector2 firstPosition = positioningStrategy.GetPiecePositionByRowAndColum(0, 0);
            float xPositionItShoudHave = firstPosition.x;
            float yPositionItShoudHave = firstPosition.y - (piceMeasuresInUnit.y + offset);
            Vector2 positionThatShouldBe = new Vector2(xPositionItShoudHave, yPositionItShoudHave);
            int row = 1;
            int column = 0;

            Vector2 resultedPiecePosition = positioningStrategy.GetPiecePositionByRowAndColum(row, column);

            Assert.AreEqual(positionThatShouldBe, resultedPiecePosition);
            //Assert.AreEqual(new Vector2(-10.5f, 12 - (6 + offset)), resultedPiecePosition);
        }

        [Test]
        public void GetMidlePiecePosition()
        {
            Vector2 positionThatShouldBe = new Vector2(0, 0);
            int row = 1;
            int column = 1;

            Vector2 resultedPiecePosition = positioningStrategy.GetPiecePositionByRowAndColum(row, column);

            Assert.AreEqual(positionThatShouldBe, resultedPiecePosition);
        }

        private PiecePositioningStrategy CreateCenterPositioningStrategy(int amountOfGridColumns, int amountOfGridRows, Vector2 gridOrigin, Vector2 piceMeasuresInUnit, float offset)
        {
            return new CenterPositioningStrategy(amountOfGridColumns, amountOfGridRows, gridOrigin, piceMeasuresInUnit, offset);
        }
    }
}
