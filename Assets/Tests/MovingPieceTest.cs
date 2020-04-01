using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;
using System;

namespace Tests
{
    public class MovingPieceTest
    {
        [Test]
        public void MovingFromOneSlotToAnother()
        {
            Vector2 pieceDestinePosition = new Vector2(1, 2);
            PieceMover pieceMover = CreatePieceMover();
            PieceTranslationController pieceTranslationController = CreatePieceTranslationController(pieceMover);
            PieceDestinationController pieceDestinationController = CreatePieceDestinationController(pieceTranslationController);

            pieceDestinationController.MovePieceToDestinePosition(pieceDestinePosition);

            Assert.AreEqual(pieceDestinePosition, pieceMover.Position);
        }

        [Test]
        public void PieceTranslation()
        {
            PieceMover pieceMover = CreatePieceMover();
            PieceTranslationController pieceTranslationController = CreatePieceTranslationController(pieceMover);
            Vector2 newPiecePosition = new Vector2(1, 2);

            pieceTranslationController.TranslateToPosition(newPiecePosition);

            Assert.AreEqual(newPiecePosition, pieceMover.Position);
        }

        [Test]
        public void MovePieceWhenDestinationControlerIsMovingState()
        {
            Vector2 pieceDestinePosition = new Vector2(1, 2);
            PieceMover pieceMover = CreatePieceMover();
            PieceTranslationController pieceTranslationController = CreatePieceTranslationController(pieceMover);
            PieceDestinationController pieceDestinationController = CreatePieceDestinationController(pieceTranslationController);
            pieceDestinationController.SetMovable();

            pieceDestinationController.TakePiece(pieceDestinePosition);

            Assert.AreEqual(pieceDestinePosition, pieceMover.Position);
        }

        [Test]
        public void MovePieceWhenFirstSelectedSlotIsMovableAndSecondCanReceivePiece()
        {
            //TODO: Slot tem que dar a posição dele e não da peça, pq tem slots q não possuem peça
            Vector2 pieceDestinePosition = new Vector2(1, 2);
            SlotSelection slotSelection = CreateSlotSelection();
            PieceMover pieceMover = CreatePieceMover();
            PieceTranslationController firstPieceTranslationController = CreatePieceTranslationController(pieceMover);
            PieceDestinationController firstPieceDestinationController = CreatePieceDestinationController(firstPieceTranslationController);
            firstPieceDestinationController.SetMovable();
            Positioner slotPositioner = CreateSlotPositioner(pieceDestinePosition);
            Slot slot1 = CreateSlot(slotSelection, firstPieceDestinationController, slotPositioner);
            PieceTranslationController secondPieceTranslationController = CreatePieceTranslationController(null);
            PieceDestinationController secondPieceDestinationController = CreatePieceDestinationController(secondPieceTranslationController);
            secondPieceDestinationController.SetEmpty();
            Positioner slotPositioner2 = CreateSlotPositioner(pieceDestinePosition);
            Slot slot2 = CreateSlot(slotSelection, secondPieceDestinationController, slotPositioner2);

            slot1.Touch();
            slot2.Touch();

            Assert.AreEqual(pieceDestinePosition, pieceMover.Position);
        }

        [Test]
        public void Positioning()
        {
            Vector2 destinePosition = new Vector2(1, 2);
            Positioner slotPositioner = CreateSlotPositioner(destinePosition);

            Assert.AreEqual(destinePosition, slotPositioner.Position);
        }

        private Positioner CreateSlotPositioner(Vector2 pieceDestinePosition)
        {
            return new StubPositioner(pieceDestinePosition);
        }

        private PieceTranslationController CreatePieceTranslationController(PieceMover pieceMover)
        {
            return new StubPieceTranslationController(pieceMover);
        }

        private PieceMover CreatePieceMover()
        {
            PieceFactory pieceFactory = CreatePieceFactory();
            GameObject pieceObject = pieceFactory.Create();
            return pieceObject.GetComponent<PieceMover>();
        }

        private PieceFactory CreatePieceFactory()
        {
            return new StubPieceFactory();
        }

        private PieceDestinationController CreatePieceDestinationController(PieceTranslationController pieceTranslationController)
        {
            return new PieceDestinationControllerImplementation(pieceTranslationController);
        }

        private SlotSelection CreateSlotSelection()
        {
            return new SlotSelectionImplementation();
        }

        private Slot CreateSlot(SlotSelection slotSelection, PieceDestinationController pieceDestinationController, Positioner positioner = null)
        {
            return new SlotImplementation(slotSelection, pieceDestinationController, positioner);
        }
    }
}
