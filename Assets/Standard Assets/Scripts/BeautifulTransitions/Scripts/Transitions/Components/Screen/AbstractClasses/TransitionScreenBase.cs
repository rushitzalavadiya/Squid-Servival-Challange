using BeautifulTransitions.Scripts.Transitions.TransitionSteps;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.Components.Screen.AbstractClasses
{
	[ExecuteInEditMode]
	public abstract class TransitionScreenBase : TransitionBase
	{
		public override void SetupTransitionStepIn(TransitionStep transitionStep)
		{
			TransitionStepFloat transitionStepFloat = transitionStep as TransitionStepFloat;
			if (transitionStepFloat != null)
			{
				transitionStepFloat.StartValue = 1f;
				transitionStepFloat.EndValue = 0f;
			}
			base.SetupTransitionStepIn(transitionStep);
		}

		public override void SetupTransitionStepOut(TransitionStep transitionStep)
		{
			TransitionStepFloat transitionStepFloat = transitionStep as TransitionStepFloat;
			if (transitionStepFloat != null)
			{
				transitionStepFloat.StartValue = 0f;
				transitionStepFloat.EndValue = 1f;
			}
			base.SetupTransitionStepOut(transitionStep);
		}
	}
}
