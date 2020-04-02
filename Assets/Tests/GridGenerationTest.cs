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
            Assert.IsNotNull(grid.GridItemObjects);
            Assert.AreEqual(9, grid.GridItemObjects.Count);
        }

        [Test]
        public void FirstAndSecondGridItemAreNotNull()
        {
            Vector2 originPosition = new Vector2(0, 0);
            Game.Grid grid = CreateGrid(3, 3, 2, originPosition);

            GameObject firstGridItemObject = grid.GridItemObjects[0];
            GameObject secondGridItemObject = grid.GridItemObjects[1];

            Assert.IsNotNull(firstGridItemObject);
            Assert.IsNotNull(secondGridItemObject);
        }

        [Test]
        public void GetCreatedGridItems()
        {
            Vector2 originPosition = new Vector2(0, 0);
            Game.Grid grid = CreateGrid(3, 3, 2, originPosition);

            GameObject firstGridItemObject = grid.GridItemObjects[0];
            GameObject secondGridItemObject = grid.GridItemObjects[1];
            GameObject thirdGridItemObject = grid.GridItemObjects[2];

            GridItemMover firstGridItemMover = firstGridItemObject.GetComponent<GridItemMover>();
            GridItem firstGridItem = firstGridItemObject.GetComponent<GridItem>();
            GridItemMover secondGridItemMover = secondGridItemObject.GetComponent<GridItemMover>();
            GridItem secondGridItem = secondGridItemObject.GetComponent<GridItem>();
            GridItemMover thirdGridItemMover = thirdGridItemObject.GetComponent<GridItemMover>();
            GridItem thirdGridItem = thirdGridItemObject.GetComponent<GridItem>();

            Assert.AreEqual(5, firstGridItem.WidthInUnit);
            Assert.AreEqual(6, firstGridItem.HeightInUnit);
            Assert.AreNotEqual(secondGridItemMover.Position, thirdGridItemMover.Position);
            Assert.AreNotEqual(firstGridItemMover.Position, secondGridItemMover.Position);            
            //Assert.AreEqual(new Vector2(-10.5f, 12), firstGridItemMover.Position);
            Assert.AreEqual(firstGridItemMover.Position + new Vector2(secondGridItem.WidthInUnit + 2, 0), secondGridItemMover.Position);
            Assert.AreEqual(secondGridItemMover.Position + new Vector2(thirdGridItem.WidthInUnit + 2, 0), thirdGridItemMover.Position);
        }

        [Test]
        public void CreatePieaceAndSetItsPosition()
        {
            float offset = 2;
            Vector2 originPosition = new Vector2(0, 0);
            Game.Grid grid = CreateGrid(3, 3, offset, originPosition);
            GridItemFactory gridItemFactory = CreateGridItemFactory();

            float gridItemWidthInUnit = gridItemFactory.GridItemWidthInUnit;
            float gridItemHeightInUnit = gridItemFactory.GridItemHeightInUnit;
            int amountOfGridColumns = grid.Width;
            int amountOfGridRows = grid.Height;
            Vector2 gridOrigin = grid.Position;
            Vector2 piceMeasuresInUnit = new Vector2(gridItemWidthInUnit, gridItemHeightInUnit);
            
            GridItemPositioningStrategy positioningStrategy = CreateCenterPositioningStrategy
            (
                amountOfGridColumns, 
                amountOfGridRows, 
                gridOrigin, 
                piceMeasuresInUnit, 
                offset
            );

            GameObject gridItemObject = gridItemFactory.Create();
            GridItem gridItem = gridItemObject.GetComponent<GridItem>();
            GridItemMover gridItemMover = gridItemObject.GetComponent<GridItemMover>();

            Assert.IsNotNull(gridItem);
            Assert.IsNotNull(gridItemMover);

            gridItemMover.Position = positioningStrategy.GetGridItemPositionByRowAndColum(0, 0);

            Assert.AreEqual(gridItemWidthInUnit, gridItem.WidthInUnit);
            Assert.AreEqual(gridItemHeightInUnit, gridItem.HeightInUnit);
            //Assert.AreEqual(new Vector2(-10.5f, 12), gridItemMover.Position);
        }

        private Game.Grid CreateGrid(int width, int height, float offset, Vector2 originPosition)
        {
            GridItemFactory gridItemFactory = CreateGridItemFactory();
            return new Game.Grid(width, height, gridItemFactory, offset, originPosition);
        }

        private GridItemFactory CreateGridItemFactory()
        {
            return new StubGridItemFactory();
        }

        private GridItemPositioningStrategy CreateCenterPositioningStrategy(int amountOfGridColumns, int amountOfGridRows, Vector2 gridOrigin, Vector2 piceMeasuresInUnit, float offset)
        {
            return new CenterPositioningStrategy(amountOfGridColumns, amountOfGridRows, gridOrigin, piceMeasuresInUnit, offset);
        }
    }
}
