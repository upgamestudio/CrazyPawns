using UnityEngine;

namespace Code.Gameplay.Input.Services
{
    public class InputService
    {
        public Vector3 MousePosition => UnityEngine.Input.mousePosition;

        public bool GetMouseButtonDown() => UnityEngine.Input.GetMouseButtonDown(0);
        public bool GetMouseButton() => UnityEngine.Input.GetMouseButton(0);
        public bool GetMouseButtonUp() => UnityEngine.Input.GetMouseButtonUp(0);
    }
}