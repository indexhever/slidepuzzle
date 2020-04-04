using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SlotFactoryImplementation : GridItemFactory
    {
        private GameObject gridItemObjectPrefab;
        private SlotSelection slotSelection;

        public SlotFactoryImplementation(GameObject gridItemObjectPrefab, SlotSelection slotSelection)
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
            GameObject gridItemObject = GameObject.Instantiate(gridItemObjectPrefab);
            SlotComponent slotComponent = gridItemObject.GetComponent<SlotComponent>();
            slotComponent.Construct(slotSelection);
            return gridItemObject;
        }
    }
}