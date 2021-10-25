// using UnityEngine;
//
// namespace SleekRender
// {
// 	public class DualFilterBloomRenderer
// 	{
// 		private RenderTexture[] _blurTextures;
//
// 		private Material _brightpassBlurMaterial;
//
// 		private Material _downsampleBlurMaterial;
//
// 		private PassRenderer _renderer;
//
// 		private int _bloomPasses;
//
// 		private int _baseTextureHeight;
//
// 		private int _baseTextureWidth;
//
// 		private bool _preserveAspectRatio;
//
// 		public DualFilterBloomRenderer(PassRenderer renderer)
// 		{
// 			_renderer = renderer;
// 		}
//
// 		public RenderTexture ApplyToAndReturn(RenderTexture source, SleekRenderSettings settings)
// 		{
// 			Vector4 luminanceThreshold = HelperExtensions.GetLuminanceThreshold(settings);
// 			_brightpassBlurMaterial.SetVector(Uniforms._LuminanceThreshold, luminanceThreshold);
// 			_brightpassBlurMaterial.SetVector(Uniforms._TexelSize, new Vector2(1f / (float)_blurTextures[0].width, 1f / (float)_blurTextures[0].height));
// 			RenderTexture renderTexture = _blurTextures[0];
// 			RenderTexture source2 = _blurTextures[0];
// 			int num = _blurTextures.Length;
// 			for (int i = 0; i < num; i++)
// 			{
// 				renderTexture = _blurTextures[i];
// 				if (i == 0)
// 				{
// 					_renderer.Blit(source, renderTexture, _brightpassBlurMaterial);
// 				}
// 				else
// 				{
// 					_downsampleBlurMaterial.SetVector(Uniforms._TexelSize, new Vector2(1f / (float)renderTexture.width, 1f / (float)renderTexture.height));
// 					_renderer.Blit(source2, renderTexture, _downsampleBlurMaterial);
// 				}
// 				source2 = renderTexture;
// 			}
// 			return renderTexture;
// 		}
//
// 		public void CreateResources(SleekRenderSettings settings, Camera camera)
// 		{
// 			_bloomPasses = settings.bloomPasses;
// 			_preserveAspectRatio = settings.preserveAspectRatio;
// 			CalculateBloomHeightAndWidth(settings, camera);
// 			if (_bloomPasses == 3)
// 			{
// 				_blurTextures = new RenderTexture[3];
// 				_blurTextures[0] = HelperExtensions.CreateTransientRenderTexture("Brightpass Blur 0", _baseTextureWidth, _baseTextureHeight);
// 				_blurTextures[1] = HelperExtensions.CreateTransientRenderTexture("Downsample Blur 1", _baseTextureWidth / 2, _baseTextureHeight / 2);
// 				_blurTextures[2] = HelperExtensions.CreateTransientRenderTexture("Downsample Blur 2", _baseTextureWidth, _baseTextureHeight);
// 			}
// 			else
// 			{
// 				_blurTextures = new RenderTexture[5];
// 				_blurTextures[0] = HelperExtensions.CreateTransientRenderTexture("Brightpass Blur 0", _baseTextureWidth, _baseTextureHeight);
// 				_blurTextures[1] = HelperExtensions.CreateTransientRenderTexture("Downsample Blur 1", _baseTextureWidth / 2, _baseTextureHeight / 2);
// 				_blurTextures[2] = HelperExtensions.CreateTransientRenderTexture("Downsample Blur 2", _baseTextureWidth / 4, _baseTextureHeight / 4);
// 				_blurTextures[3] = HelperExtensions.CreateTransientRenderTexture("Downsample Blur 4", _baseTextureWidth / 2, _baseTextureHeight / 2);
// 				_blurTextures[4] = HelperExtensions.CreateTransientRenderTexture("Downsample Blur 4", _baseTextureWidth, _baseTextureHeight);
// 			}
// 			_brightpassBlurMaterial = HelperExtensions.CreateMaterialFromShader("Sleek Render/Post Process/Brightpass Dualfilter Blur");
// 			_downsampleBlurMaterial = HelperExtensions.CreateMaterialFromShader("Sleek Render/Post Process/Downsample Dualfilter Blur");
// 		}
//
// 		private void CalculateBloomHeightAndWidth(SleekRenderSettings settings, Camera camera)
// 		{
// 			_baseTextureHeight = settings.bloomTextureHeight;
// 			if (settings.preserveAspectRatio)
// 			{
// 				_baseTextureWidth = Mathf.RoundToInt((float)_baseTextureHeight * camera.aspect);
// 			}
// 			else
// 			{
// 				_baseTextureWidth = settings.bloomTextureWidth;
// 			}
// 		}
//
// 		public bool SomeSettingsHaveChanged(SleekRenderSettings settings)
// 		{
// 			bool flag = !settings.preserveAspectRatio && settings.bloomTextureWidth != _baseTextureWidth;
// 			return (settings.bloomPasses != _bloomPasses || settings.bloomTextureHeight != _baseTextureHeight || settings.preserveAspectRatio != _preserveAspectRatio) | flag;
// 		}
//
// 		public void ReleaseResources()
// 		{
// 			if (_blurTextures != null)
// 			{
// 				RenderTexture[] blurTextures = _blurTextures;
// 				for (int i = 0; i < blurTextures.Length; i++)
// 				{
// 					blurTextures[i].DestroyImmediateIfNotNull();
// 				}
// 			}
// 			_blurTextures = null;
// 			_brightpassBlurMaterial.DestroyImmediateIfNotNull();
// 			_downsampleBlurMaterial.DestroyImmediateIfNotNull();
// 		}
// 	}
// }
