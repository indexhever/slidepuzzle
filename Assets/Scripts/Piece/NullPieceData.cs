using UnityEngine;
using System.Collections;

namespace Game
{
    public class NullPieceData : PieceData
    {
        public string Text => "No Data";

        public int PlaceInGrid => 0;
    }
}