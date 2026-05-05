using Code.Gameplay.Board.Behaviour;
using Code.Infrastructure.Loaders.StaticData;
using UnityEngine;

namespace Code.Gameplay.Board.Factory
{
    public class BoardFactory
    {
        private readonly StaticDataProvider staticDataProvider;

        public BoardFactory(StaticDataProvider staticDataProvider)
        {
            this.staticDataProvider = staticDataProvider;
        }
        
        public Cell[] Create(int size, Color white, Color black)
        {
            var cells = new Cell[size * size];
            
            for (var x = 0; x < size; x++)
            {
                for (var y = 0; y < size; y++)
                {
                    var cell = GameObject.Instantiate(staticDataProvider.GetCellTemplate());

                    cell.Setup(CalculatePosition(size, x, y, cell.Size), GetColor(white, black, (x + y) % 2 == 0));
                    cells[x + y] = cell;
                }
            }

            return cells;
        }

        private Vector3 CalculatePosition(int size, int x, int y, float cellSize)
        {
            var halfBoardSize = (size * cellSize) * 0.5f;
    
            var posX = -halfBoardSize + (x + 0.5f) * cellSize;
            var posZ = -halfBoardSize + (y + 0.5f) * cellSize;
    
            return new Vector3(posX, 0f, posZ);
        }

        private Color GetColor(Color white, Color black, bool isEven) => isEven ? white : black;
    }
}