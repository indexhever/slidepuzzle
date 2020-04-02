using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Game
{
    public class SlotComponent : MonoBehaviour, IPointerClickHandler
    {
        private Slot slot;
        private SlotSelection slotSelection;

        public void Construct(SlotSelection slotSelection)
        {
            this.slotSelection = slotSelection;
            slot = new SlotImplementation(slotSelection);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Tocou no slot");
            //slot.Touch();
        }
    }
}