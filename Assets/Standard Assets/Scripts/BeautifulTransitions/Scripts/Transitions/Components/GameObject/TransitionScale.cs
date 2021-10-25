using BeautifulTransitions.Scripts.Transitions.Components.GameObject.AbstractClasses;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.Components.GameObject
{
	[AddComponentMenu("Beautiful Transitions/GameObject + UI/Scale Transition")]
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/")]
	public class TransitionScale : TransitionGameObjectBase
	{
		[Serializable]
		public class InSettings
		{
			[Tooltip("Start scale (end at the GameObjects initial scale).")]
			public Vector3 StartScale = new Vector3(0f, 0f, 0f);
		}

		[Serializable]
		public class OutSettings
		{
			[Tooltip("End scale (starts at the GameObjects current scale).")]
			public Vector3 EndScale = new Vector3(0f, 0f, 0f);
		}

		public InSettings InConfig;

		public OutSettings OutConfig;

		private Vector3 _originalScale;

		public override void SetupInitialState()
		{
			_originalScale = ((Scale)CreateTransitionStep()).OriginalValue;
		}

		public override TransitionStep CreateTransitionStep()
		{
			return new Scale(Target);
		}

		public override void SetupTransitionStepIn(TransitionStep transitionStep)
		{
			Scale scale = transitionStep as Scale;
			if (scale != null)
			{
				scale.StartValue = InConfig.StartScale;
				scale.EndValue = _originalScale;
			}
			base.SetupTransitionStepIn(transitionStep);
		}

		public override void SetupTransitionStepOut(TransitionStep transitionStep)
		{
			Scale scale = transitionStep as Scale;
			if (scale != null)
			{
				scale.StartValue = scale.GetCurrent();
				scale.EndValue = OutConfig.EndScale;
			}
			base.SetupTransitionStepOut(transitionStep);
		}
	}
}
