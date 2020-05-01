using UnityEngine;
using System.Collections;

namespace Game
{
    public interface Slot
    {
        PieceMover PieceMover { get; }

        void Touch();
    }
}

