using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GridComponent : MonoBehaviour
    {
        private Grid grid;
        private GridItemFactoryImplementation gridItemFactory;

        [SerializeField]
        private GameObject gridItemObjectPrefab;
        [SerializeField]
        private int width;
        [SerializeField]
        private int height;
        [SerializeField]
        private float offset;

        private void Start()
        {
            gridItemFactory = new GridItemFactoryImplementation(gridItemObjectPrefab);
            grid = new Grid(width, height, gridItemFactory, offset, transform.position);
        }
    }
}