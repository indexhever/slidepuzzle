using UnityEngine;
using System.Collections;
using Game;

namespace Tests
{
    public class StubPieceTranslationController : PieceTranslationController
    {
        private GridItemMover pieceMover;

        public StubPieceTranslationController(GridItemMover pieceMover)
        {
            this.pieceMover = pieceMover;
        }

        public Vector2 CurrentPiecePosition
        {
            get
            {
                return pieceMover.Position;
            }
        }

        public void TranslateToPosition(Vector2 newPiecePosition)
        {
            pieceMover.Position = newPiecePosition;
        }
    }
}
