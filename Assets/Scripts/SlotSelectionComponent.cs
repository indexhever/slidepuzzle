using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public class SlotSelectionComponent : MonoBehaviour, SlotSelection
    {
        private SlotSelection slotSelection;

        public List<SlotSelectionServer> SelectedSlotSevers => slotSelection.SelectedSlotSevers;

        private void Start()
        {
            Construct();
        }

        private void Construct()
        {
            slotSelection = new SlotSelectionImplementation();
        }

        public void SelectSlot(SlotSelectionServer slotSelectionServer)
        {
            slotSelection.SelectSlot(slotSelectionServer);
        }

        public void SelectSlot(SlotSelectionServer slotSelectionServer, PieceDestinationController pieceDestinationController)
        {
            slotSelection.SelectSlot(slotSelectionServer, pieceDestinationController);
        }
    }
}