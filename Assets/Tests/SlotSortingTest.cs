using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;
using System;

namespace Tests
{
    public class SlotSortingTest
    {
        [Test]
        public void SetEmptyStateToRandomSlot()
        {
            Game.GridImplementation slotGrid = CreateSlotGrid();
            SlotSorting slotSorting = CreateSlotSortingToGrid(slotGrid);

            GameObject randomSlotObject = slotSorting.GetRandomEmptySlotObject();
            PieceDestinationController randomSlotPieceDestinationController = randomSlotObject.GetComponent<PieceDestinationController>();

            Assert.IsTrue(randomSlotPieceDestinationController.State is EmptyState);
            Assert.IsNull(randomSlotPieceDestinationController.Piece);
        }

        // TODO: setar vizinhos do slot empty como movable

        private Game.GridImplementation CreateSlotGrid()
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

        private GridItemFactory CreateGridItemFactory(ItemNeighborRetriever itemNeighborRetriever)
        {
            GameObject slotPrefab = LoadSlotPrefab();
            SlotSelection slotSelection = CreateSlotSelection();
            GridItemFactory pieceFactory = CreatePieceFactory();
            return new SlotFactoryImplementation(slotPrefab, slotSelection, pieceFactory, itemNeighborRetriever);
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

        private SlotSelection CreateSlotSelection()
        {
            return new SlotSelectionImplementation();
        }

        private GameObject LoadSlotPrefab()
        {
            return Resources.Load("StubSlotPrefab") as GameObject;
        }

        private SlotSorting CreateSlotSortingToGrid(Game.GridImplementation slotGrid)
        {
            return new SlotSortingImplementation(slotGrid);
        }

        private StubItemNeighborRetriever CreateItemNeighborRetriever()
        {
            return new StubItemNeighborRetriever();
        }
    }
}
