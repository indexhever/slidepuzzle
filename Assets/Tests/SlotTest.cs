using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;
using System;

namespace Tests
{
    public class SlotTest
    {
        /*
        [Test]
        public void Creation()
        {
            Slot slot = CreateSlot();

            PieceMover pieceMoverInsideSlot = slot.PieceMover;

            Assert.IsNotNull(pieceMoverInsideSlot);
        }*/

        private Slot CreateSlot()
        {
            GridItemFactory slotFactory = CreateSlotFactory();
            GameObject slotObject = slotFactory.Create();

            return slotObject.GetComponent<SlotComponent>();
        }

        private GridItemFactory CreateSlotFactory()
        {
            GameObject slotObjectPrefab = LoadSlotPrefab();
            SlotSelection slotSelection = CreateSlotSelection();

            return new SlotFactoryImplementation(slotObjectPrefab, slotSelection);
        }

        private GameObject LoadSlotPrefab()
        {
            return Resources.Load("StubSlotPrefab") as GameObject;
        }

        private SlotSelection CreateSlotSelection()
        {
            return new SlotSelectionImplementation();
        }
    }
}
