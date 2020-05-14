using UnityEngine;
using System.Collections;
using Game;

namespace Tests
{
    public class StubSlotFactory : GridItemFactory
    {
        private GridItemFactory gridItemFactory;
        private GridItemFactory pieceFactory;
        private SlotSelection slotSelection;

        public float GridItemWidthInUnit => 2;

        public float GridItemHeightInUnit => 2;

        public StubSlotFactory(GameObject slotPrefab, SlotSelection slotSelection, ItemNeighborRetriever itemNeighborRetriever)
        {
            gridItemFactory = new SlotFactoryImplementation(slotPrefab, slotSelection, pieceFactory, itemNeighborRetriever, new StubWinController());
        }

        public GameObject Create()
        {
            GameObject slotObject = gridItemFactory.Create();
            GameObject pieceObject = pieceFactory.Create();
            pieceObject.transform.position = slotObject.transform.position;
            pieceObject.transform.SetParent(slotObject.transform);
            SlotComponent slotComponent = slotObject.GetComponent<SlotComponent>();
            slotComponent.Construct(slotSelection);

            PieceDestinationControllerComponent pieceDestinationController = slotObject.GetComponent<PieceDestinationControllerComponent>();
            PieceTranslationControllerComponent pieceTranslationController = pieceObject.GetComponent<PieceTranslationControllerComponent>();

            pieceDestinationController.Construct(pieceTranslationController, new StubWinController());

            return slotObject;
        }
    }
}