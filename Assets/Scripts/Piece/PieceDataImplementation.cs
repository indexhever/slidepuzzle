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

        public string Text => text;
    }
}