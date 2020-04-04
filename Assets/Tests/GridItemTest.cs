using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;
using System;

namespace Tests
{
    public class GridItemTest : MonoBehaviour
    {
        [Test]
        public void PieceCreation()
        {
            int initialGridItemRow = 1;
            int initialGridItemColum = 2;

            GridItemMover gridItemMover = CreateGridItemMover();
            gridItemMover.SetupRownAndColumn(initialGridItemRow, initialGridItemColum);
            PieceImplementation piece = new PieceImplementation(gridItemMover);

            Assert.AreEqual(initialGridItemRow, piece.Row);
            Assert.AreEqual(initialGridItemColum, piece.Column);
        }

        [Test]
        public void GridItemMoverCreation()
        {
            GridItemMover gridItemMover = CreateGridItemMover();

            Assert.IsNotNull(gridItemMover);
        }

        [Test]
        public void SetupGridItemMoverRowAndColumn()
        {
            int row = 1;
            int column = 2;
            GridItemMover gridItemMover = CreateGridItemMover();
            gridItemMover.SetupRownAndColumn(row, column);

            Assert.AreEqual(row, gridItemMover.Row);
            Assert.AreEqual(column, gridItemMover.Column);
        }

        [Test]
        public void ChangeGridItemPosition()
        {
            GridItemMover gridItemMover = CreateGridItemMover();
            Vector2 newPosition = new Vector2(1, 2);

            Vector2 initialGridItemPosition = gridItemMover.Position;
            gridItemMover.Position = newPosition;

            Assert.AreEqual(new Vector2(0, 0), initialGridItemPosition);
            Assert.AreEqual(newPosition, gridItemMover.Position);
        }

        [Test]
        public void CalculateGridItemWidthAndHeightInUnit()
        {
            float spriteWidthInPixel = 30;
            float spriteHeightInPixel = 40;
            float spritePixelPerUnit = 100;

            GridItem gridItem = CreateGridItemWithWidthAndHeightInPixelsAndPixelPerUnit(spriteWidthInPixel, spriteHeightInPixel, spritePixelPerUnit);

            Assert.AreEqual(0.3f, gridItem.WidthInUnit);
            Assert.AreEqual(0.4f, gridItem.HeightInUnit);
        }

        private GridItemMover CreateGridItemMover()
        {
            GridItemFactory gridItemFactory = CreateGridItemFactory();
            GameObject gridItemObject = gridItemFactory.Create();
            return gridItemObject.GetComponent<GridItemMover>();
        }

        private GridItem CreateGridItemWithWidthAndHeightInPixelsAndPixelPerUnit(float widthInPixels, float heightInPixels, float pixelPerUnit)
        {
            GridItemFactory gridItemFactory = CreateGridItemFactory();
            GameObject gridItemObject = gridItemFactory.Create();
            StubGridItemComponent stubGridItemComponent = gridItemObject.GetComponent<StubGridItemComponent>();
            stubGridItemComponent.SetWidthAndHeightInPixels(widthInPixels, heightInPixels);
            stubGridItemComponent.SetPixelPerUnit(pixelPerUnit);

            return stubGridItemComponent;
        }

        private GridItemFactory CreateGridItemFactory()
        {
            return new StubGridItemFactory();
        }
    }
}