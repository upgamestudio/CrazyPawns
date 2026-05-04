using Code.Gameplay.Cell.Behaviour;
using UnityEngine;

namespace Code.Infrastructure.Loaders.StaticData
{
    public class StaticDataProvider
    {
        private const string BoardCellPath = "Gameplay/BoardCell/Cell";
        
        private CellView cellTemplate;

        public void Initialize()
        {
            LoadCellTemplate();
        }

        public CellView GetCellTemplate() => cellTemplate;

        private void LoadCellTemplate() =>
            cellTemplate = Resources
                .Load<CellView>(BoardCellPath);
    }
}