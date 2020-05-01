using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public class PieceFactoryImplementation : PieceFactory
    {
        private GameObject piecePrefab;
        private PieceDataSorter pieceSorter;

        public PieceFactoryImplementation(GameObject piecePrefab)
        {
            this.piecePrefab = piecePrefab;
            this.pieceSorter = new NullPieceDataSorter();
            GridItem gridItem = piecePrefab.GetComponent<GridItem>();
            GridItemWidthInUnit = gridItem.WidthInUnit;
            GridItemHeightInUnit = gridItem.HeightInUnit;
        }

        public PieceFactoryImplementation(GameObject piecePrefab, PieceDataSorter pieceSorter)
        {
            this.piecePrefab = piecePrefab;
            this.pieceSorter = pieceSorter;
            GridItem gridItem = this.piecePrefab.GetComponent<GridItem>();
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

        public GameObject Create(PieceData pieceData)
        {
            GameObject gridItemObject = Create();
            ConstructPiece(pieceData, gridItemObject);

            return gridItemObject;
        }

        public GameObject Create()
        {
            GameObject pieceObject = CreateGameObject();
            ConstructPiece(pieceSorter.GetRandomPieceData(), pieceObject);

            return pieceObject;
        }

        private GameObject CreateGameObject()
        {
            return GameObject.Instantiate(piecePrefab);
        }

        private static void ConstructPiece(PieceData pieceData, GameObject gridItemObject)
        {
            PieceComponent pieceComponent = gridItemObject.GetComponent<PieceComponent>();
            pieceComponent.Construct(pieceData);
        }
    }
}