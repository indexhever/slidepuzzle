using UnityEngine;
using System.Collections;

namespace Game
{
    public interface SlotState
    {
        void ReceivePiece(PieceDestinationController pieceDestinationController);
        void TakePieceFromSlot(PieceDestinationController pieceDestinationController);
        void TakePieceFromSlot(PieceDestinationController pieceDestinationController, Vector2 pieceDestinePosition);
    }
}
