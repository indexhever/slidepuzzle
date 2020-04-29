using System;
using Game;
using NUnit.Framework;

namespace Tests
{
    public class SlotSelectionTest
    {
        [Test]
        public void SelectOneSlot()
        {
            SlotSelection slotSelection = CreateSlotSelection();
            SlotSelectionServer slotSelectionServer = CreateSlotSelectionServer(true, true);

            slotSelection.SelectSlot(slotSelectionServer);

            Assert.AreEqual(1, slotSelection.SelectedSlotSevers.Count);
        }

        [Test]
        public void AfterSelectingTwoSlotsSelectionResets()
        {
            SlotSelection slotSelection = CreateSlotSelection();
            SlotSelectionServer slotSelectionServer1 = CreateSlotSelectionServer(true, true);
            SlotSelectionServer slotSelectionServer2 = CreateSlotSelectionServer(true, true);

            slotSelection.SelectSlot(slotSelectionServer1);
            slotSelection.SelectSlot(slotSelectionServer2);

            Assert.AreEqual(0, slotSelection.SelectedSlotSevers.Count);
        }

        [Test]
        public void SelectingThreeStartNewSelection()
        {
            SlotSelection slotSelection = CreateSlotSelection();
            SlotSelectionServer slotSelectionServer1 = CreateSlotSelectionServer(true, true);
            SlotSelectionServer slotSelectionServer2 = CreateSlotSelectionServer(true, true);
            SlotSelectionServer slotSelectionServer3 = CreateSlotSelectionServer(true, true);

            slotSelection.SelectSlot(slotSelectionServer1);
            slotSelection.SelectSlot(slotSelectionServer2);
            slotSelection.SelectSlot(slotSelectionServer3);

            Assert.AreEqual(1, slotSelection.SelectedSlotSevers.Count);
            Assert.AreEqual(slotSelectionServer3, slotSelection.SelectedSlotSevers[0]);
        }

        [Test]
        public void SelectingTwoSlotsWillCheckIfTheyCanMoveAndReceivePiece()
        {
            SlotSelection slotSelection = CreateSlotSelection();
            StubSlotSelectionServer slotSelectionServer1 = CreateSlotSelectionServer(true, true) as StubSlotSelectionServer;
            StubSlotSelectionServer slotSelectionServer2 = CreateSlotSelectionServer(true, true) as StubSlotSelectionServer;

            slotSelection.SelectSlot(slotSelectionServer1);
            slotSelection.SelectSlot(slotSelectionServer2);

            Assert.IsTrue(slotSelectionServer1.CanMovePieceWasCalled);
            Assert.IsTrue(slotSelectionServer2.CanReceivePieceWasCalled);
        }

        [Test]
        public void SelectingTwoSlotsWillTakePieceAndReceiveWhenCanMoveAndReceive()
        {
            SlotSelection slotSelection = CreateSlotSelection();
            StubSlotSelectionServer slotSelectionServer1 = CreateSlotSelectionServer(true, true) as StubSlotSelectionServer;
            StubSlotSelectionServer slotSelectionServer2 = CreateSlotSelectionServer(true, true) as StubSlotSelectionServer;

            slotSelection.SelectSlot(slotSelectionServer1);
            slotSelection.SelectSlot(slotSelectionServer2);

            Assert.IsTrue(slotSelectionServer1.CanMovePieceWasCalled);
            Assert.IsTrue(slotSelectionServer2.CanReceivePieceWasCalled);
            Assert.IsTrue(slotSelectionServer1.TakePieceWasCalled);
            Assert.IsTrue(slotSelectionServer2.ReceivePieceWasCalled);
        }

        [Test]
        public void DontMoveAndReceiveIfCantMove()
        {
            SlotSelection slotSelection = CreateSlotSelection();
            StubSlotSelectionServer slotSelectionServer1 = CreateSlotSelectionServer(false, true) as StubSlotSelectionServer;
            StubSlotSelectionServer slotSelectionServer2 = CreateSlotSelectionServer(true, true) as StubSlotSelectionServer;

            slotSelection.SelectSlot(slotSelectionServer1);
            slotSelection.SelectSlot(slotSelectionServer2);

            Assert.IsFalse(slotSelectionServer1.TakePieceWasCalled);
            Assert.IsFalse(slotSelectionServer2.ReceivePieceWasCalled);
        }

        [Test]
        public void DontMoveAndReceiveIfCantReceive()
        {
            SlotSelection slotSelection = CreateSlotSelection();
            StubSlotSelectionServer slotSelectionServer1 = CreateSlotSelectionServer(true, true) as StubSlotSelectionServer;
            StubSlotSelectionServer slotSelectionServer2 = CreateSlotSelectionServer(true, false) as StubSlotSelectionServer;

            slotSelection.SelectSlot(slotSelectionServer1);
            slotSelection.SelectSlot(slotSelectionServer2);

            Assert.IsFalse(slotSelectionServer1.TakePieceWasCalled);
            Assert.IsFalse(slotSelectionServer2.ReceivePieceWasCalled);
        }

        [Test]
        public void CanMovePieceCalledWhenCheckIfServerCanMovePiece()
        {
            SlotSelectionServer slotSelectionServer1 = CreateSlotSelectionServer(true, true) as StubSlotSelectionServer;

            bool canMovePiece = slotSelectionServer1.CanMovePiece();

            Assert.IsTrue((slotSelectionServer1 as StubSlotSelectionServer).CanMovePieceWasCalled);
            Assert.IsTrue(canMovePiece);
        }

        [Test]
        public void CanReceivePieceCalledWhenCheckIfServerCanReceivePiece()
        {
            SlotSelectionServer slotSelectionServer1 = CreateSlotSelectionServer(true, true) as StubSlotSelectionServer;

            bool canReceivePiece = slotSelectionServer1.CanReceivePiece();

            Assert.IsTrue((slotSelectionServer1 as StubSlotSelectionServer).CanReceivePieceWasCalled);
            Assert.IsTrue(canReceivePiece);
        }

        [Test]
        public void TakePieceCalled()
        {
            SlotSelectionServer slotSelectionServer1 = CreateSlotSelectionServer(true, true) as StubSlotSelectionServer;

            slotSelectionServer1.TakePiece();

            Assert.IsTrue((slotSelectionServer1 as StubSlotSelectionServer).TakePieceWasCalled);
        }

        // TODO: fix receive piece from slot null value
        [Test]
        public void ReceivePieceCalled()
        {
            SlotSelectionServer slotSelectionServer1 = CreateSlotSelectionServer(true, true) as StubSlotSelectionServer;

            slotSelectionServer1.ReceivePieceFromSlot(null);

            Assert.IsTrue((slotSelectionServer1 as StubSlotSelectionServer).ReceivePieceWasCalled);
        }

        private SlotSelection CreateSlotSelection()
        {
            return new SlotSelectionImplementation();
        }

        private SlotSelectionServer CreateSlotSelectionServer(bool canMovePiece, bool canReceivePiece)
        {
            return new StubSlotSelectionServer(canMovePiece, canReceivePiece);
        }
    }
}
