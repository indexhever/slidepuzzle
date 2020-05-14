using UnityEngine;
using System.Collections;
using Game;

namespace Tests
{
    public class StubPieceData : PieceData
    {
        public StubPieceData()
        {
            Text = "";
            PlaceInGrid = 0;
        }

        public StubPieceData(int placeInGrid)
        {
            Text = "";
            PlaceInGrid = placeInGrid;
        }

        public string Text { get; private set; }

        public int PlaceInGrid { get; private set; }
    }
}