using BeautifulTransitions.Scripts.Transitions.Components.Screen.AbstractClasses;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.Components.Screen
{
	[AddComponentMenu("Beautiful Transitions/Screen/Fade Screen Transition")]
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/")]
	[ExecuteInEditMode]
	public class FadeScreen : TransitionScreenBase
	{
		[Serializable]
		public class InSettings
		{
			[Tooltip("Optional overlay texture to use.")]
			public Texture2D Texture;

			[Tooltip("Tint color.")]
			public Color Color = Color.black;

			[Tooltip("Skip running this if there is already a cross transition in progress. Useful for e.g. your entry scene where on first run you enter directly (running this transition), but might later cross transition to from another scene and so not want this transition to run.")]
			public bool SkipOnCrossTransition = true;
		}

		[Serializable]
		public class OutSettings
		{
			[Tooltip("Optional overlay texture to use.")]
			public Texture2D Texture;

			[Tooltip("Tint color.")]
			public Color Color = Color.black;

			[Tooltip("Whether and how to transition to a new scene.")]
			public TransitionStepScreen.SceneChangeModeType SceneChangeMode;

			[Tooltip("If transitioning to a new scene then the name of the scene to transition to.")]
			public string SceneToLoad;
		}

		[Header("Fade Specific")]
		public InSettings InConfig;

		public OutSettings OutConfig;

		public override TransitionStep CreateTransitionStep()
		{
			return new ScreenFade(base.gameObject);
		}

		public override void SetupTransitionStepIn(TransitionStep transitionStep)
		{
			ScreenFade screenFade = transitionStep as ScreenFade;
			if (screenFade != null)
			{
				screenFade.Color = InConfig.Color;
				screenFade.Texture = InConfig.Texture;
				screenFade.SkipOnCrossTransition = InConfig.SkipOnCrossTransition;
			}
			base.SetupTransitionStepIn(transitionStep);
		}

		public override void SetupTransitionStepOut(TransitionStep transitionStep)
		{
			ScreenFade screenFade = transitionStep as ScreenFade;
			if (screenFade != null)
			{
				screenFade.Color = OutConfig.Color;
				screenFade.Texture = OutConfig.Texture;
				screenFade.SceneChangeMode = OutConfig.SceneChangeMode;
				screenFade.SceneToLoad = OutConfig.SceneToLoad;
			}
			base.SetupTransitionStepOut(transitionStep);
		}
	}
}
