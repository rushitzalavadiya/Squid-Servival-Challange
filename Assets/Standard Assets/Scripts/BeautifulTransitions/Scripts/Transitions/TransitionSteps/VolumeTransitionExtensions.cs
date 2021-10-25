using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public static class VolumeTransitionExtensions
	{
		public static VolumeTransition VolumeTransition(this TransitionStep transitionStep, float startVolume, float endVolume, float delay = 0f, float duration = 0.5f, TransitionStep.TransitionModeType transitionMode = TransitionStep.TransitionModeType.Specified, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			VolumeTransition volumeTransition = new VolumeTransition(transitionStep.Target, startVolume, endVolume, delay, duration, transitionMode, timeUpdateMethod, tweenType, animationCurve, onStart, onUpdate, onComplete);
			volumeTransition.AddToChain(transitionStep, runAtStart);
			return volumeTransition;
		}

		public static VolumeTransition VolumeToOriginal(this TransitionStep transitionStep, float startVolume, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.VolumeTransition(startVolume, 0f, delay, duration, TransitionStep.TransitionModeType.ToOriginal, timeUpdateMethod, tweenType, animationCurve, runAtStart, onStart, onUpdate, onComplete);
		}

		public static VolumeTransition VolumeToCurrent(this TransitionStep transitionStep, float startVolume, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.VolumeTransition(startVolume, 0f, delay, duration, TransitionStep.TransitionModeType.ToCurrent, timeUpdateMethod, tweenType, animationCurve, runAtStart, onStart, onUpdate, onComplete);
		}

		public static VolumeTransition VolumeFromOriginal(this TransitionStep transitionStep, float endVolume, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.VolumeTransition(0f, endVolume, delay, duration, TransitionStep.TransitionModeType.FromOriginal, timeUpdateMethod, tweenType, animationCurve, runAtStart, onStart, onUpdate, onComplete);
		}

		public static VolumeTransition VolumeFromCurrent(this TransitionStep transitionStep, float endVolume, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.VolumeTransition(0f, endVolume, delay, duration, TransitionStep.TransitionModeType.FromCurrent, timeUpdateMethod, tweenType, animationCurve, runAtStart, onStart, onUpdate, onComplete);
		}
	}
}
