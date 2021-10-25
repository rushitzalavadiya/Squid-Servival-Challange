using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public static class RotateExtensions
	{
		public static Rotate Rotate(this TransitionStep transitionStep, Vector3 startRotation, Vector3 endRotation, float delay = 0f, float duration = 0.5f, TransitionStep.TransitionModeType transitionMode = TransitionStep.TransitionModeType.Specified, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, TransitionStep.CoordinateSpaceType coordinateMode = TransitionStep.CoordinateSpaceType.Global, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			Rotate rotate = new Rotate(transitionStep.Target, startRotation, endRotation, delay, duration, transitionMode, timeUpdateMethod, tweenType, animationCurve, coordinateMode, onStart, onUpdate, onComplete);
			rotate.AddToChain(transitionStep, runAtStart);
			return rotate;
		}

		public static Rotate RotateToOriginal(this TransitionStep transitionStep, Vector3 startRotation, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, TransitionStep.CoordinateSpaceType coordinateMode = TransitionStep.CoordinateSpaceType.Global, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.Rotate(startRotation, Vector3.zero, delay, duration, TransitionStep.TransitionModeType.ToOriginal, timeUpdateMethod, tweenType, animationCurve, coordinateMode, runAtStart, onStart, onUpdate, onComplete);
		}

		public static Rotate RotateToCurrent(this TransitionStep transitionStep, Vector3 startRotation, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, TransitionStep.CoordinateSpaceType coordinateMode = TransitionStep.CoordinateSpaceType.Global, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.Rotate(startRotation, Vector3.zero, delay, duration, TransitionStep.TransitionModeType.ToCurrent, timeUpdateMethod, tweenType, animationCurve, coordinateMode, runAtStart, onStart, onUpdate, onComplete);
		}

		public static Rotate RotateFromOriginal(this TransitionStep transitionStep, Vector3 endRotation, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, TransitionStep.CoordinateSpaceType coordinateMode = TransitionStep.CoordinateSpaceType.Global, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.Rotate(Vector3.zero, endRotation, delay, duration, TransitionStep.TransitionModeType.FromOriginal, timeUpdateMethod, tweenType, animationCurve, coordinateMode, runAtStart, onStart, onUpdate, onComplete);
		}

		public static Rotate RotateFromCurrent(this TransitionStep transitionStep, Vector3 endRotation, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, TransitionStep.CoordinateSpaceType coordinateMode = TransitionStep.CoordinateSpaceType.Global, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.Rotate(Vector3.zero, endRotation, delay, duration, TransitionStep.TransitionModeType.FromCurrent, timeUpdateMethod, tweenType, animationCurve, coordinateMode, runAtStart, onStart, onUpdate, onComplete);
		}
	}
}
