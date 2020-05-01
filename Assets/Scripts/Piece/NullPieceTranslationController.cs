using UnityEngine;
using System.Collections;

namespace Game
{
    public class NullPieceTranslationController : PieceTranslationController
    {
        public Vector2 CurrentPiecePosition => Vector2.zero;

        public GameObject PieceObject => null;

        public void TranslateToPosition(Vector2 newPiecePosition)
        {

        }
    }
}
