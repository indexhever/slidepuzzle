using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;

namespace Tests
{
    public class PieceChangingSlotTest
    {
        [Test]
        public void ChangePieceParentToDestineSlotAfterMoving()
        {
            Game.Grid grid = CreateSlotGrid();
            GameObject emptySlotObject = GetEmptySlotObjectFromGrid(grid);
            GameObject movableSlotObject = GetNeighborOfSlot(emptySlotObject);
            Slot emptySlot = emptySlotObject.GetComponent<Slot>();
            Slot movableSlot = movableSlotObject.GetComponent<Slot>();
            PieceDestinationController emptySlotPieceDestinationController = emptySlotObject.GetComponent<PieceDestinationController>();
            PieceDestinationController movableSlotPieceDestinationController = movableSlotObject.GetComponent<PieceDestinationController>();
            
            GameObject movedPiece = movableSlotPieceDestinationController.Piece;

            Assert.IsNotNull(movedPiece);

            movableSlot.Touch();
            emptySlot.Touch();

            Assert.IsNotNull(movedPiece);
            Assert.IsNotNull(emptySlotObject.transform);
            Assert.AreEqual(emptySlotObject.transform, movedPiece.transform.parent);
            Assert.IsNotNull(emptySlotPieceDestinationController.Piece);
            Assert.AreEqual(null, movableSlotPieceDestinationController.Piece);
            Assert.AreEqual(movedPiece, emptySlotPieceDestinationController.Piece);
        }

        //TODO: no estado Empty, quando ReceivePiece
	    //- chamar metodo de PiceDestinationController que transforma todos os vizinhos, menos a
        // peça que está indo para a vazia, em estado fixed        
        [Test]
        public void WhenEmptySlotReceivePieceItsNeighborShouldTurnFixed()
        {
            Game.Grid grid = CreateSlotGrid();
            GameObject emptySlotObject = GetEmptySlotObjectFromGrid(grid);
            GameObject movableSlotObject = GetNeighborOfSlot(emptySlotObject);
            GridItemMover slotMover = emptySlotObject.GetComponent<GridItemMover>();
            List<GameObject> slotNeighbors = slotMover.GetNeighbors();
            Slot emptySlot = emptySlotObject.GetComponent<Slot>();
            Slot movableSlot = movableSlotObject.GetComponent<Slot>();
            SlotSelectionServer givenSlotSelectionServer = movableSlotObject.GetComponent<SlotSelectionServer>();
            PieceDestinationController emptySlotPieceDestinationController = emptySlotObject.GetComponent<PieceDestinationController>();
            PieceDestinationController movableSlotPieceDestinationController = movableSlotObject.GetComponent<PieceDestinationController>();

            movableSlot.Touch();
            emptySlot.Touch();

            TestNeighborsAreFixedButGivenOne(slotNeighbors, givenSlotSelectionServer);
        }

        [Test]
        public void NeigborOfSlotDifferentThanAGivenSlotTurnFixed()
        {
            Game.Grid grid = CreateSlotGrid();
            GameObject slotObject = GetEmptySlotObjectFromGrid(grid);
            GridItemMover slotMover = slotObject.GetComponent<GridItemMover>();
            List<GameObject> slotNeighbors = slotMover.GetNeighbors();
            GameObject givenSlot = slotNeighbors[0];
            SlotSelectionServer givenSlotSelectionServer = givenSlot.GetComponent<SlotSelectionServer>();
            PieceDestinationController slot = slotObject.GetComponent<PieceDestinationController>();

            slot.TurnFixedAllNeighborButOne(givenSlotSelectionServer);
            TestNeighborsAreFixedButGivenOne(slotNeighbors, givenSlotSelectionServer);
        }

        private static void TestNeighborsAreFixedButGivenOne(List<GameObject> slotNeighbors, SlotSelectionServer givenSlotSelectionServer)
        {
            bool foundGivenNeighbor = false;

            foreach (GameObject slotNeighbor in slotNeighbors)
            {
                SlotSelectionServer neighborSlotSelectionServer = slotNeighbor.GetComponent<SlotSelectionServer>();

                if (givenSlotSelectionServer.Equals(neighborSlotSelectionServer))
                {
                    foundGivenNeighbor = true;
                    Assert.IsTrue(!neighborSlotSelectionServer.IsFixed);
                }
                else
                {
                    Assert.IsTrue(neighborSlotSelectionServer.IsFixed);
                }
            }
            Assert.IsTrue(foundGivenNeighbor);
        }

        private GameObject GetEmptySlotObjectFromGrid(Game.Grid grid)
        {
            SlotSorting slotSorting = CreateSlotSortingToGrid(grid);
            return slotSorting.GetRandomEmptySlotObject();
        }

        private SlotSorting CreateSlotSortingToGrid(Game.Grid slotGrid)
        {
            return new SlotSortingImplementation(slotGrid);
        }

        private GameObject GetNeighborOfSlot(GameObject slotObject)
        {
            GridItemMover gridItemMover = slotObject.GetComponent<GridItemMover>();
            return gridItemMover.GetNeighbors()[0];
        }

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
