using Code.Gameplay.Cell.Behaviour;
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
        
        public CellView[,] Create(int size, Color white, Color black)
        {
            var cells = new CellView[size, size];
            
            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    var cell = GameObject.Instantiate(staticDataProvider.GetCellTemplate());

                    cell.Setup(GetColor(white, black, x + y % 2 == 0));
                    cells[x, y] = cell;
                }
            }

            return cells;
        }

        private Color GetColor(Color white, Color black, bool isEven) => isEven ? white : black;
    }
}