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
        private PieceFactoryComponent pieceFactory;
        [SerializeField]
        private GridComponent slotGrid;
        [SerializeField]
        private WinControllerComponent winController;

        private void Awake()
        {
            Construct();
        }

        private void Construct()
        {
            WinEventControllerImplementation winEvent = new WinEventControllerImplementation();
            winEvent.AddListener(HandleEndGame);
            winController.Construct(slotGrid.Width * slotGrid.Height - 1, winEvent);
            slotFactory.Construct();
            pieceFactory.Construct();
            slotSorting = new SlotSortingImplementation(slotGrid);
        }

        private void Start()
        {
            slotSorting.GetRandomEmptySlotObject();
        }

        private void HandleEndGame()
        {
            Debug.Log("Game finished");
        }
    }
}