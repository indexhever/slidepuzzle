using UnityEngine;
using System.Collections;

namespace Game
{
    public interface PieceData
    {
        int PlaceInGrid { get; }
        string Text { get; }
    }
}