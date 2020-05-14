using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;
using System;

namespace Tests
{
    public class PieceChangingSlotTest
    {
        PieceDataSorter pieceDataSorter;

        [SetUp]
        public void Setup()
        {
            pieceDataSorter = CreateStubPieceDataSorter();
        }

        private PieceDataSorter CreateStubPieceDataSorter()
        {
            return new StubPieceDataSorter();
        }

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

        //TODO: definir o place do piece quando cria o piece a partir da factory
        [Test]
        public void PieceIsAddedToWinController()
        {
            int piecePlaceInGrid = 2;
            (pieceDataSorter as StubPieceDataSorter).pieceData = new StubPieceData(piecePlaceInGrid);
            int maximumPiecesToPlace = 1;
            WinEventController winEventController = CreateWinEventController();
            List<PiecePlaceInGrid> correctlyPositionedPieces = new List<PiecePlaceInGrid>();
            WinController winController = CreateWinController(correctlyPositionedPieces, winEventController, maximumPiecesToPlace);
            EmptyState emptyState = CreateEmptyState();
            PieceDestinationController movableSlot = CreateSlot(winController, 1, 0, 1);
            PieceDestinationController emptySlot = CreateSlot(winController, 2, 0, 2);
            bool wasEventTriggered = false;
            winEventController.AddListener(() => wasEventTriggered = true);

            emptyState.ReceivePiece(emptySlot, movableSlot);

            Assert.IsTrue(wasEventTriggered);
        }

        private WinController CreateWinController(List<PiecePlaceInGrid> correctlyPositionedPieces, WinEventController winEventController, int maximumPiecesToPlace)
        {
            return new WinControllerImplementation(correctlyPositionedPieces, winEventController, maximumPiecesToPlace);
        }

        private WinEventController CreateWinEventController()
        {
            return new WinEventControllerImplementation();
        }

        private PieceDestinationController CreateSlot(WinController winController)
        {
            GameObject slotObject = CreateSlotObject(winController);

            return slotObject.GetComponent<PieceDestinationController>();
        }

        private PieceDestinationController CreateSlot(WinController winController, int placeInGrid, int row, int column)
        {
            GameObject slotObject = CreateSlotObject(winController);
            slotObject.GetComponent<GridItemMover>().SetupRownAndColumn(placeInGrid, row, column);

            return slotObject.GetComponent<PieceDestinationController>();
        }

        private GameObject CreateSlotObject(WinController winController)
        {
            StubNullItemNeighborRetriever itemNeighborRetriever = new StubNullItemNeighborRetriever();
            GridItemFactory slotFactory = CreateGridItemFactory(itemNeighborRetriever, winController);
            GameObject slotObject = slotFactory.Create();
            return slotObject;
        }

        private EmptyState CreateEmptyState()
        {
            return new EmptyState();
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
            GridItemFactory gridItemFactory = CreateGridItemFactory(itemNeighborRetriever, new StubWinController());
            GridImplementation gridImplementation = new Game.GridImplementation(width, height, gridItemFactory, offset, originPosition);

            itemNeighborRetriever.Initialize(gridImplementation);

            return gridImplementation;
        }

        private GridItemFactory CreateGridItemFactory(ItemNeighborRetriever itemNeighborRetriever, WinController winController)
        {
            GameObject slotPrefab = LoadSlotPrefab();
            SlotSelection slotSelection = CreateSlotSelection();
            GridItemFactory pieceFactory = CreatePieceFactory();
            return new SlotFactoryImplementation(slotPrefab, slotSelection, pieceFactory, itemNeighborRetriever, winController);
        }

        private GridItemFactory CreatePieceFactory()
        {
            GameObject piecePrefab = LoadPiecePrefab();
            return new PieceFactoryImplementation(piecePrefab, pieceDataSorter);
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
