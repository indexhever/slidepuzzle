using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;

namespace Tests
{
    public class PieceStateTest
    {
        [Test]
        public void FirstIsMovableAndSecondIsEmpty()
        {
            PieceDestinationController firstPieceDestinationController = CreatePieceDestinationController();
            PieceDestinationController secondPieceDestinationController = CreatePieceDestinationController();
            firstPieceDestinationController.SetMovable();
            secondPieceDestinationController.SetEmpty();

            Assert.IsTrue(firstPieceDestinationController.CanMovePiece());
            Assert.IsTrue(secondPieceDestinationController.CanReceivePiece());

            firstPieceDestinationController.TakePiece();
            secondPieceDestinationController.ReceivePiece();

            Assert.IsTrue(secondPieceDestinationController.State is MovableState);
            Assert.IsTrue(firstPieceDestinationController.State is EmptyState);            
        }

        private SlotState CreateMovableState()
        {
            return new MovableState();
        }

        private SlotState CreateEmptyState()
        {
            return new EmptyState();
        }

        private PieceDestinationController CreatePieceDestinationController()
        {
            return new PieceDestinationControllerImplementation();
        }
    }
}
