using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game
{
    public class PieceComponent : MonoBehaviour
    {
        [SerializeField]
        private PieceData pieceData;
        [SerializeField]
        private TextMeshProUGUI text;

        public void Construct(PieceData pieceData)
        {
            this.pieceData = pieceData;
            text.text = pieceData.Text;
            GridItemMover gridItemMover = GetComponent<GridItemMover>();
            gridItemMover.SetupRownAndColumn(pieceData.PlaceInGrid, 0, 0);
        }
    }
}