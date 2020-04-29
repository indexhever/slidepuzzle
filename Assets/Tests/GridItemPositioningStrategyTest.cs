using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;
using System;

namespace Tests
{
    public class GridItemPositioningStrategyTest
    {
        private Vector2 gridOrigin;
        private int amountOfGridColumns;
        private int amountOfGridRows;
        private Vector2 gridItemMeasuresInUnit;
        private float offset;
        private GridItemPositioningStrategy positioningStrategy;

        [SetUp]
        public void Setup()
        {
            gridOrigin = new Vector2(0, 0);
            amountOfGridColumns = 3;
            amountOfGridRows = 3;
            gridItemMeasuresInUnit = new Vector2(5, 6);
            offset = 2;
            positioningStrategy = CreateCenterPositioningStrategy(amountOfGridColumns, amountOfGridRows, gridOrigin, gridItemMeasuresInUnit, offset);
        }

        [Test]
        public void GetFirstGridItemPosition()
        {
            float firstGridItemXPosition = gridOrigin.x - (gridItemMeasuresInUnit.x + offset);
            float firstGridItemYPosition = gridOrigin.y + (gridItemMeasuresInUnit.y + offset);
            Vector2 positionFirstGridItemShouldBe = new Vector2(firstGridItemXPosition, firstGridItemYPosition);

            Vector2 firstGridItemPosition = positioningStrategy.GetGridItemPositionByRowAndColum(0, 0);

            Assert.AreEqual(positionFirstGridItemShouldBe, firstGridItemPosition);                    
        }

        [Test]
        public void GetSecondPosition()
        {
            Vector2 firstPosition = positioningStrategy.GetGridItemPositionByRowAndColum(0, 0);
            float xPositionItShoudHave = firstPosition.x + gridItemMeasuresInUnit.x + offset;
            float yPositionItShoudHave = firstPosition.y;
            Vector2 positionThatShouldBe = new Vector2(xPositionItShoudHave, yPositionItShoudHave);
            int row = 0;
            int column = 1;

            Vector2 resultedGridItemPosition = positioningStrategy.GetGridItemPositionByRowAndColum(row, column);

            Assert.AreEqual(positionThatShouldBe, resultedGridItemPosition);
        }

        [Test]
        public void GetFourthGridItemPosition()
        {
            Vector2 firstPosition = positioningStrategy.GetGridItemPositionByRowAndColum(0, 0);
            float xPositionItShoudHave = firstPosition.x;
            float yPositionItShoudHave = firstPosition.y - (gridItemMeasuresInUnit.y + offset);
            Vector2 positionThatShouldBe = new Vector2(xPositionItShoudHave, yPositionItShoudHave);
            int row = 1;
            int column = 0;

            Vector2 resultedGridItemPosition = positioningStrategy.GetGridItemPositionByRowAndColum(row, column);

            Assert.AreEqual(positionThatShouldBe, resultedGridItemPosition);
        }

        [Test]
        public void GetMidleGridItemPosition()
        {
            Vector2 positionThatShouldBe = new Vector2(0, 0);
            int row = 1;
            int column = 1;

            Vector2 resultedGridItemPosition = positioningStrategy.GetGridItemPositionByRowAndColum(row, column);

            Assert.AreEqual(positionThatShouldBe, resultedGridItemPosition);
        }

        private GridItemPositioningStrategy CreateCenterPositioningStrategy(int amountOfGridColumns, int amountOfGridRows, Vector2 gridOrigin, Vector2 gridItemgMeasuresInUnit, float offset)
        {
            return new CenterPositioningStrategy(amountOfGridColumns, amountOfGridRows, gridOrigin, gridItemgMeasuresInUnit, offset);
        }
    }
}
