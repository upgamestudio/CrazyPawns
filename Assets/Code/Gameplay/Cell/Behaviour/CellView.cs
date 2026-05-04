using Code.Common.Extensions;
using UnityEngine;

namespace Code.Gameplay.Cell.Behaviour
{
    public class CellView : MonoBehaviour
    {
        [SerializeField] private Renderer renderer;
        
        public void Setup(Color color)
        {
            renderer.SetColor("Color", color);
        }
    }
}