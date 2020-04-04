using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface GridItemPositioningStrategy
    {
        Vector2 GetGridItemPositionByRowAndColum(int row, int column);
    }
}
