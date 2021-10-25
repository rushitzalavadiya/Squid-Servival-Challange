using BeautifulTransitions.Scripts.Transitions.Components.GameObject.AbstractClasses;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.Components.GameObject
{
	[AddComponentMenu("Beautiful Transitions/GameObject + UI/Color Transition")]
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/")]
	public class TransitionColor : TransitionGameObjectBase
	{
		[Serializable]
		public class InSettings
		{
			[Tooltip("Gradient to use for the transition in. Note the end color will be overridden with the current color when the transition runs.")]
			public Gradient Gradient;
		}

		[Serializable]
		public class OutSettings
		{
			[Tooltip("Gradient to use for the transition out. Note the start color will be overridden with the current color when the transition runs.")]
			public Gradient Gradient;
		}

		public InSettings InConfig;

		public OutSettings OutConfig;

		private Color _originalColor;

		public override void SetupInitialState()
		{
			_originalColor = ((ColorTransition)CreateTransitionStep()).OriginalValue;
		}

		public override TransitionStep CreateTransitionStep()
		{
			return new ColorTransition(Target);
		}

		public override void SetupTransitionStepIn(TransitionStep transitionStep)
		{
			ColorTransition colorTransition = transitionStep as ColorTransition;
			if (colorTransition != null)
			{
				colorTransition.Gradient = InConfig.Gradient;
				colorTransition.EndValue = _originalColor;
			}
			base.SetupTransitionStepIn(transitionStep);
		}

		public override void SetupTransitionStepOut(TransitionStep transitionStep)
		{
			ColorTransition colorTransition = transitionStep as ColorTransition;
			if (colorTransition != null)
			{
				colorTransition.Gradient = OutConfig.Gradient;
				colorTransition.StartValue = colorTransition.GetCurrent();
			}
			base.SetupTransitionStepOut(transitionStep);
		}
	}
}
