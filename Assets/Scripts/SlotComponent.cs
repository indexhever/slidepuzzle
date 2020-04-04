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

        // TODO: pieceDestinationController vai ser um componente que vai controlar a posição da peça atual do slote
        // TODO: positioner é o controlador de posição do slot
        // TODO: quando uma peça for pra outro slot, o controlador de peça deve controlar essa nova peça
        // TODO: slot vai ter a factory de peça para poder criá-la e colocar como filha dele na posição dele
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