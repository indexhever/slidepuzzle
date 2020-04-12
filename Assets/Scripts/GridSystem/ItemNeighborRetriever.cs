using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public interface ItemNeighborRetriever
    {
        List<GameObject> GetItemNeighbors(GridItemMover item);
    }
}