using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface GridItemMover : PiecePlaceInGrid
    {
        int Row { get; }
        int Column { get; }
        Vector2 Position { get; set; }
        Transform Transform { get; }

        void SetupRownAndColumn(int place, int row, int column);
        List<GameObject> GetNeighbors();
    }
}