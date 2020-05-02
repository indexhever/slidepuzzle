using UnityEngine;
using System.Collections;

namespace Game
{
    public interface WinController
    {
        void AddCorrectlyPositionedPiece(PiecePlaceInGrid piece);
        void RemoveCorrectlyPositionedPiece(PiecePlaceInGrid piece);
    }
}