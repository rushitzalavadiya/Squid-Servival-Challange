using BeautifulTransitions.Scripts.Transitions.Components.GameObject.AbstractClasses;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.Components.GameObject
{
	[AddComponentMenu("Beautiful Transitions/GameObject + UI/Fade Transition")]
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/")]
	public class TransitionFade : TransitionGameObjectBase
	{
		[Serializable]
		public class InSettings
		{
			[Tooltip("Normalised transparency at the start of the transition (ends at the GameObjects initial transparency).")]
			public float StartTransparency;
		}

		[Serializable]
		public class OutSettings
		{
			[Tooltip("Normalised transparency at the end of the transition (starts at the GameObjects current transparency).")]
			public float EndTransparency;
		}

		[Header("Fade Specific")]
		public InSettings FadeInConfig;

		public OutSettings FadeOutConfig;

		private float _originalTransparency;

		public override void SetupInitialState()
		{
			_originalTransparency = ((Fade)CreateTransitionStep()).OriginalValue;
		}

		public override TransitionStep CreateTransitionStep()
		{
			return new Fade(Target);
		}

		public override void SetupTransitionStepIn(TransitionStep transitionStep)
		{
			Fade fade = transitionStep as Fade;
			if (fade != null)
			{
				fade.StartValue = FadeInConfig.StartTransparency;
				fade.EndValue = _originalTransparency;
			}
			base.SetupTransitionStepIn(transitionStep);
		}

		public override void SetupTransitionStepOut(TransitionStep transitionStep)
		{
			Fade fade = transitionStep as Fade;
			if (fade != null)
			{
				fade.StartValue = fade.GetCurrent();
				fade.EndValue = FadeOutConfig.EndTransparency;
			}
			base.SetupTransitionStepOut(transitionStep);
		}
	}
}
