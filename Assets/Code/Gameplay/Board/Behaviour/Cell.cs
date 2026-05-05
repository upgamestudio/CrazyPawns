using Code.Common.Extensions;
using UnityEngine;

namespace Code.Gameplay.Board.Behaviour
{
    public class Cell : MonoBehaviour
    {
        [SerializeField] private Renderer renderer;

        public float Size => transform.localScale.x;
        
        public void Setup(Vector3 at, Color color)
        {
            transform.position = at;
            renderer.SetColor(color);
        }
    }
}