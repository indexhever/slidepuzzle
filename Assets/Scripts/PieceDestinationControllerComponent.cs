using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PieceDestinationControllerComponent : MonoBehaviour, PieceDestinationController
    {
        private PieceDestinationController pieceDestinationController;

        [SerializeField]
        private GridItemComponent gridItemComponent;

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

        public GameObject Piece
        {
            get
            {
                return pieceDestinationController.Piece;
            }
            set
            {
                pieceDestinationController.Piece = value;
            }
        }

        public void Construct(PieceTranslationController pieceTranslationController)
        {
            pieceDestinationController = new PieceDestinationControllerImplementation(pieceTranslationController, gridItemComponent);
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

        public void ReceivePieceFromSlot(SlotSelectionServer slotSelectionServer)
        {
            pieceDestinationController.ReceivePieceFromSlot(slotSelectionServer);
        }

        public void SetEmpty()
        {
            pieceDestinationController.SetEmpty();
        }

        public void SetMovable()
        {
            pieceDestinationController.SetMovable();
        }

        public void SetFixed()
        {
            pieceDestinationController.SetFixed();
        }

        public void TakePiece()
        {
            pieceDestinationController.TakePiece();
        }

        public void TakePieceToPosition(Vector2 pieceDestinePosition)
        {
            pieceDestinationController.TakePieceToPosition(pieceDestinePosition);
        }

        public void Clean()
        {
            pieceDestinationController.Clean();
        }
    }
}