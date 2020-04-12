using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;
using System;

namespace Tests
{
    public class SlotTest : ItemNeighborRetriever
    {
        [Test]
        public void Creation()
        {
            PieceDestinationController slotPieceDestinationController = CreatePieceDestinationController();

            Assert.IsNotNull(slotPieceDestinationController);
            Assert.IsTrue(slotPieceDestinationController.State is FixedState);
        }

        private Slot CreateSlot()
        {
            GameObject slotObject = CreateSlotObject();

            return slotObject.GetComponent<SlotComponent>();
        }

        private PieceDestinationController CreatePieceDestinationController()
        {
            GameObject slotObject = CreateSlotObject();

            return slotObject.GetComponent<PieceDestinationController>();
        }

        private GameObject CreateSlotObject()
        {
            ItemNeighborRetriever itemNeighborRetriever = CreateItemNeighborRetriever();
            GridItemFactory slotFactory = CreateSlotFactory(itemNeighborRetriever);
            return slotFactory.Create();
        }

        private ItemNeighborRetriever CreateItemNeighborRetriever()
        {
            return this;
        }

        private GridItemFactory CreateSlotFactory(ItemNeighborRetriever itemNeighborRetriever)
        {
            GameObject slotObjectPrefab = LoadSlotPrefab();
            SlotSelection slotSelection = CreateSlotSelection();
            GridItemFactory pieceFactory = CreatePieceFactory(); ;

            return new SlotFactoryImplementation(slotObjectPrefab, slotSelection, pieceFactory, itemNeighborRetriever);
        }

        private GridItemFactory CreatePieceFactory()
        {
            GameObject pieceObjectPrefab = LoadPiecePrefab();
            return new PieceFactoryImplementation(pieceObjectPrefab);
        }

        private GameObject LoadSlotPrefab()
        {
            return Resources.Load("StubSlotPrefab") as GameObject;
        }

        private GameObject LoadPiecePrefab()
        {
            return Resources.Load("StubPiecePrefab") as GameObject;
        }

        private SlotSelection CreateSlotSelection()
        {
            return new SlotSelectionImplementation();
        }

        public List<GameObject> GetItemNeighbors(GridItemMover item)
        {
            return new List<GameObject>();
        }
    }
}
