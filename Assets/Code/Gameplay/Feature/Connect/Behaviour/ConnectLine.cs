using UnityEngine;

namespace Code.Gameplay.Feature.Connect.Behaviour
{
    public class ConnectLine : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        
        public void Setup(params Vector3[] positions)
        {
            lineRenderer.SetPositions(positions);
        }
    }
}