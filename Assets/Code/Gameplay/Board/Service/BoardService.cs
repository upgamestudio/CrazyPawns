using Code.Gameplay.Board.Behaviour;
using Code.Gameplay.Board.Factory;
using UnityEngine;

namespace Code.Gameplay.Board.Service
{
    public class BoardService
    {
        private readonly BoardFactory boardFactory;
        
        private Cell[] board;

        public BoardService(BoardFactory boardFactory)
        {
            this.boardFactory = boardFactory;
        }

        public void Create(int size, Color white, Color black)
        {
            board = boardFactory.Create(size, white, black);
        }
    }
}