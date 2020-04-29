using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;
using System;

namespace Tests
{
    public class TouchSlotTest
    {
        [Test]
        public void SelectOneSlotByTouching()
        {
            SlotSelection slotSelection = CreateSlotSelection();
            Slot slot = CreateSlot(slotSelection);

            slot.Touch();

            Assert.AreEqual(1, slotSelection.SelectedSlotSevers.Count);
        }

        [Test]
        public void SelectTwoSlotsByTouching()
        {
            SlotSelection slotSelection = CreateSlotSelection();
            PieceDestinationController firstPieceDestinationController = CreatePieceDestinationController();
            firstPieceDestinationController.SetMovable();
            PieceDestinationController secondPieceDestinationController = CreatePieceDestinationController();
            firstPieceDestinationController.SetEmpty();
            Slot slot1 = CreateSlot(slotSelection, firstPieceDestinationController);
            Slot slot2 = CreateSlot(slotSelection, secondPieceDestinationController);

            slot1.Touch();
            slot2.Touch();

            Assert.AreEqual(0, slotSelection.SelectedSlotSevers.Count);
        }

        [Test]
        public void SelectingTheThirdWillResetSelecting()
        {
            SlotSelection slotSelection = CreateSlotSelection();
            PieceDestinationController firstPieceDestinationController = CreatePieceDestinationController();
            firstPieceDestinationController.SetMovable();
            PieceDestinationController secondPieceDestinationController = CreatePieceDestinationController();
            secondPieceDestinationController.SetEmpty();
            PieceDestinationController thirdPieceDestinationController = CreatePieceDestinationController();
            thirdPieceDestinationController.SetMovable();
            Slot slot1 = CreateSlot(slotSelection, firstPieceDestinationController);
            Slot slot2 = CreateSlot(slotSelection, secondPieceDestinationController);
            Slot slot3 = CreateSlot(slotSelection, thirdPieceDestinationController);

            slot1.Touch();
            slot2.Touch();
            slot3.Touch();

            Assert.AreEqual(1, slotSelection.SelectedSlotSevers.Count);
            Assert.AreEqual(slot3, slotSelection.SelectedSlotSevers[0]);
        }

        [Test]
        public void TouchingFirstThatCanTakePieceAndSecondThatCanReceive()
        {
            SlotSelection slotSelection = CreateSlotSelection();
            PieceDestinationController firstPieceDestinationController = CreatePieceDestinationController();
            firstPieceDestinationController.SetMovable();
            PieceDestinationController secondPieceDestinationController = CreatePieceDestinationController();
            secondPieceDestinationController.SetEmpty();
            Slot slot1 = CreateSlot(slotSelection, firstPieceDestinationController);
            Slot slot2 = CreateSlot(slotSelection, secondPieceDestinationController);

            slot1.Touch();
            slot2.Touch();

            Assert.IsTrue(firstPieceDestinationController.CanReceivePiece());
            Assert.IsTrue(secondPieceDestinationController.CanMovePiece());
            Assert.IsFalse(firstPieceDestinationController.CanMovePiece());
            Assert.IsFalse(secondPieceDestinationController.CanReceivePiece());
        }

        [Test]
        public void TouchingFirstThatCanNotTakePieceAndSecondThatCanReceive()
        {
            SlotSelection slotSelection = CreateSlotSelection();
            PieceDestinationController firstPieceDestinationController = CreatePieceDestinationController();
            firstPieceDestinationController.SetEmpty();
            PieceDestinationController secondPieceDestinationController = CreatePieceDestinationController();
            secondPieceDestinationController.SetEmpty();
            Slot slot1 = CreateSlot(slotSelection, firstPieceDestinationController);
            Slot slot2 = CreateSlot(slotSelection, secondPieceDestinationController);

            slot1.Touch();
            slot2.Touch();

            Assert.IsTrue(firstPieceDestinationController.CanReceivePiece());
            Assert.IsTrue(secondPieceDestinationController.CanReceivePiece());
            Assert.IsFalse(firstPieceDestinationController.CanMovePiece());
            Assert.IsFalse(secondPieceDestinationController.CanMovePiece());
        }

        [Test]
        public void TouchingFirstThatCanTakePieceAndSecondThatCanNotReceive()
        {
            SlotSelection slotSelection = CreateSlotSelection();
            PieceDestinationController firstPieceDestinationController = CreatePieceDestinationController();
            firstPieceDestinationController.SetMovable();
            PieceDestinationController secondPieceDestinationController = CreatePieceDestinationController();
            secondPieceDestinationController.SetMovable();
            Slot slot1 = CreateSlot(slotSelection, firstPieceDestinationController);
            Slot slot2 = CreateSlot(slotSelection, secondPieceDestinationController);

            slot1.Touch();
            slot2.Touch();

            Assert.IsTrue(firstPieceDestinationController.CanMovePiece());
            Assert.IsTrue(secondPieceDestinationController.CanMovePiece());
            Assert.IsFalse(firstPieceDestinationController.CanReceivePiece());
            Assert.IsFalse(secondPieceDestinationController.CanReceivePiece());
        }

        private SlotSelection CreateSlotSelection()
        {
            return new SlotSelectionImplementation();
        }

        private Slot CreateSlot(SlotSelection slotSelection)
        {
            Positioner slotPositioner = CreateSlotPositioner(Vector2.zero);
            return new SlotImplementation(slotSelection, slotPositioner);
        }

        private Slot CreateSlot(SlotSelection slotSelection, PieceDestinationController pieceDestinationController)
        {
            Positioner slotPositioner = CreateSlotPositioner(Vector2.zero);
            return new SlotImplementation(slotSelection, pieceDestinationController, slotPositioner);
        }

        private PieceDestinationController CreatePieceDestinationController()
        {
            GridItemMover pieceMover = CreatePieceMover();
            PieceTranslationController pieceTranslationController = CreatePieceTranslationController(pieceMover);
            return new PieceDestinationControllerImplementation(pieceTranslationController, pieceMover);
        }

        private PieceTranslationController CreatePieceTranslationController(GridItemMover pieceMover)
        {
            GameObject pieceObject = CreatePieceObject();
            return new StubPieceTranslationController(pieceObject);
        }

        private GameObject CreatePieceObject()
        {
            GridItemFactory pieceFactory = CreatePieceFactoryPrefab();
            GameObject pieceObject = pieceFactory.Create();
            return pieceObject;
        }

        private GridItemFactory CreatePieceFactoryPrefab()
        {
            GameObject piecePrefab = LoadPiecePrefab();
            return new PieceFactoryImplementation(piecePrefab);
        }

        private GameObject LoadPiecePrefab()
        {
            return Resources.Load("StubPiecePrefab") as GameObject;
        }

        private GridItemMover CreatePieceMover()
        {
            GridItemFactory pieceFactory = CreatePieceFactory();
            GameObject pieceObject = pieceFactory.Create();
            return pieceObject.GetComponent<GridItemMover>();
        }

        private GridItemFactory CreatePieceFactory()
        {
            return new StubGridItemFactory();
        }

        private Positioner CreateSlotPositioner(Vector2 pieceDestinePosition)
        {
            return new StubPositioner(pieceDestinePosition);
        }
    }
}
