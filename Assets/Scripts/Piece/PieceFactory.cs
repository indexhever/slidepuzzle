using UnityEngine;
using System.Collections;

namespace Game
{
    public interface PieceFactory : GridItemFactory
    {
        GameObject Create(PieceData pieceData);
    }
}

