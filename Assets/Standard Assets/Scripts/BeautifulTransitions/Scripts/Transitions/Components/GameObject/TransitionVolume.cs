using BeautifulTransitions.Scripts.Transitions.Components.GameObject.AbstractClasses;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.Components.GameObject
{
	[AddComponentMenu("Beautiful Transitions/GameObject + UI/Volume Transition")]
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/")]
	public class TransitionVolume : TransitionGameObjectBase
	{
		[Serializable]
		public class InSettings
		{
			[Tooltip("Normalised volume at the start of the transition (ends at the GameObjects initial volume).")]
			public float StartVolume;
		}

		[Serializable]
		public class OutSettings
		{
			[Tooltip("Normalised volume at the end of the transition (starts at the GameObjects current volume).")]
			public float EndVolume;
		}

		[Header("Volume Specific")]
		public InSettings InConfig;

		public OutSettings OutConfig;

		private float _originalVolume;

		public override void SetupInitialState()
		{
			_originalVolume = ((VolumeTransition)CreateTransitionStep()).OriginalValue;
		}

		public override TransitionStep CreateTransitionStep()
		{
			return new VolumeTransition(Target);
		}

		public override void SetupTransitionStepIn(TransitionStep transitionStep)
		{
			VolumeTransition volumeTransition = transitionStep as VolumeTransition;
			if (volumeTransition != null)
			{
				volumeTransition.StartValue = InConfig.StartVolume;
				volumeTransition.EndValue = _originalVolume;
			}
			base.SetupTransitionStepIn(transitionStep);
		}

		public override void SetupTransitionStepOut(TransitionStep transitionStep)
		{
			VolumeTransition volumeTransition = transitionStep as VolumeTransition;
			if (volumeTransition != null)
			{
				volumeTransition.StartValue = volumeTransition.GetCurrent();
				volumeTransition.EndValue = OutConfig.EndVolume;
			}
			base.SetupTransitionStepOut(transitionStep);
		}
	}
}
