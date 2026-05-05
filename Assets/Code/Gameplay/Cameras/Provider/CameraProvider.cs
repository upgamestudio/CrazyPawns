using UnityEngine;

namespace Code.Gameplay.Cameras.Provider
{
    public class CameraProvider
    {
        public Camera MainCamera { get; private set; }

        public void SetMainCamera(Camera camera) => MainCamera = camera;
    }
}