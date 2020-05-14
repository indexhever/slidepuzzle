using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Game
{
    public class PieceDestinationControllerImplementation : PieceDestinationController
    {
        private readonly PieceTranslationController NULL_TRANSLATION_CONTROLLER;
        private readonly SlotState EMPTY_STATE;
        private readonly SlotState MOVABLE_STATE;
        private readonly SlotState FIXED_STATE;

        private PieceTranslationController pieceTranslationController;
        private GridItemMover slotGridItemMover;
        private WinController winController;

        public PieceDestinationControllerImplementation()
        {
            EMPTY_STATE = new EmptyState();
            MOVABLE_STATE = new MovableState();
            FIXED_STATE = new FixedState();
            SetFixed();
        }

        public PieceDestinationControllerImplementation(PieceTranslationController pieceTranslationController)
        {
            this.pieceTranslationController = pieceTranslationController;
            NULL_TRANSLATION_CONTROLLER = new NullPieceTranslationController();
            EMPTY_STATE = new EmptyState();
            MOVABLE_STATE = new MovableState();
            FIXED_STATE = new FixedState();
            SetFixed();
        }

        public PieceDestinationControllerImplementation(PieceTranslationController pieceTranslationController, GridItemMover slotGridItemMover, WinController winController)
        {
            this.pieceTranslationController = pieceTranslationController;
            this.slotGridItemMover = slotGridItemMover;
            this.winController = winController;
            //this.grid = grid;
            NULL_TRANSLATION_CONTROLLER = new NullPieceTranslationController();
            EMPTY_STATE = new EmptyState();
            MOVABLE_STATE = new MovableState();
            FIXED_STATE = new FixedState();
            SetFixed();
        }

        public SlotState State { get; set; }

        public Vector2 Position
        {
            get
            {
                return pieceTranslationController.CurrentPiecePosition;
            }
        }

        public GameObject Piece
        {
            get
            {
                return pieceTranslationController.PieceObject;
            }
            set
            {
                GameObject pieceObject = value;
                pieceTranslationController = pieceObject.GetComponent<PieceTranslationController>();
                pieceObject.transform.SetParent(slotGridItemMover.Transform);
                PiecePlaceInGrid piecePlaceInGrid = pieceObject.GetComponent<PiecePlaceInGrid>();
                if (piecePlaceInGrid.Place == slotGridItemMover.Place)
                    winController.AddCorrectlyPositionedPiece(piecePlaceInGrid);
                else
                    winController.RemoveCorrectlyPositionedPiece(piecePlaceInGrid);
            }
        }

        public bool IsFixed => State == FIXED_STATE;

        public PieceDestinationController PieceDestinationController => this;

        public void ReceivePieceFromSlot(SlotSelectionServer slotSelectionServer)
        {
            State.ReceivePiece(this, slotSelectionServer);
        }

        public void TakePiece()
        {
            State.TakePieceFromSlot(this);
        }

        public void TakePieceToPosition(Vector2 pieceDestinePosition)
        {
            State.TakePieceFromSlot(this, pieceDestinePosition);
        }

        public void SetEmpty()
        {
            State = EMPTY_STATE;
        }

        public void SetMovable()
        {
            State = MOVABLE_STATE;
        }

        public void SetFixed()
        {
            State = FIXED_STATE;
        }

        public bool CanMovePiece()
        {
            return State == MOVABLE_STATE;
        }

        public bool CanReceivePiece()
        {
            return State == EMPTY_STATE;
        }

        public Vector2 GetPosition()
        {
            throw new System.NotImplementedException();
        }

        public void MovePieceToDestinePosition(Vector2 destinePosition)
        {
            pieceTranslationController.TranslateToPosition(destinePosition);
        }

        public void Clean()
        {
            pieceTranslationController = NULL_TRANSLATION_CONTROLLER;
            SetNeighborMovable();
        }

        private void SetNeighborMovable()
        {
            List<GameObject> neighbors = slotGridItemMover.GetNeighbors();

            foreach(GameObject neighbor in neighbors)
            {
                PieceDestinationController currentNeighborPieceDestinationController = neighbor.GetComponent<PieceDestinationController>();
                currentNeighborPieceDestinationController.SetMovable();
            }
        }

        public void TurnFixedAllNeighborButOne(SlotSelectionServer givenSlotSelectionServer)
        {
            List<GameObject> neighbors = slotGridItemMover.GetNeighbors();
            neighbors.RemoveAll
            (
                neighbor => 
                    neighbor.GetComponent<SlotSelectionServer>().Equals(givenSlotSelectionServer)
            );

            foreach (GameObject neighbor in neighbors)
            {
                PieceDestinationController currentNeighborPieceDestinationController = neighbor.GetComponent<PieceDestinationController>();
                currentNeighborPieceDestinationController.SetFixed();
            }
        }
    }
}