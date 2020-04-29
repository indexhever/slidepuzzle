using UnityEngine;
using System.Collections;

namespace Game
{
    public class MovableState : SlotState
    {
        public void ReceivePiece(PieceDestinationController pieceDestinationController, SlotSelectionServer slotSelectionServer)
        {
            
        }

        public void TakePieceFromSlot(PieceDestinationController pieceDestinationController)
        {
            pieceDestinationController.SetEmpty();
        }

        public void TakePieceFromSlot(PieceDestinationController pieceDestinationController, Vector2 pieceDestinePosition)
        {
            pieceDestinationController.SetEmpty();
            pieceDestinationController.MovePieceToDestinePosition(pieceDestinePosition);
            pieceDestinationController.Clean();
        }
    }
}