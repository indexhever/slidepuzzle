using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        SlotFactory slotFactory;
        [SerializeField]
        PieceFactory pieceFactory;

        private void Awake()
        {
            Construct();
        }

        private void Construct()
        {
            slotFactory.Construct();
            pieceFactory.Construct();
        }
    }
}