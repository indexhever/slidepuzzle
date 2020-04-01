using UnityEngine;
using System.Collections;

namespace Game
{
    public interface SlotSelectionServer
    {
        Vector2 Position { get; }

        bool CanMovePiece();
        bool CanReceivePiece();
        void TakePiece();
        void TakePiece(Vector2 pieceDestinePosition);
        void ReceivePiece();
    }
}