using UnityEngine;
using System.Collections;
using Game;

namespace Tests
{
    public class StubSlotSelectionServer : SlotSelectionServer
    {
        private bool canMovePiece;
        private bool canReceivePiece;

        public StubSlotSelectionServer(bool canMovePiece, bool canReceivePiece)
        {
            this.canMovePiece = canMovePiece;
            this.canReceivePiece = canReceivePiece;
        }

        public bool CanMovePieceWasCalled { get; private set; }
        public bool CanReceivePieceWasCalled { get; private set; }
        public bool TakePieceWasCalled { get; internal set; }
        public bool ReceivePieceWasCalled { get; internal set; }

        public Vector2 Position => Vector2.zero;

        public bool CanMovePiece()
        {
            CanMovePieceWasCalled = true;
            return canMovePiece;
        }

        public bool CanReceivePiece()
        {
            CanReceivePieceWasCalled = true;
            return canReceivePiece;
        }

        public void ReceivePiece()
        {
            ReceivePieceWasCalled = true;
        }

        public void TakePiece()
        {
            TakePieceWasCalled = true;
        }

        public void TakePiece(Vector2 pieceDestinePosition)
        {
            TakePieceWasCalled = true;
        }
    }
}