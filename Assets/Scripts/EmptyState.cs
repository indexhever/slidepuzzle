﻿using UnityEngine;
using System.Collections;

namespace Game
{
    public class EmptyState : SlotState
    {
        public void ReceivePiece(PieceDestinationController pieceDestinationController)
        {
            pieceDestinationController.SetMovable();
        }

        public void TakePieceFromSlot(PieceDestinationController pieceDestinationController)
        {

        }

        public void TakePieceFromSlot(PieceDestinationController pieceDestinationController, Vector2 pieceDestinePosition)
        {
            
        }
    }
}