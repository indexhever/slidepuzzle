using UnityEngine;
using System.Collections;
using Game;
using System.Collections.Generic;

namespace Tests
{
    public class StubItemNeighborRetriever : ItemNeighborRetriever
    {
        private ItemNeighborRetriever itemNeighborRetriever;

        public void Initialize(ItemNeighborRetriever itemNeighborRetriever)
        {
            this.itemNeighborRetriever = itemNeighborRetriever;
        }

        public List<GameObject> GetItemNeighbors(GridItemMover item)
        {
            return itemNeighborRetriever.GetItemNeighbors(item);
        }
    }
}