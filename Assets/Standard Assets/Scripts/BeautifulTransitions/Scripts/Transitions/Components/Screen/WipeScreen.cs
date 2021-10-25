using BeautifulTransitions.Scripts.Transitions.Components.Screen.AbstractClasses;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.Components.Screen
{
	[AddComponentMenu("Beautiful Transitions/Screen/Wipe Screen Transition")]
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/")]
	[ExecuteInEditMode]
	public class WipeScreen : TransitionScreenBase
	{
		[Serializable]
		public class InSettings
		{
			[Tooltip("Optional overlay texture to use.")]
			public Texture2D Texture;

			[Tooltip("Tint color.")]
			public Color Color = Color.white;

			[Tooltip("Gray scale wipe mask.")]
			public Texture2D MaskTexture;

			[Tooltip("Whether to invery the wipe mask.")]
			public bool InvertMask;

			[Tooltip("The amount of softness to apply to the wipe")]
			[Range(0f, 1f)]
			public float Softness;

			[Tooltip("Skip running this if there is already a cross transition in progress. Useful for e.g. your entry scene where on first run you enter directly (running this transition), but might later cross transition to from another scene and so not want this transition to run.")]
			public bool SkipOnCrossTransition = true;
		}

		[Serializable]
		public class OutSettings
		{
			[Tooltip("Optional overlay texture to use.")]
			public Texture2D Texture;

			[Tooltip("Tint color.")]
			public Color Color = Color.white;

			[Tooltip("Gray scale wipe mask. Look in the folder 'FlipWebApps\\BeautifulTransitions\\Textures' for sample mask textures you can drag and add here.")]
			public Texture2D MaskTexture;

			[Tooltip("Whether to invert the wipe mask.")]
			public bool InvertMask;

			[Tooltip("The amount of softness to apply to the wipe.")]
			[Range(0f, 1f)]
			public float Softness;

			[Tooltip("Whether and how to transition to a new scene.")]
			public TransitionStepScreen.SceneChangeModeType SceneChangeMode;

			[Tooltip("If transitioning to a new scene then the name of the scene to transition to.")]
			public string SceneToLoad;
		}

		[Header("Wipe Specific")]
		public InSettings InConfig;

		public OutSettings OutConfig;

		public override TransitionStep CreateTransitionStep()
		{
			return new ScreenWipe(base.gameObject, null);
		}

		public override void SetupTransitionStepIn(TransitionStep transitionStep)
		{
			ScreenWipe screenWipe = transitionStep as ScreenWipe;
			if (screenWipe != null)
			{
				screenWipe.MaskTexture = InConfig.MaskTexture;
				screenWipe.InvertMask = InConfig.InvertMask;
				screenWipe.Color = InConfig.Color;
				screenWipe.Texture = InConfig.Texture;
				screenWipe.Softness = InConfig.Softness;
				screenWipe.SkipOnCrossTransition = InConfig.SkipOnCrossTransition;
			}
			base.SetupTransitionStepIn(transitionStep);
		}

		public override void SetupTransitionStepOut(TransitionStep transitionStep)
		{
			ScreenWipe screenWipe = transitionStep as ScreenWipe;
			if (screenWipe != null)
			{
				screenWipe.MaskTexture = OutConfig.MaskTexture;
				screenWipe.InvertMask = OutConfig.InvertMask;
				screenWipe.Color = OutConfig.Color;
				screenWipe.Texture = OutConfig.Texture;
				screenWipe.Softness = OutConfig.Softness;
				screenWipe.SceneChangeMode = OutConfig.SceneChangeMode;
				screenWipe.SceneToLoad = OutConfig.SceneToLoad;
			}
			base.SetupTransitionStepOut(transitionStep);
		}
	}
}
