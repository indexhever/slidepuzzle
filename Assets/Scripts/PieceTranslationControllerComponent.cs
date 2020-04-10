using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PieceTranslationControllerComponent : MonoBehaviour, PieceTranslationController
    {
        public Vector2 CurrentPiecePosition
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

        public GameObject PieceObject => gameObject;

        // TODO: Criar translação por tempo
        public void TranslateToPosition(Vector2 newPiecePosition)
        {
            CurrentPiecePosition = newPiecePosition;
        }
    }
}