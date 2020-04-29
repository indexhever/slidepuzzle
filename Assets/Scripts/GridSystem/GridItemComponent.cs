using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GridItemComponent : MonoBehaviour, GridItemMover, GridItem
    {
        private ItemNeighborRetriever itemNeighborRetriever;

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

        public Transform Transform => transform;

        public void Construct(ItemNeighborRetriever itemNeighborRetriever)
        {
            this.itemNeighborRetriever = itemNeighborRetriever;
        }

        public List<GameObject> GetNeighbors()
        {
            return itemNeighborRetriever.GetItemNeighbors(this);
        }

        public void SetupRownAndColumn(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}