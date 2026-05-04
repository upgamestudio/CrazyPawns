using Code.Gameplay.Board.Factory;
using UnityEngine;

namespace Code.Gameplay.Board.Service
{
    public class BoardService
    {
        private readonly BoardFactory boardFactory;

        public BoardService(BoardFactory boardFactory)
        {
            this.boardFactory = boardFactory;
        }

        public void Create(int size, Color white, Color black)
        {
            boardFactory.Create(size, white, black);
        }
    }
}