using UnityEngine;
using System.Collections;

namespace Game
{
    public class PieceDestinationControllerImplementation : PieceDestinationController
    {
        private readonly SlotState EMPTY_STATE;
        private readonly SlotState MOVABLE_STATE;
        private readonly SlotState FIXED_STATE;
        private PieceTranslationController pieceTranslationController;

        public PieceDestinationControllerImplementation()
        {
            EMPTY_STATE = new EmptyState();
            MOVABLE_STATE = new MovableState();
            FIXED_STATE = new FixedState();
            SetFixed();
        }

        public PieceDestinationControllerImplementation(PieceTranslationController pieceTranslationController)
        {
            this.pieceTranslationController = pieceTranslationController;
            EMPTY_STATE = new EmptyState();
            MOVABLE_STATE = new MovableState();
            FIXED_STATE = new FixedState();
            SetFixed();
        }

        public SlotState State { get; set; }

        public Vector2 Position
        {
            get
            {
                return pieceTranslationController.CurrentPiecePosition;
            }
        }

        public void ReceivePiece()
        {
            State.ReceivePiece(this);
        }

        public void TakePiece()
        {
            State.TakePieceFromSlot(this);
        }

        public void TakePiece(Vector2 pieceDestinePosition)
        {
            State.TakePieceFromSlot(this, pieceDestinePosition);
        }

        public void SetEmpty()
        {
            State = EMPTY_STATE;
        }

        public void SetMovable()
        {
            State = MOVABLE_STATE;
        }

        public void SetFixed()
        {
            State = FIXED_STATE;
        }

        public bool CanMovePiece()
        {
            return State == MOVABLE_STATE;
        }

        public bool CanReceivePiece()
        {
            return State == EMPTY_STATE;
        }

        public Vector2 GetPosition()
        {
            throw new System.NotImplementedException();
        }

        public void MovePieceToDestinePosition(Vector2 destinePosition)
        {
            pieceTranslationController.TranslateToPosition(destinePosition);
        }
    }
}