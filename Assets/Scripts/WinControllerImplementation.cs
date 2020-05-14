using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public class WinControllerImplementation : WinController
    {
        private List<PiecePlaceInGrid> correctlyPositionedPieces;
        private WinEventController winEventController;
        private int maximumPiecesToPlace;

        public WinControllerImplementation(List<PiecePlaceInGrid> correctlyPositionedPieces, WinEventController winEventController, int maximumPiecesToPlace)
        {
            this.correctlyPositionedPieces = correctlyPositionedPieces;
            this.winEventController = winEventController;
            this.maximumPiecesToPlace = maximumPiecesToPlace;
        }

        public void AddCorrectlyPositionedPiece(PiecePlaceInGrid piece)
        {
            correctlyPositionedPieces.Add(piece);
            if (correctlyPositionedPieces.Count == maximumPiecesToPlace)
                winEventController.TriggerEvent();
        }

        public void RemoveCorrectlyPositionedPiece(PiecePlaceInGrid piece)
        {
            correctlyPositionedPieces.Remove(piece);
        }
    }
}