using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SlotSortingImplementation : SlotSorting
    {
        private Grid slotGrid;

        public SlotSortingImplementation(Grid slotGrid)
        {
            this.slotGrid = slotGrid;
        }

        // TODO: deletar piece do slot achado
        public GameObject GetRandomEmptySlotObject()
        {
            int randomRow = Random.Range(0, slotGrid.Height);
            int randomColumn = Random.Range(0, slotGrid.Width);
            GameObject randomSlot = slotGrid.GetGridItemObjectByRowColumn(randomRow, randomColumn);
            PieceDestinationController pieceDestinationController = randomSlot.GetComponent<PieceDestinationController>();
            pieceDestinationController.SetEmpty();

            return randomSlot;
        }
    }
}