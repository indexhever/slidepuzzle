using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PieceFactoryComponent : GridItemFactoryComponent
    {
        private GridItemFactory gridItemFactory;

        [SerializeField]
        private GameObject piecePrefab;
        [SerializeField]
        private PieceDataSorterComponent pieceDataSorter;

        public override float GridItemWidthInUnit => gridItemFactory.GridItemWidthInUnit;
        public override float GridItemHeightInUnit => gridItemFactory.GridItemHeightInUnit;
        
        public void Construct()
        {
            pieceDataSorter.Construct();
            gridItemFactory = new PieceFactoryImplementation(piecePrefab, pieceDataSorter);
        }

        public override GameObject Create()
        {
            return gridItemFactory.Create();
        }
    }
}