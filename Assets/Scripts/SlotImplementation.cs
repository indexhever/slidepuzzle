using UnityEngine;
using System.Collections;

namespace Game
{
    public class SlotImplementation : Slot, SlotSelectionServer
    {
        private SlotSelection slotSelection;
        private PieceDestinationController pieceDestinationController;
        private Positioner positioner;
        private PieceMover pieceMover;

        public SlotImplementation(SlotSelection slotSelection)
        {
            this.slotSelection = slotSelection;
        }

        public SlotImplementation(SlotSelection slotSelection, Positioner positioner)
        {
            this.slotSelection = slotSelection;
            this.positioner = positioner;
        }

        public SlotImplementation(SlotSelection slotSelection, PieceDestinationController pieceDestinationController)
        {
            this.slotSelection = slotSelection;
            this.pieceDestinationController = pieceDestinationController;
        }

        public SlotImplementation(SlotSelection slotSelection, PieceDestinationController pieceDestinationController, Positioner positioner)
        {
            this.slotSelection = slotSelection;
            this.pieceDestinationController = pieceDestinationController;
            this.positioner = positioner;
        }

        public Vector2 Position
        {
            get
            {
                return positioner.Position;
            }
        }

        public PieceMover PieceMover => pieceMover;

        public GameObject Piece
        {
            get => pieceDestinationController.Piece;
            set => pieceDestinationController.Piece = value;
        }

        public bool CanMovePiece()
        {
            return pieceDestinationController.CanMovePiece();
        }

        public bool CanReceivePiece()
        {
            return pieceDestinationController.CanReceivePiece();
        }

        public void ReceivePieceFromSlot(SlotSelectionServer slotSelectionServer)
        {
            pieceDestinationController.ReceivePieceFromSlot(slotSelectionServer);
        }

        public void TakePiece()
        {
            pieceDestinationController.TakePiece();
        }

        public void TakePieceToPosition(Vector2 pieceDestinePosition)
        {
            pieceDestinationController.TakePieceToPosition(pieceDestinePosition);
        }

        public void Touch()
        {
            slotSelection.SelectSlot(this);
        }
    }
}