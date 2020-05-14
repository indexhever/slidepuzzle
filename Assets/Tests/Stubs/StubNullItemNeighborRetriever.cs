using UnityEngine;
using System.Collections;
using Game;
using System.Collections.Generic;

namespace Tests
{
    public class StubNullItemNeighborRetriever : ItemNeighborRetriever
    {
        public List<GameObject> GetItemNeighbors(GridItemMover item)
        {
            return new List<GameObject>();
        }
    }
}