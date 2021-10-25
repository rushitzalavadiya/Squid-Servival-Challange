using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using System.Linq;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public class VolumeTransition : TransitionStepFloat
	{
		private AudioSource[] _audioSources = new AudioSource[0];

		private bool _hasComponentReferences;

		public VolumeTransition(GameObject target, float startVolume = 0f, float endVolume = 1f, float delay = 0f, float duration = 0.5f, TransitionModeType transitionMode = TransitionModeType.Specified, TimeUpdateMethodType timeUpdateMethod = TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
			: base(target, startVolume, endVolume, delay, duration, transitionMode, timeUpdateMethod, tweenType, animationCurve, CoordinateSpaceType.Global, onStart, onUpdate, onComplete)
		{
		}

		public override float GetCurrent()
		{
			if (!_hasComponentReferences)
			{
				SetupComponentReferences();
			}
			if (_audioSources.Length != 0)
			{
				return _audioSources[0].volume;
			}
			return 1f;
		}

		public override void SetCurrent(float volume)
		{
			if (!_hasComponentReferences)
			{
				SetupComponentReferences();
			}
			AudioSource[] audioSources = _audioSources;
			for (int i = 0; i < audioSources.Length; i++)
			{
				audioSources[i].volume = volume;
			}
		}

		private void SetupComponentReferences()
		{
			_audioSources = new AudioSource[0];
			AudioSource component = base.Target.GetComponent<AudioSource>();
			if (component != null)
			{
				_audioSources = _audioSources.Concat(Enumerable.Repeat(component, 1)).ToArray();
			}
			_hasComponentReferences = true;
		}
	}
}
