using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PieceFactoryImplementation : PieceFactory
    {
        private GameObject pieceObjectPrefab;

        public PieceFactoryImplementation(GameObject pieceObjectPrefab)
        {
            this.pieceObjectPrefab = pieceObjectPrefab;
            Piece piece = pieceObjectPrefab.GetComponent<Piece>();
            PieceWidthInUnit = piece.WidthInUnit;
            PieceHeightInUnit = piece.HeightInUnit;
        }

        public float PieceWidthInUnit
        {
            get; private set;
        }
        public float PieceHeightInUnit
        {
            get; private set;
        }

        public GameObject Create()
        {
            GameObject pieceMoverObject = GameObject.Instantiate(pieceObjectPrefab);
            return pieceMoverObject;
        }
    }
}