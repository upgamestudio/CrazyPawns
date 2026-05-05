using UnityEngine;

namespace Code.Common.Extensions
{
    public static class RendererExtensions
    {
        private const string ColorPropertyName = "_BaseColor";

        public static Renderer SetColor(this Renderer renderer, Color color)
        {
            var propertyBlock = new MaterialPropertyBlock();
            
            renderer.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor(ColorPropertyName, color);
            renderer.SetPropertyBlock(propertyBlock);
            
            return renderer;
        }
    }
}