using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public class PieceDataSorterComponent : MonoBehaviour, PieceDataSorter
    {
        private PieceDataSorter pieceDataSorter;

        [SerializeField]
        private List<PieceDataImplementation> pieceDatas;

        public void Construct()
        {
            List<PieceData> pieceDataList = new List<PieceData>(pieceDatas);
            pieceDataSorter = new PieceDataSorterImplementation(pieceDataList);
        }

        public PieceData GetRandomPieceData()
        {
            return pieceDataSorter.GetRandomPieceData();
        }
    }
}