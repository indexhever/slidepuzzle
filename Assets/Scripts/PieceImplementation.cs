using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class PieceImplementation
    {
        private int row;
        private int column;
        private PieceMover pieceMover;

        public PieceImplementation(PieceMover pieceMover)
        {
            this.pieceMover = pieceMover;
            Row = pieceMover.Row;
            Column = pieceMover.Column;
        }

        public int Row
        {
            get;
            private set;
        }
        public double Column { get; set; }
    }
}