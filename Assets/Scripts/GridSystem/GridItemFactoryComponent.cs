using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public abstract class GridItemFactoryComponent : MonoBehaviour, GridItemFactory
    {
        public virtual float GridItemWidthInUnit => throw new System.NotImplementedException();

        public virtual float GridItemHeightInUnit => throw new System.NotImplementedException();
        
        public virtual GameObject Create()
        {
            throw new System.NotImplementedException();
        }
    }
}