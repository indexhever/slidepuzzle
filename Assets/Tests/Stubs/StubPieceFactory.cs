using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game;

namespace Tests
{
    public class StubPieceFactory : PieceFactory
    {
        private GameObject pieceObjectPrefab;

        public StubPieceFactory()
        {
            pieceObjectPrefab = LoadPiecePrefab();
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

        private GameObject LoadPiecePrefab()
        {
            return Resources.Load("StubPiecePrefab") as GameObject;
        }
    }
}