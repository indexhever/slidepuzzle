using UnityEngine;
using System.Collections;

namespace Game
{
    public class NullPieceDataSorter : PieceDataSorter
    {
        private readonly PieceData NULL_PIECE_DATA = new NullPieceData();

        public PieceData GetRandomPieceData()
        {
            return NULL_PIECE_DATA;
        }
    }
}