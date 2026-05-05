using Code.Gameplay.Board.Behaviour;
using UnityEngine;

namespace Code.Infrastructure.Loaders.StaticData
{
    public class StaticDataProvider
    {
        private const string BoardCellPath = "Gameplay/BoardCell/Cell";
        
        private Cell cellTemplate;

        public void Initialize()
        {
            LoadCellTemplate();
        }

        public Cell GetCellTemplate() => cellTemplate;

        private void LoadCellTemplate() =>
            cellTemplate = Resources
                .Load<Cell>(BoardCellPath);
    }
}