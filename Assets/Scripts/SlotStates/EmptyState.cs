using UnityEngine;
using System.Collections;

namespace Game
{
    public class EmptyState : SlotState
    {
        public void ReceivePiece(PieceDestinationController pieceDestinationController, SlotSelectionServer slotSelectionServer)
        {
            pieceDestinationController.SetMovable();
            pieceDestinationController.Piece = slotSelectionServer.Piece;
            pieceDestinationController.TurnFixedAllNeighborButOne(slotSelectionServer);
        }

        public void TakePieceFromSlot(PieceDestinationController pieceDestinationController)
        {

        }

        public void TakePieceFromSlot(PieceDestinationController pieceDestinationController, Vector2 pieceDestinePosition)
        {
            
        }
    }
}