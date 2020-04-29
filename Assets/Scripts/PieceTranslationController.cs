using UnityEngine;
using System.Collections;

namespace Game
{
    public interface PieceTranslationController
    {
        Vector2 CurrentPiecePosition { get; }
        GameObject PieceObject { get; }

        void TranslateToPosition(Vector2 newPiecePosition);
    }
}