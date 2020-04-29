using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private SlotSorting slotSorting;

        [SerializeField]
        private SlotFactory slotFactory;
        [SerializeField]
        private PieceFactory pieceFactory;
        [SerializeField]
        private GridComponent slotGrid;

        private void Awake()
        {
            Construct();
        }

        private void Construct()
        {
            slotFactory.Construct();
            pieceFactory.Construct();
            slotSorting = new SlotSortingImplementation(slotGrid);
        }

        private void Start()
        {
            slotSorting.GetRandomEmptySlotObject();
        }
    }
}