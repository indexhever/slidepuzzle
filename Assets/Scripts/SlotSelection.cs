using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public interface SlotSelection
    {
        List<SlotSelectionServer> SelectedSlotSevers { get; }

        void SelectSlot(SlotSelectionServer slotSelectionServer);
    }
}