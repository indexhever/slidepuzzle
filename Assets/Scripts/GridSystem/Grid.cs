using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface Grid
    {
        int Width { get; }
        int Height { get; }
        Vector2 Position { get; }
        List<GameObject> GridItemObjects { get; }
        Vector2 Origin { get; }

        GameObject GetGridItemObjectByRowColumn(int row, int column);
    }
}
