using UnityEngine;
using System.Collections;

namespace Game
{
    public interface PieceDestinationController : SlotSelectionServer
    {
        SlotState State { get; set; }

        void SetEmpty();
        void SetMovable();
        void SetFixed();
        // Actions
        Vector2 GetPosition();
        void MovePieceToDestinePosition(Vector2 destinePosition);
    }
}