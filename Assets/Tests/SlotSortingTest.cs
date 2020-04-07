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
            Game.Grid slotGrid = CreateSlotGrid();
            SlotSorting slotSorting = CreateSlotSortingToGrid(slotGrid);

            GameObject randomSlotObject = slotSorting.GetRandomEmptySlotObject();
            PieceDestinationController randomSlotPieceDestinationController = randomSlotObject.GetComponent<PieceDestinationController>();

            Assert.IsTrue(randomSlotPieceDestinationController.State is EmptyState);
        }

        // TODO: deletar piece do slot achado

        // TODO: setar vizinhos do slot empty como movable

        private Game.Grid CreateSlotGrid()
        {
            return CreateGrid(3, 3, 1, new Vector2(0, 0));
        }

        private Game.Grid CreateGrid(int width, int height, float offset, Vector2 originPosition)
        {
            GridItemFactory gridItemFactory = CreateGridItemFactory();
            return new Game.Grid(width, height, gridItemFactory, offset, originPosition);
        }

        private GridItemFactory CreateGridItemFactory()
        {
            GameObject slotPrefab = LoadSlotPrefab();
            SlotSelection slotSelection = CreateSlotSelection();
            GridItemFactory pieceFactory = CreatePieceFactory();
            return new SlotFactoryImplementation(slotPrefab, slotSelection, pieceFactory);
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

        private SlotSorting CreateSlotSortingToGrid(Game.Grid slotGrid)
        {
            return new SlotSortingImplementation(slotGrid);
        }
    }
}
