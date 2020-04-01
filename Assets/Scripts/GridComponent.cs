using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class GridComponent : MonoBehaviour
    {
        private Grid grid;
        private PieceFactoryImplementation pieceFactory;

        [SerializeField]
        private GameObject pieceObjectPrefab;
        [SerializeField]
        private int width;
        [SerializeField]
        private int height;
        [SerializeField]
        private float offset;

        private void Start()
        {
            pieceFactory = new PieceFactoryImplementation(pieceObjectPrefab);
            grid = new Grid(width, height, pieceFactory, offset, transform.position);
        }
    }
}