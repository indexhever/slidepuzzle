using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace Game
{
    public class SlotSelectionImplementation : SlotSelection
    {
        private int MAXIMUN_AMOUNT_OF_SLOTS_SELECTED = 2;

        public SlotSelectionImplementation()
        {
            SelectedSlotSevers = new List<SlotSelectionServer>();
        }

        public List<SlotSelectionServer> SelectedSlotSevers { get; private set; }

        public void SelectSlot(SlotSelectionServer slotSelectionServer)
        {
            SelectedSlotSevers.Add(slotSelectionServer);

            if (SelectedSlotSevers.Count < MAXIMUN_AMOUNT_OF_SLOTS_SELECTED)
                return;

            bool firstCanMovePiece = SelectedSlotSevers[0].CanMovePiece();
            bool secondCanReceivePiece = SelectedSlotSevers[1].CanReceivePiece();

            if(firstCanMovePiece && secondCanReceivePiece)
            {
                SelectedSlotSevers[1].ReceivePieceFromSlot(SelectedSlotSevers[0]);
                SelectedSlotSevers[0].TakePieceToPosition(SelectedSlotSevers[1].Position);                
            }

            ResetSelectedSlotServers();
        }

        private void ResetSelectedSlotServers()
        {
            SelectedSlotSevers.Clear();
        }
    }
}