using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface PieceFactory
    {
        float PieceWidthInUnit { get; }
        float PieceHeightInUnit { get; }
        GameObject Create();
    }
}