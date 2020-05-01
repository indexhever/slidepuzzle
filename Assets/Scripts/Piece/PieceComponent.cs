using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PieceComponent : MonoBehaviour
    {
        [SerializeField]
        private PieceDataImplementation pieceDataImplementation;

        public void Construct(PieceData pieceData)
        {
            pieceDataImplementation = pieceData as PieceDataImplementation;
        }
    }
}