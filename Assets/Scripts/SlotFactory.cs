using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SlotFactory : GridItemFactoryComponent
    {
        private GridItemFactory gridItemFactory;

        [SerializeField]
        private GameObject slotPrefab;
        [SerializeField]
        private SlotSelectionComponent slotSelectionComponent;
        [SerializeField]
        private GridItemFactoryComponent pieceFactory;

        public override float GridItemHeightInUnit => gridItemFactory.GridItemHeightInUnit;
        public override float GridItemWidthInUnit => gridItemFactory.GridItemWidthInUnit;

        private void Start()
        {
            Construct();
        }

        public void Construct()
        {
            gridItemFactory = new SlotFactoryImplementation(slotPrefab, slotSelectionComponent, pieceFactory);
        }

        public override GameObject Create()
        {
            /*
            GameObject slotObject = gridItemFactory.Create();
            GameObject pieceObject = pieceFactory.Create();
            pieceObject.transform.position = slotObject.transform.position;
            pieceObject.transform.SetParent(slotObject.transform);
            SlotComponent slotComponent = slotObject.GetComponent<SlotComponent>();
            slotComponent.Construct(slotSelectionComponent);

            PieceDestinationControllerComponent pieceDestinationController = slotObject.GetComponent<PieceDestinationControllerComponent>();
            PieceTranslationControllerComponent pieceTranslationController = pieceObject.GetComponent<PieceTranslationControllerComponent>();

            pieceDestinationController.Construct(pieceTranslationController);
            return slotObject;
             */
            return gridItemFactory.Create();            
        }
    }
}