using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GridComponent : MonoBehaviour
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

        // TODO: inject grid item factory
        private void Start()
        {
            grid = new Grid(width, height, gridItemFactoryComponent, offset, transform.position);
        }
    }
}