using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Game
{
    public class SlotComponent : MonoBehaviour, IPointerClickHandler, Slot, Positioner
    {
        private Slot slot;
        private SlotSelection slotSelection;

        [SerializeField]
        private PieceDestinationControllerComponent pieceDestinationController;

        public PieceMover PieceMover => slot.PieceMover;

        public Vector2 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public void Construct(SlotSelection slotSelection)
        {
            this.slotSelection = slotSelection;
            slot = new SlotImplementation(slotSelection, pieceDestinationController, this);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Tocou no slot");
            Touch();
        }

        public void Touch()
        {
            slot.Touch();
        }
    }
}