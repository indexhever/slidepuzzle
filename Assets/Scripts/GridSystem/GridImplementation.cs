using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GridImplementation : Grid
    {
        private int width;
        private int height;
        private GridItemFactory gridItemFactory;
        private float offsetBetweenGridItems;
        private GridItemPositioningStrategy positioningStrategy;

        public GridImplementation(int width, int height, GridItemFactory gridItemFactory, float offsetBetweenGridItems, Vector2 origin)
        {
            this.width = width;
            this.height = height;
            this.gridItemFactory = gridItemFactory;
            this.offsetBetweenGridItems = offsetBetweenGridItems;
            Origin = origin;
            GridItemObjects = new List<GameObject>();

            positioningStrategy = CreatePositioningStrategy();
            CreateGridItems();
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
        public List<GameObject> GridItemObjects { get; private set; }
        public Vector2 Origin { get; private set; }

        private GridItemPositioningStrategy CreatePositioningStrategy()
        {
            float girdItemWidthInUnit = gridItemFactory.GridItemWidthInUnit;
            float gridItemHeightInUnit = gridItemFactory.GridItemHeightInUnit;
            Vector2 gridItemMeasuresInUnit = new Vector2(girdItemWidthInUnit, gridItemHeightInUnit);

            return new CenterPositioningStrategy
            (
                Width,
                Height,
                Origin,
                gridItemMeasuresInUnit,
                offsetBetweenGridItems
            );
        }

        private void CreateGridItems()
        {
            for(int row = 0; row < Height; row++)
            {
                for(int column = 0; column < Width; column++)
                {
                    CreateGridItemToRowAndColumn(column, row);
                }
            }
        }

        private void CreateGridItemToRowAndColumn(int column, int row)
        {
            GameObject girdItemObject = gridItemFactory.Create();
            girdItemObject.name = row + "x" + column;
            GridItemMover gridItemMover = girdItemObject.GetComponent<GridItemMover>();

            gridItemMover.Position = positioningStrategy.GetGridItemPositionByRowAndColum(row, column);
            gridItemMover.SetupRownAndColumn(row, column);
            GridItemObjects.Add(girdItemObject);
        }

        public List<GameObject> GetItemNeighbors(GridItemMover gridMover)
        {
            List<GameObject> itemNeighbors = new List<GameObject>();

            // Get left item
            int leftRow = gridMover.Row;
            int leftColumn = gridMover.Column - 1;
            if (IsInRowBounds(leftRow) && IsInColumnBounds(leftColumn))
                itemNeighbors.Add(GetGridItemObjectByRowColumn(leftRow, leftColumn));

            // Get up item
            int upRow = gridMover.Row - 1;
            int upColumn = gridMover.Column;
            if (IsInRowBounds(upRow) && IsInColumnBounds(upColumn))
                itemNeighbors.Add(GetGridItemObjectByRowColumn(upRow, upColumn));

            // Get right item
            int rightRow = gridMover.Row;
            int rightColumn = gridMover.Column + 1;
            if (IsInRowBounds(rightRow) && IsInColumnBounds(rightColumn))
                itemNeighbors.Add(GetGridItemObjectByRowColumn(rightRow, rightColumn));

            // Get bottom item
            int bottomRow = gridMover.Row + 1;
            int bottomColumn = gridMover.Column;
            if (IsInRowBounds(bottomRow) && IsInColumnBounds(bottomColumn))
                itemNeighbors.Add(GetGridItemObjectByRowColumn(bottomRow, bottomColumn));

            return itemNeighbors;
        }

        private bool IsInRowBounds(int row)
        {
            return row < Height && row >= 0;
        }

        private bool IsInColumnBounds(int column)
        {
            return column < Width && column >= 0;
        }

        public GameObject GetGridItemObjectByRowColumn(int row, int column)
        {
            return GridItemObjects[row * Width + column];
        }
    }
}