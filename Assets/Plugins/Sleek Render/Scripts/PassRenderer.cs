// using UnityEngine;
//
// namespace SleekRender
// {
// 	public class PassRenderer
// 	{
// 		private Mesh _fullscreenQuadMesh;
//
// 		public PassRenderer()
// 		{
// 			_fullscreenQuadMesh = CreateScreenSpaceQuadMesh();
// 		}
//
// 		public void Blit(Texture source, RenderTexture destination, Material material, int materialPass = 0)
// 		{
// 			SetActiveRenderTextureAndClear(destination);
// 			DrawFullscreenQuad(source, material, materialPass);
// 		}
//
// 		public void DrawFullscreenQuad(Texture source, Material material, int materialPass = 0)
// 		{
// 			material.SetTexture(Uniforms._MainTex, source);
// 			material.SetPass(materialPass);
// 			Graphics.DrawMeshNow(_fullscreenQuadMesh, Matrix4x4.identity);
// 		}
//
// 		public void SetActiveRenderTextureAndClear(RenderTexture destination)
// 		{
// 			RenderTexture.active = destination;
// 			GL.Clear(clearDepth: true, clearColor: true, new Color(1f, 0.75f, 0.5f, 0.8f));
// 		}
//
// 		private Mesh CreateScreenSpaceQuadMesh()
// 		{
// 			Mesh mesh = new Mesh();
// 			Vector3[] vertices = new Vector3[4]
// 			{
// 				new Vector3(-1f, -1f, 0f),
// 				new Vector3(-1f, 1f, 0f),
// 				new Vector3(1f, 1f, 0f),
// 				new Vector3(1f, -1f, 0f)
// 			};
// 			Vector2[] uv = new Vector2[4]
// 			{
// 				new Vector2(0f, 0f),
// 				new Vector2(0f, 1f),
// 				new Vector2(1f, 1f),
// 				new Vector2(1f, 0f)
// 			};
// 			Color[] colors = new Color[4]
// 			{
// 				new Color(0f, 0f, 1f),
// 				new Color(0f, 1f, 1f),
// 				new Color(1f, 1f, 1f),
// 				new Color(1f, 0f, 1f)
// 			};
// 			int[] triangles = new int[6]
// 			{
// 				0,
// 				2,
// 				1,
// 				0,
// 				3,
// 				2
// 			};
// 			mesh.vertices = vertices;
// 			mesh.uv = uv;
// 			mesh.triangles = triangles;
// 			mesh.colors = colors;
// 			mesh.UploadMeshData(markNoLongerReadable: true);
// 			return mesh;
// 		}
// 	}
// }
