using UnityEngine;
using System.Collections;

namespace Game
{
    public class PieceFactoryImplementation : GridItemFactory
    {
        private GameObject gridItemObjectPrefab;

        public PieceFactoryImplementation(GameObject gridItemObjectPrefab)
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
            PieceComponent pieceComponent = gridItemObject.GetComponent<PieceComponent>();
            pieceComponent.Construct();
            return gridItemObject;
        }
    }
}