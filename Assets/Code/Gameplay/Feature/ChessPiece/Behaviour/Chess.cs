using UnityEngine;

namespace Code.Gameplay.Feature.ChessPiece.Behaviour
{
    public class Chess : MonoBehaviour
    {
        public void Setup(Vector3 at)
        {
            transform.position = at;
        }
    }
}