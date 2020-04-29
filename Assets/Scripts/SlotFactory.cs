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
        [SerializeField]
        private GridComponent grid;

        public override float GridItemHeightInUnit => gridItemFactory.GridItemHeightInUnit;
        public override float GridItemWidthInUnit => gridItemFactory.GridItemWidthInUnit;

        private void Start()
        {
            Construct();
        }

        public void Construct()
        {
            gridItemFactory = new SlotFactoryImplementation(slotPrefab, slotSelectionComponent, pieceFactory, grid);
        }

        public override GameObject Create()
        {
            return gridItemFactory.Create();             
        }
    }
}