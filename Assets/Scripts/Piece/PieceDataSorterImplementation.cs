using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public class PieceDataSorterImplementation : PieceDataSorter
    {
        private List<PieceData> pieceDataList;
        private int currentRandomIndex;

        public PieceDataSorterImplementation(List<PieceData> pieceDataList)
        {
            this.pieceDataList = pieceDataList;
        }

        public PieceData GetRandomPieceData()
        {
            if (pieceDataList.Count == 0)
                return new NullPieceData();

            currentRandomIndex = Random.Range(0, pieceDataList.Count);

            PieceData newPieceData = pieceDataList[currentRandomIndex];
            pieceDataList.RemoveAt(currentRandomIndex);

            return newPieceData;
        }
    }
}