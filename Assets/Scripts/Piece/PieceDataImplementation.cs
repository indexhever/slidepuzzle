using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [CreateAssetMenu(fileName = "PieceData", menuName = "Piece/Data")]
    public class PieceDataImplementation : ScriptableObject, PieceData
    {
        [SerializeField]
        private string text;
        [SerializeField]
        private int placeInGrid;

        public string Text => text;

        public int PlaceInGrid => placeInGrid;
    }
}