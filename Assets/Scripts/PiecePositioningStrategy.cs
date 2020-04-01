using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface PiecePositioningStrategy
    {
        Vector2 GetPiecePositionByRowAndColum(int row, int column);
    }
}
