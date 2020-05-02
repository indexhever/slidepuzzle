using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;
using System;

namespace Tests
{
    public class WinConditionTest
    {
        [Test]
        public void AddCorrectlyPositionedPiece()
        {
            List<PiecePlaceInGrid> correctlyPositionedPieces = CreateCorrectPositionedPieceList();
            WinController winController = CreateWinController(correctlyPositionedPieces);
            PiecePlaceInGrid piece = CreatePiecePlaceInGrid();

            winController.AddCorrectlyPositionedPiece(piece);

            Assert.Contains(piece, correctlyPositionedPieces);
        }

        [Test]
        public void RemoveCorrectlyPositionedPiece()
        {
            List<PiecePlaceInGrid> correctlyPositionedPieces = CreateCorrectPositionedPieceList();
            WinController winController = CreateWinController(correctlyPositionedPieces);
            PiecePlaceInGrid piece = CreatePiecePlaceInGrid();
            winController.AddCorrectlyPositionedPiece(piece);

            winController.RemoveCorrectlyPositionedPiece(piece);

            Assert.IsFalse(correctlyPositionedPieces.Contains(piece));
        }

        [Test]
        public void WhenAllPiecesAreInCorretPlaceWinEventIsTriggered()
        {
            int maximumPiecesToPlace = 2;
            List<PiecePlaceInGrid> correctlyPositionedPieces = CreateCorrectPositionedPieceList();
            WinEventController winEventController = CreateWinEventController();
            WinController winController = CreateWinController(correctlyPositionedPieces, winEventController, maximumPiecesToPlace);
            PiecePlaceInGrid firstPiece = CreatePiecePlaceInGrid();
            PiecePlaceInGrid secondPiece = CreatePiecePlaceInGrid();
            bool wasEventTriggered = false;

            winEventController.AddListener(() => wasEventTriggered = true);
            winController.AddCorrectlyPositionedPiece(firstPiece);
            winController.AddCorrectlyPositionedPiece(secondPiece);

            Assert.IsTrue(wasEventTriggered);
        }

        [Test]
        public void WhenNotAllPiecesAreInCorretPlaceWinEventIsNotTriggered()
        {
            int maximumPiecesToPlace = 2;
            List<PiecePlaceInGrid> correctlyPositionedPieces = CreateCorrectPositionedPieceList();
            WinEventController winEventController = CreateWinEventController();
            WinController winController = CreateWinController(correctlyPositionedPieces, winEventController, maximumPiecesToPlace);
            PiecePlaceInGrid firstPiece = CreatePiecePlaceInGrid();
            bool wasEventTriggered = false;

            winEventController.AddListener(() => wasEventTriggered = true);
            winController.AddCorrectlyPositionedPiece(firstPiece);

            Assert.IsFalse(wasEventTriggered);
        }

        private List<PiecePlaceInGrid> CreateCorrectPositionedPieceList()
        {

            return new List<PiecePlaceInGrid>();
        }

        private WinController CreateWinController(List<PiecePlaceInGrid> correctlyPositionedPieces)
        {
            WinEventController winEventController = CreateWinEventController();
            return new WinControllerImplementation(correctlyPositionedPieces, winEventController, 2);
        }

        private WinController CreateWinController(List<PiecePlaceInGrid> correctlyPositionedPieces, WinEventController winEventController, int maximumPiecesToPlace)
        {
            return new WinControllerImplementation(correctlyPositionedPieces, winEventController, maximumPiecesToPlace);
        }

        private PiecePlaceInGrid CreatePiecePlaceInGrid()
        {
            return new StubPiecePlaceInGrid();
        }

        private WinEventController CreateWinEventController()
        {
            return new WinEventControllerImplementation();
        }
    }
}
