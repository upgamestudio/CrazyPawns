using Code.Gameplay.Board.Factory;
using Code.Gameplay.Board.Service;
using Code.Infrastructure.Loaders.StaticData;
using UnityEngine;

namespace CrazyPawn.Infrastructure.Initializer
{
    public class Bootstrapper : MonoBehaviour
    {
        [SerializeField] private CrazyPawnSettings settings;
        
        private void Awake()
        {
            var staticDataProvider = new StaticDataProvider();
            
            staticDataProvider.Initialize();
            
            var boardService = new BoardService(new BoardFactory(staticDataProvider));

            boardService.Create(settings.CheckerboardSize, settings.WhiteCellColor, settings.BlackCellColor);
        }
    }
}

