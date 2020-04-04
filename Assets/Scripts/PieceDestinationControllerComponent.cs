using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PieceDestinationControllerComponent : MonoBehaviour, PieceDestinationController
    {
        private PieceDestinationController pieceDestinationController;

        public SlotState State
        {
            get
            {
                return pieceDestinationController.State;
            }
            set
            {
                pieceDestinationController.State = value;
            }
        }

        public Vector2 Position => pieceDestinationController.Position;

        public void Construct(PieceTranslationController pieceTranslationController)
        {
            pieceDestinationController = new PieceDestinationControllerImplementation(pieceTranslationController);
        }

        public bool CanMovePiece()
        {
            return pieceDestinationController.CanMovePiece();
        }

        public bool CanReceivePiece()
        {
            return pieceDestinationController.CanReceivePiece();
        }

        public Vector2 GetPosition()
        {
            return pieceDestinationController.GetPosition();
        }

        public void MovePieceToDestinePosition(Vector2 destinePosition)
        {
            pieceDestinationController.MovePieceToDestinePosition(destinePosition);
        }

        public void ReceivePiece()
        {
            pieceDestinationController.ReceivePiece();
        }

        public void SetEmpty()
        {
            pieceDestinationController.SetEmpty();
        }

        public void SetMovable()
        {
            pieceDestinationController.SetMovable();
        }

        public void TakePiece()
        {
            pieceDestinationController.TakePiece();
        }

        public void TakePiece(Vector2 pieceDestinePosition)
        {
            pieceDestinationController.TakePiece(pieceDestinePosition);
        }
    }
}