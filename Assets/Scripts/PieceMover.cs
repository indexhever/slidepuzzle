using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface PieceMover
    {
        int Row { get; }
        int Column { get; }
        Vector2 Position { get; set; }

        void SetupRownAndColumn(int row, int column);
    }
}