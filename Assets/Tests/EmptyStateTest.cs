using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;
using System;

namespace Tests
{
    public class EmptyStateTest
    {
        Game.Grid grid;

        [Test]
        public void WhenEmptyStateAllNeighBorAreMovable()
        {
            grid = CreateSlotGrid(3, 3);
            PieceDestinationController currentSlot = GetSlotByRowAndColumn(1, 1);
            PieceDestinationController leftNeighbor = GetSlotByRowAndColumn(1, 0);
            PieceDestinationController rightNeighbor = GetSlotByRowAndColumn(1, 2);
            PieceDestinationController upNeighbor = GetSlotByRowAndColumn(0, 1);
            PieceDestinationController bottomNeighbor = GetSlotByRowAndColumn(2, 1);

            currentSlot.SetEmpty();
            currentSlot.Clean();

            Assert.IsTrue(currentSlot.CanReceivePiece());
            Assert.IsTrue(leftNeighbor.CanMovePiece());
            Assert.IsTrue(upNeighbor.CanMovePiece());
            Assert.IsTrue(rightNeighbor.CanMovePiece());
            Assert.IsTrue(bottomNeighbor.CanMovePiece());
        }

        [Test]
        public void FindGridItemNeighbor()
        {
            grid = CreateSlotGrid(3, 3);
            GameObject currentSlotObject = GetSlotObjectByRowAndColumn(1, 1);
            GridItemMover slotGridItemMover = currentSlotObject.GetComponent<GridItemMover>();

            //List<GameObject> neighBors = grid.GetItemNeighbors(slotGridItemMover);
            List<GameObject> neighBors = slotGridItemMover.GetNeighbors();

            Assert.AreEqual(4, neighBors.Count);
        }

        private Game.Grid CreateSlotGrid(int width, int height)
        {
            return CreateGrid(3, 3, 1, new Vector2(0, 0));
        }

        private Game.GridImplementation CreateGrid(int width, int height, float offset, Vector2 originPosition)
        {
            StubItemNeighborRetriever itemNeighborRetriever = CreateItemNeighborRetriever();
            GridItemFactory gridItemFactory = CreateGridItemFactory(itemNeighborRetriever);
            GridImplementation gridImplementation = new Game.GridImplementation(width, height, gridItemFactory, offset, originPosition);

            itemNeighborRetriever.Initialize(gridImplementation);

            return gridImplementation;
        }

        private StubItemNeighborRetriever CreateItemNeighborRetriever()
        {
            return new StubItemNeighborRetriever();
        }

        private GridItemFactory CreateGridItemFactory(ItemNeighborRetriever itemNeighborRetriever)
        {
            GameObject slotPrefab = LoadSlotPrefab();
            SlotSelection slotSelection = CreateSlotSelection();
            GridItemFactory pieceFactory = CreatePieceFactory();
            return new SlotFactoryImplementation(slotPrefab, slotSelection, pieceFactory, itemNeighborRetriever);
        }

        private GameObject LoadSlotPrefab()
        {
            return Resources.Load("StubSlotPrefab") as GameObject;
        }

        private GridItemFactory CreatePieceFactory()
        {
            GameObject piecePrefab = LoadPiecePrefab();
            return new PieceFactoryImplementation(piecePrefab);
        }

        private SlotSelection CreateSlotSelection()
        {
            return new SlotSelectionImplementation();
        }

        private GameObject LoadPiecePrefab()
        {
            return Resources.Load("StubPiecePrefab") as GameObject;
        }

        private PieceDestinationController GetSlotByRowAndColumn(int neighborRow, int neighborColumn)
        {
            GameObject slotObject = GetSlotObjectByRowAndColumn(neighborRow, neighborColumn);

            return slotObject.GetComponent<PieceDestinationController>();
        }
        
        private GameObject GetSlotObjectByRowAndColumn(int row, int column)
        {
            return grid.GetGridItemObjectByRowColumn(row, column);
        }
    }
}
