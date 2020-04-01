using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PieceComponent : MonoBehaviour, PieceMover, Piece
    {
        [SerializeField]
        private SpriteRenderer spriteRenderer;

        public int Row { get; private set; }
        public int Column { get; private set; }
        public Vector2 Position
        {
            get
            {
                return transform.position;
            }
            set
            {
                transform.position = value;
            }
        }
        public float WidthInUnit
        {
            get
            {
                return spriteRenderer.sprite.texture.width / spriteRenderer.sprite.pixelsPerUnit;
            }
        }
        public float HeightInUnit
        {
            get
            {
                return spriteRenderer.sprite.texture.height / spriteRenderer.sprite.pixelsPerUnit;
            }
        }

        public void SetupRownAndColumn(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}