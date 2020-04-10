using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GridComponent : MonoBehaviour, Grid
    {
        private Grid grid;

        [SerializeField]
        private int width;
        [SerializeField]
        private int height;
        [SerializeField]
        private float offset;
        [SerializeField]
        private GridItemFactoryComponent gridItemFactoryComponent;

        public int Width => grid.Width;

        public int Height => grid.Height;

        public Vector2 Position => grid.Position;

        public List<GameObject> GridItemObjects => grid.GridItemObjects;

        public Vector2 Origin => grid.Origin;

        public GameObject GetGridItemObjectByRowColumn(int row, int column)
        {
            return grid.GetGridItemObjectByRowColumn(row, column);
        }

        // TODO: inject grid item factory
        private void Start()
        {
            grid = new GridImplementation(width, height, gridItemFactoryComponent, offset, transform.position);
        }
    }
}