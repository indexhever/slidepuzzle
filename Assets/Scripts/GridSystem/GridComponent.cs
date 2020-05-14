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

        public int Width => width;

        public int Height => height;

        public Vector2 Position => grid.Position;

        public List<GameObject> GridItemObjects => grid.GridItemObjects;

        public Vector2 Origin => grid.Origin;

        // TODO: inject grid item factory
        private void Start()
        {
            grid = new GridImplementation(width, height, gridItemFactoryComponent, offset, transform.position);
        }

        public GameObject GetGridItemObjectByRowColumn(int row, int column)
        {
            return grid.GetGridItemObjectByRowColumn(row, column);
        }

        public List<GameObject> GetItemNeighbors(GridItemMover gridMover)
        {
            return grid.GetItemNeighbors(gridMover);
        }
    }
}