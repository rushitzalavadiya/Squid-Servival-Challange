using BeautifulTransitions.Scripts.Transitions.Components.Camera.AbstractClasses;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.Components.Camera
{
	[ExecuteInEditMode]
	[AddComponentMenu("Beautiful Transitions/Camera/Wipe Camera Transition")]
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/")]
	public class WipeCamera : TransitionCameraBase
	{
		[Serializable]
		public class InSettings
		{
			[Tooltip("Optional overlay texture to use.")]
			public Texture2D Texture;

			[Tooltip("Tint color.")]
			public Color Color = Color.white;

			[Tooltip("Gray scale wipe mask. Look in the folder 'FlipWebApps\\BeautifulTransitions\\Textures' for sample mask textures you can drag and add here.")]
			public Texture2D MaskTexture;

			[Tooltip("Whether to invery the wipe mask.")]
			public bool InvertMask;

			[Tooltip("The amount of softness to apply to the wipe.")]
			[Range(0f, 1f)]
			public float Softness;
		}

		[Serializable]
		public class OutSettings
		{
			[Tooltip("Optional overlay texture to use.")]
			public Texture2D Texture;

			[Tooltip("Tint color.")]
			public Color Color = Color.white;

			[Tooltip("Gray scale wipe mask.")]
			public Texture2D MaskTexture;

			[Tooltip("Whether to invery the wipe mask.")]
			public bool InvertMask;

			[Tooltip("The amount of softness to apply to the wipe.")]
			[Range(0f, 1f)]
			public float Softness;
		}

		[Header("Wipe Specific")]
		public InSettings InConfig;

		public OutSettings OutConfig;

		private Material _material;

		public void Awake()
		{
			Shader shader = Shader.Find("Hidden/FlipWebApps/BeautifulTransitions/WipeCamera");
			if (shader != null && shader.isSupported)
			{
				_material = new Material(shader);
			}
			else
			{
				UnityEngine.Debug.Log("WipeCamera: Shader is not found or supported on this platform.");
			}
		}

		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
			TransitionStepFloat transitionStepFloat = base.CurrentTransitionStep as TransitionStepFloat;
			if (transitionStepFloat != null && _material != null && !Mathf.Approximately(transitionStepFloat.Value, 0f))
			{
				if (CrossTransitionTarget != null)
				{
					_material.SetTexture("_OverlayTex", CrossTransitionRenderTexture);
				}
				else
				{
					_material.SetTexture("_OverlayTex", (base.TransitionMode == TransitionModeType.In) ? InConfig.Texture : OutConfig.Texture);
				}
				_material.SetColor("_Color", (base.TransitionMode == TransitionModeType.In) ? InConfig.Color : OutConfig.Color);
				_material.SetTexture("_MaskTex", (base.TransitionMode == TransitionModeType.In) ? InConfig.MaskTexture : OutConfig.MaskTexture);
				_material.SetFloat("_Amount", transitionStepFloat.Value);
				if ((base.TransitionMode == TransitionModeType.In) ? InConfig.InvertMask : OutConfig.InvertMask)
				{
					_material.EnableKeyword("INVERT_MASK");
				}
				else
				{
					_material.DisableKeyword("INVERT_MASK");
				}
				_material.SetFloat("_Softness", (base.TransitionMode == TransitionModeType.In) ? InConfig.Softness : OutConfig.Softness);
				Graphics.Blit(source, destination, _material);
			}
			else
			{
				Graphics.Blit(source, destination);
			}
		}
	}
}
