// using UnityEngine;
//
// namespace SleekRender
// {
// 	public static class HelperExtensions
// 	{
// 		public static void DestroyImmediateIfNotNull(this Object obj)
// 		{
// 			if (obj != null)
// 			{
// 				UnityEngine.Object.DestroyImmediate(obj);
// 			}
// 		}
//
// 		public static RenderTexture CreateTransientRenderTexture(string textureName, int width, int height)
// 		{
// 			return new RenderTexture(width, height, 0, RenderTextureFormat.ARGB32)
// 			{
// 				name = textureName,
// 				filterMode = FilterMode.Bilinear,
// 				wrapMode = TextureWrapMode.Clamp
// 			};
// 		}
//
// 		public static Material CreateMaterialFromShader(string shaderName)
// 		{
// 			return new Material(Shader.Find(shaderName));
// 		}
//
// 		public static Vector4 GetLuminanceThreshold(SleekRenderSettings settings)
// 		{
// 			float num = 1f / (1f - settings.bloomThreshold);
// 			Vector3 bloomLumaVector = settings.bloomLumaVector;
// 			return new Vector4(bloomLumaVector.x * num, bloomLumaVector.y * num, bloomLumaVector.z * num, (0f - settings.bloomThreshold) * num);
// 		}
// 	}
// }
