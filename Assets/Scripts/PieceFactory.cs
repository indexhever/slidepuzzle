using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PieceFactory : GridItemFactoryComponent
    {
        private GridItemFactory gridItemFactory;

        [SerializeField]
        private GameObject piecePrefab;

        public override float GridItemWidthInUnit => gridItemFactory.GridItemWidthInUnit;
        public override float GridItemHeightInUnit => gridItemFactory.GridItemHeightInUnit;

        private void Start()
        {
            Construct();
        }

        private void Construct()
        {
            gridItemFactory = new PieceFactoryImplementation(piecePrefab);
        }

        public override GameObject Create()
        {
            return gridItemFactory.Create();
        }
    }
}