using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SlotFactoryImplementation : GridItemFactory
    {
        private GameObject gridItemObjectPrefab;
        private SlotSelection slotSelection;
        private GridItemFactory pieceFactory;

        public SlotFactoryImplementation(GameObject gridItemObjectPrefab, SlotSelection slotSelection, GridItemFactory pieceFactory)
        {
            this.gridItemObjectPrefab = gridItemObjectPrefab;
            GridItem gridItem = gridItemObjectPrefab.GetComponent<GridItem>();
            GridItemWidthInUnit = gridItem.WidthInUnit;
            GridItemHeightInUnit = gridItem.HeightInUnit;
            this.pieceFactory = pieceFactory;
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
            /*
            GameObject gridItemObject = GameObject.Instantiate(gridItemObjectPrefab);
            SlotComponent slotComponent = gridItemObject.GetComponent<SlotComponent>();
            slotComponent.Construct(slotSelection);
            return gridItemObject;
            */

            GameObject slotObject = InstantiateSlotObject();
            GameObject pieceObject = pieceFactory.Create();
            pieceObject.transform.position = slotObject.transform.position;
            pieceObject.transform.SetParent(slotObject.transform);
            SlotComponent slotComponent = slotObject.GetComponent<SlotComponent>();
            slotComponent.Construct(slotSelection);

            PieceDestinationControllerComponent pieceDestinationController = slotObject.GetComponent<PieceDestinationControllerComponent>();
            PieceTranslationControllerComponent pieceTranslationController = pieceObject.GetComponent<PieceTranslationControllerComponent>();

            pieceDestinationController.Construct(pieceTranslationController);

            return slotObject;
        }

        private GameObject InstantiateSlotObject()
        {
            return GameObject.Instantiate(gridItemObjectPrefab);
        }
    }
}