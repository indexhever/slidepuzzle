using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;

namespace Tests
{
    public class PieceStateTest
    {
        [Test]
        public void FirstIsMovableAndSecondIsEmpty()
        {
            PieceDestinationController firstPieceDestinationController = CreatePieceDestinationController();
            PieceDestinationController secondPieceDestinationController = CreatePieceDestinationController();
            firstPieceDestinationController.SetMovable();
            secondPieceDestinationController.SetEmpty();
            SlotSelectionServer slotSelectionServer = new StubSlotSelectionServer(true, false, CreatePieceObject());

            Assert.IsTrue(firstPieceDestinationController.CanMovePiece());
            Assert.IsTrue(secondPieceDestinationController.CanReceivePiece());

            firstPieceDestinationController.TakePiece();
            secondPieceDestinationController.ReceivePieceFromSlot(slotSelectionServer);

            Assert.IsTrue(secondPieceDestinationController.State is MovableState);
            Assert.IsTrue(firstPieceDestinationController.State is EmptyState);            
        }

        private SlotState CreateMovableState()
        {
            return new MovableState();
        }

        private SlotState CreateEmptyState()
        {
            return new EmptyState();
        }

        private PieceDestinationController CreatePieceDestinationController()
        {
            PieceTranslationController pieceTranslationController = CreatePieceTranslationController();
            GridItemMover slotGridItemMover = SlotGridItemMover();
            return new PieceDestinationControllerImplementation(pieceTranslationController, slotGridItemMover);
        }

        private PieceTranslationController CreatePieceTranslationController()
        {
            GameObject pieceObject = CreatePieceObject();
            return pieceObject.GetComponent<PieceTranslationController>();
        }

        private GameObject CreatePieceObject()
        {
            GridItemFactory pieceFactory = CreatePieceFactory();
            GameObject pieceObject = pieceFactory.Create();
            return pieceObject;
        }

        private GridItemFactory CreatePieceFactory()
        {
            GameObject piecePrefab = LoadPiecePrefab();
            return new PieceFactoryImplementation(piecePrefab);
        }

        private GameObject LoadPiecePrefab()
        {
            return Resources.Load("StubPiecePrefab") as GameObject;
        }

        private GridItemMover SlotGridItemMover()
        {
            StubGridItemFactory slotFactory = new StubGridItemFactory();
            return slotFactory.Create().GetComponent<GridItemMover>();
        }
    }
}
