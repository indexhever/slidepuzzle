using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GridItemFactoryImplementation : GridItemFactory
    {
        private GameObject gridItemObjectPrefab;

        public GridItemFactoryImplementation(GameObject gridItemObjectPrefab)
        {
            this.gridItemObjectPrefab = gridItemObjectPrefab;
            GridItem gridItem = gridItemObjectPrefab.GetComponent<GridItem>();
            GridItemWidthInUnit = gridItem.WidthInUnit;
            GridItemHeightInUnit = gridItem.HeightInUnit;
        }

        public float GridItemWidthInUnit
        {
            get; private set;
        }
        public float GridItemHeightInUnit
        {
            get; private set;
        }

        public GameObject Create()
        {
            GameObject gridItemMoverObject = GameObject.Instantiate(gridItemObjectPrefab);
            return gridItemMoverObject;
        }
    }
}