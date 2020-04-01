using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface Piece
    {
        float WidthInUnit { get; }
        float HeightInUnit { get; }
    }
}