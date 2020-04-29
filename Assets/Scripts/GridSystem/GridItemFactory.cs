using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public interface GridItemFactory
    {
        float GridItemWidthInUnit { get; }
        float GridItemHeightInUnit { get; }
        GameObject Create();
    }
}