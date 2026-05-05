using System.Collections.Generic;
using System.Linq;
using Code.Gameplay.Board.Behaviour;
using Code.Gameplay.Board.Factory;
using UnityEngine;

namespace Code.Gameplay.Board.Service
{
    public class BoardService
    {
        private readonly BoardFactory boardFactory;
        
        private Cell[] board;
        private int boardSize;

        public BoardService(BoardFactory boardFactory)
        {
            this.boardFactory = boardFactory;
        }

        public void Create(int size, Color white, Color black)
        {
            board = boardFactory.Create(size, white, black);
            boardSize = board.Length / 2;
        }

        public List<Vector3> GetCellInCircle(float radius)
        {
            var result = new List<Vector3>();
        
            if (board == null || boardSize <= 0)
                return result;

            var cellSize = board.First().Size;
            var halfBoard = (boardSize * cellSize) * 0.5f;
            var start = -halfBoard + cellSize * 0.5f;

            var radiusSqr = radius * radius;

            for (var x = 0; x < boardSize; x++)
            {
                for (var y = 0; y < boardSize; y++)
                {
                    var posX = start + x * cellSize;
                    var posZ = start + y * cellSize;

                    var distanceSqr = posX * posX + posZ * posZ;

                    if (distanceSqr <= radiusSqr)
                    {
                        result.Add(new Vector3(posX, 0f, posZ));
                    }
                }
            }

            return result;
        }
    }
}