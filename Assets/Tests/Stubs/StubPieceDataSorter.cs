using UnityEngine;
using System.Collections;
using Game;

namespace Tests
{
    public class StubPieceDataSorter : PieceDataSorter
    {
        public PieceData pieceData;

        public StubPieceDataSorter()
        {
            pieceData = new NullPieceData();
        }

        public PieceData GetRandomPieceData()
        {
            return pieceData;
        }
    }
}