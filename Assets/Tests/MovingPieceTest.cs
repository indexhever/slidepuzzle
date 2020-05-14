using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;
using System;

namespace Tests
{
    public class MovingPieceTest : ItemNeighborRetriever
    {
        [Test]
        public void MovingFromOneSlotToAnother()
        {
            Vector2 pieceDestinePosition = new Vector2(1, 2);
            GridItemMover pieceMover = CreatePieceMover();
            PieceTranslationController pieceTranslationController = CreatePieceTranslationController(pieceMover);
            PieceDestinationController pieceDestinationController = CreatePieceDestinationController(pieceTranslationController, pieceMover);

            pieceDestinationController.MovePieceToDestinePosition(pieceDestinePosition);

            Assert.AreEqual(pieceDestinePosition, pieceMover.Position);
        }

        [Test]
        public void PieceTranslation()
        {
            GridItemMover pieceMover = CreatePieceMover();
            PieceTranslationController pieceTranslationController = CreatePieceTranslationController(pieceMover);
            Vector2 newPiecePosition = new Vector2(1, 2);

            pieceTranslationController.TranslateToPosition(newPiecePosition);

            Assert.AreEqual(newPiecePosition, pieceMover.Position);
        }

        [Test]
        public void MovePieceWhenDestinationControlerIsMovingState()
        {
            Vector2 pieceDestinePosition = new Vector2(1, 2);
            GridItemMover pieceMover = CreatePieceMover();
            PieceTranslationController pieceTranslationController = CreatePieceTranslationController(pieceMover);
            PieceDestinationController pieceDestinationController = CreatePieceDestinationController(pieceTranslationController, pieceMover);
            pieceDestinationController.SetMovable();

            pieceDestinationController.TakePieceToPosition(pieceDestinePosition);

            Assert.AreEqual(pieceDestinePosition, pieceMover.Position);
        }

        [Test]
        public void MovePieceWhenFirstSelectedSlotIsMovableAndSecondCanReceivePiece()
        {
            //TODO: Slot tem que dar a posição dele e não da peça, pq tem slots q não possuem peça
            Vector2 pieceDestinePosition = new Vector2(1, 2);
            SlotSelection slotSelection = CreateSlotSelection();
            GameObject pieceObject = CreatePieceObject();
            GridItemMover pieceMover = pieceObject.GetComponent<GridItemMover>();
            PieceTranslationController firstPieceTranslationController = CreatePieceTranslationController(pieceObject);
            PieceDestinationController firstPieceDestinationController = CreatePieceDestinationController(firstPieceTranslationController, pieceMover);
            firstPieceDestinationController.SetMovable();
            Positioner slotPositioner = CreateSlotPositioner(pieceDestinePosition);
            Slot slot1 = CreateSlot(slotSelection, firstPieceDestinationController, slotPositioner);

            GameObject pieceObject2 = CreatePieceObject();
            GridItemMover pieceMover2 = pieceObject2.GetComponent<GridItemMover>();
            PieceTranslationController secondPieceTranslationController = CreatePieceTranslationController(pieceObject2);
            PieceDestinationController secondPieceDestinationController = CreatePieceDestinationController(secondPieceTranslationController, pieceMover2);
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

        private PieceTranslationController CreatePieceTranslationController(GridItemMover pieceMover)
        {
            return new StubPieceTranslationController(pieceMover);
        }

        private PieceTranslationController CreatePieceTranslationController(GameObject pieceObject)
        {
            return new StubPieceTranslationController(pieceObject);
        }

        private GridItemMover CreatePieceMover()
        {
            GameObject pieceObject = CreatePieceObject();
            StubGridItemComponent gridItemMover = pieceObject.GetComponent<GridItemMover>() as StubGridItemComponent;

            return gridItemMover;
        }

        private GameObject CreatePieceObject()
        {
            GridItemFactory pieceFactory = CreatePieceFactory();
            GameObject pieceObject = pieceFactory.Create();
            return pieceObject;
        }

        private GridItemFactory CreatePieceFactory()
        {
            return new StubGridItemFactory();
        }

        private PieceDestinationController CreatePieceDestinationController(PieceTranslationController pieceTranslationController, GridItemMover pieceMover)
        {
            return new PieceDestinationControllerImplementation(pieceTranslationController, pieceMover, new StubWinController());
        }

        private SlotSelection CreateSlotSelection()
        {
            return new SlotSelectionImplementation();
        }

        private Slot CreateSlot(SlotSelection slotSelection, PieceDestinationController pieceDestinationController, Positioner positioner = null)
        {
            return new SlotImplementation(slotSelection, pieceDestinationController, positioner);
        }

        public List<GameObject> GetItemNeighbors(GridItemMover item)
        {
            return new List<GameObject>();
        }


    }
}
