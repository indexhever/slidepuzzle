using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

namespace Tests
{
    public class StubGridItemFactory : GridItemFactory
    {
        private GameObject gridItemObjectPrefab;

        public StubGridItemFactory()
        {
            gridItemObjectPrefab = LoadGridItemPrefab();
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

        private GameObject LoadGridItemPrefab()
        {
            return Resources.Load("StubGridItemPrefab") as GameObject;
        }
    }
}