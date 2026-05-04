using UnityEngine;

namespace Code.Common.Extensions
{
    public static class RendererExtensions
    {
        public static Renderer SetColor(this Renderer renderer, string propertyName, Color color)
        {
            var propertyBlock = new MaterialPropertyBlock();
            
            renderer.GetPropertyBlock(propertyBlock);
            propertyBlock.SetColor(propertyName, color);
            renderer.SetPropertyBlock(propertyBlock);
            
            return renderer;
        }
    }
}