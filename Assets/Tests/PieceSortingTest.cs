using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PieceSortingTest
    {
        [Test]
        public void PieceIsCorrectlyRetrieved()
        {
            List<PieceData> pieceDataList = CreatePieceDataList(3);
            PieceDataSorter pieceSorter = CreatePieceDataSorter(pieceDataList);

            PieceData pieceData = pieceSorter.GetRandomPieceData();

            Assert.IsNotNull(pieceData);
        }

        [Test]
        public void EachPieceDataTakenIsDifferent()
        {
            List<PieceData> pieceDataList = CreatePieceDataList(3);
            PieceDataSorter pieceSorter = CreatePieceDataSorter(pieceDataList);

            PieceData firstPieceData = pieceSorter.GetRandomPieceData();
            PieceData secondPieceData = pieceSorter.GetRandomPieceData();

            Assert.AreNotEqual(firstPieceData, secondPieceData);
        }

        [Test]
        public void EachTimeDataIsRetrievedItIsRemovedFromList()
        {
            List<PieceData> pieceDataList = CreatePieceDataList(3);
            PieceDataSorter pieceSorter = CreatePieceDataSorter(pieceDataList);

            PieceData retrievedPieceData = pieceSorter.GetRandomPieceData();

            Assert.IsFalse(pieceDataList.Contains(retrievedPieceData));
        }

        private List<PieceData> CreatePieceDataList(int amountOfData)
        {
            List<PieceData> pieceDataList = new List<PieceData>();

            for(int i = 0; i < amountOfData; i++)
            {
                pieceDataList.Add(new StubPieceData());
            }

            return pieceDataList;
        }

        private PieceDataSorter CreatePieceDataSorter(List<PieceData> pieceDataList)
        {
            return new PieceDataSorterImplementation(pieceDataList);
        }
    }
}
