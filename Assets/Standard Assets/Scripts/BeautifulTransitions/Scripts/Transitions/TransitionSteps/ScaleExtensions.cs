using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public static class ScaleExtensions
	{
		public static Scale Scale(this TransitionStep transitionStep, Vector3 startScale, Vector3 endScale, float delay = 0f, float duration = 0.5f, TransitionStep.TransitionModeType transitionMode = TransitionStep.TransitionModeType.Specified, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			Scale scale = new Scale(transitionStep.Target, startScale, endScale, delay, duration, transitionMode, timeUpdateMethod, tweenType, animationCurve, onStart, onUpdate, onComplete);
			scale.AddToChain(transitionStep, runAtStart);
			return scale;
		}

		public static Scale ScaleToOriginal(this TransitionStep transitionStep, Vector3 startScale, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.Scale(startScale, Vector3.zero, delay, duration, TransitionStep.TransitionModeType.ToOriginal, timeUpdateMethod, tweenType, animationCurve, runAtStart, onStart, onUpdate, onComplete);
		}

		public static Scale ScaleToCurrent(this TransitionStep transitionStep, Vector3 startScale, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.Scale(startScale, Vector3.zero, delay, duration, TransitionStep.TransitionModeType.ToCurrent, timeUpdateMethod, tweenType, animationCurve, runAtStart, onStart, onUpdate, onComplete);
		}

		public static Scale ScaleFromOriginal(this TransitionStep transitionStep, Vector3 endScale, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.Scale(Vector3.zero, endScale, delay, duration, TransitionStep.TransitionModeType.FromOriginal, timeUpdateMethod, tweenType, animationCurve, runAtStart, onStart, onUpdate, onComplete);
		}

		public static Scale ScaleFromCurrent(this TransitionStep transitionStep, Vector3 endScale, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.Scale(Vector3.zero, endScale, delay, duration, TransitionStep.TransitionModeType.FromCurrent, timeUpdateMethod, tweenType, animationCurve, runAtStart, onStart, onUpdate, onComplete);
		}
	}
}
