using BeautifulTransitions.Scripts.Transitions.Components.Camera.AbstractClasses;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.Components.Camera
{
	[ExecuteInEditMode]
	[AddComponentMenu("Beautiful Transitions/Camera/Fade Camera Transition")]
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/")]
	public class FadeCamera : TransitionCameraBase
	{
		[Serializable]
		public class InSettings
		{
			[Tooltip("Optional overlay texture to use.")]
			public Texture2D Texture;

			[Tooltip("Tint color.")]
			public Color Color;
		}

		[Serializable]
		public class OutSettings
		{
			[Tooltip("Optional overlay texture to use.")]
			public Texture2D Texture;

			[Tooltip("Tint color.")]
			public Color Color;
		}

		[Header("Fade Specific")]
		public InSettings InConfig;

		public OutSettings OutConfig;

		private Material _material;

		public void Awake()
		{
			Shader shader = Shader.Find("Hidden/FlipWebApps/BeautifulTransitions/FadeCamera");
			if (shader != null && shader.isSupported)
			{
				_material = new Material(shader);
			}
			else
			{
				UnityEngine.Debug.Log("FadeCamera: Shader is not found or supported on this platform.");
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
				_material.SetFloat("_Amount", transitionStepFloat.Value);
				Graphics.Blit(source, destination, _material);
			}
			else
			{
				Graphics.Blit(source, destination);
			}
		}
	}
}
