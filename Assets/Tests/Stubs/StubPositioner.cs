using UnityEngine;
using System.Collections;
using Game;

namespace Tests
{
    public class StubPositioner : Positioner
    {
        public StubPositioner(Vector2 newPosition)
        {
            Position = newPosition;
        }

        public Vector2 Position { get; set; }
    }
}