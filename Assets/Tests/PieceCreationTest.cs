using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Game;
using System;

namespace Tests
{
    public class PieceCreationTest
    {
        [Test]
        public void PieceCreationCorrectly()
        {
            PieceFactory pieceFactory = CreatePieceFactory();

            GameObject pieceObject = pieceFactory.Create();

            Assert.IsNotNull(pieceObject); 
        }

        [Test]
        public void WhenPieceIsCreatedPieceDataIsRetrieved()
        {
            List<PieceData> pieceDataList = CreatePieceDataList(3);
            PieceDataSorter pieceDataSorter = CreatePieceDataSorter(pieceDataList);
            PieceFactory pieceFactory = CreatePieceFactory(pieceDataSorter);

            GameObject pieceObject = pieceFactory.Create();

            Assert.AreEqual(2, pieceDataList.Count);
        }

        private PieceDataSorter CreatePieceDataSorter(List<PieceData> pieceDataList)
        {
            return new PieceDataSorterImplementation(pieceDataList);
        }

        private PieceFactory CreatePieceFactory(PieceDataSorter pieceDataSorter)
        {
            GameObject piecePrefab = LoadPiecePrefab();
            return new PieceFactoryImplementation(piecePrefab, pieceDataSorter);
        }

        private List<PieceData> CreatePieceDataList(int amountOfData)
        {
            List<PieceData> pieceDataList = new List<PieceData>();

            for (int i = 0; i < amountOfData; i++)
            {
                pieceDataList.Add(new StubPieceData());
            }

            return pieceDataList;
        }

        private PieceData CreatePieceData()
        {
            return new StubPieceData();
        }

        private PieceFactory CreatePieceFactory()
        {
            GameObject piecePrefab = LoadPiecePrefab();
            return new PieceFactoryImplementation(piecePrefab);
        }

        private GameObject LoadPiecePrefab()
        {
            return Resources.Load("StubPiecePrefab") as GameObject;
        }
    }
}
