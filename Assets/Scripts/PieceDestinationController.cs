using UnityEngine;
using System.Collections;

namespace Game
{
    public interface PieceDestinationController : SlotSelectionServer
    {
        SlotState State { get; set; }

        // Events
        void SetEmpty();
        void SetMovable();
        void SetFixed();
        // Actions
        Vector2 GetPosition();
        void MovePieceToDestinePosition(Vector2 destinePosition);
        void Clean();
        void TurnFixedAllNeighborButOne(SlotSelectionServer givenSlotSelectionServer);
    }
}