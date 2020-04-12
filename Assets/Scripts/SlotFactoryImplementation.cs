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
        private ItemNeighborRetriever itemNeighborRetriever;

        public SlotFactoryImplementation(GameObject gridItemObjectPrefab, SlotSelection slotSelection, GridItemFactory pieceFactory, ItemNeighborRetriever itemNeighborRetriever)
        {
            this.gridItemObjectPrefab = gridItemObjectPrefab;
            this.slotSelection = slotSelection;
            this.pieceFactory = pieceFactory;
            this.itemNeighborRetriever = itemNeighborRetriever;

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
            GameObject slotObject = InstantiateSlotObject();
            GameObject pieceObject = pieceFactory.Create();
            pieceObject.transform.position = slotObject.transform.position;
            pieceObject.transform.SetParent(slotObject.transform);
            SlotComponent slotComponent = slotObject.GetComponent<SlotComponent>();
            slotComponent.Construct(slotSelection);

            PieceDestinationControllerComponent pieceDestinationController = slotObject.GetComponent<PieceDestinationControllerComponent>();
            PieceTranslationControllerComponent pieceTranslationController = pieceObject.GetComponent<PieceTranslationControllerComponent>();
            GridItemComponent gridItemComponent = slotObject.GetComponent<GridItemComponent>();
            
            pieceDestinationController.Construct(pieceTranslationController);
            gridItemComponent.Construct(itemNeighborRetriever);

            return slotObject;
        }

        private GameObject InstantiateSlotObject()
        {
            return GameObject.Instantiate(gridItemObjectPrefab);
        }
    }
}