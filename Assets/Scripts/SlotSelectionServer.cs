using UnityEngine;
using System.Collections;

namespace Game
{
    public interface SlotSelectionServer
    {
        Vector2 Position { get; }
        GameObject Piece { get; set; }
        bool IsFixed { get; }
        PieceDestinationController PieceDestinationController { get; }

        bool CanMovePiece();
        bool CanReceivePiece();
        void TakePiece();
        void TakePieceToPosition(Vector2 pieceDestinePosition);
        void ReceivePieceFromSlot(SlotSelectionServer slotSelectionServer);
    }
}