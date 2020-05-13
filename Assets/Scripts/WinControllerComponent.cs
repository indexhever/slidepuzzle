using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public class WinControllerComponent : MonoBehaviour, WinController
    {
        private WinController winController;
        private List<PiecePlaceInGrid> correctlyPositionedPieces;

        public void Construct(int maximumPiecesToPlace, WinEventController winEventController)
        {
            correctlyPositionedPieces = new List<PiecePlaceInGrid>();
            winController = new WinControllerImplementation(correctlyPositionedPieces, winEventController, maximumPiecesToPlace);
        }

        public void AddCorrectlyPositionedPiece(PiecePlaceInGrid piece)
        {
            winController.AddCorrectlyPositionedPiece(piece);
        }

        public void RemoveCorrectlyPositionedPiece(PiecePlaceInGrid piece)
        {
            winController.RemoveCorrectlyPositionedPiece(piece);
        }
    }
}