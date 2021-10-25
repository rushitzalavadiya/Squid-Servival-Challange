using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public static class MoveExtensions
	{
		public static Move Move(this TransitionStep transitionStep, Vector3 startPosition, Vector3 endPosition, float delay = 0f, float duration = 0.5f, TransitionStep.TransitionModeType transitionMode = TransitionStep.TransitionModeType.Specified, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, TransitionStep.CoordinateSpaceType coordinateMode = TransitionStep.CoordinateSpaceType.Global, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			Move move = new Move(transitionStep.Target, startPosition, endPosition, delay, duration, transitionMode, timeUpdateMethod, tweenType, animationCurve, coordinateMode, onStart, onUpdate, onComplete);
			move.AddToChain(transitionStep, runAtStart);
			return move;
		}

		public static Move MoveToOriginal(this TransitionStep transitionStep, Vector3 startPosition, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, TransitionStep.CoordinateSpaceType coordinateMode = TransitionStep.CoordinateSpaceType.Global, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.Move(startPosition, Vector3.zero, delay, duration, TransitionStep.TransitionModeType.ToOriginal, timeUpdateMethod, tweenType, animationCurve, coordinateMode, runAtStart, onStart, onUpdate, onComplete);
		}

		public static Move MoveToCurrent(this TransitionStep transitionStep, Vector3 startPosition, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, TransitionStep.CoordinateSpaceType coordinateMode = TransitionStep.CoordinateSpaceType.Global, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.Move(startPosition, Vector3.zero, delay, duration, TransitionStep.TransitionModeType.ToCurrent, timeUpdateMethod, tweenType, animationCurve, coordinateMode, runAtStart, onStart, onUpdate, onComplete);
		}

		public static Move MoveFromOriginal(this TransitionStep transitionStep, Vector3 endPosition, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, TransitionStep.CoordinateSpaceType coordinateMode = TransitionStep.CoordinateSpaceType.Global, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.Move(Vector3.zero, endPosition, delay, duration, TransitionStep.TransitionModeType.FromOriginal, timeUpdateMethod, tweenType, animationCurve, coordinateMode, runAtStart, onStart, onUpdate, onComplete);
		}

		public static Move MoveFromCurrent(this TransitionStep transitionStep, Vector3 endPosition, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, TransitionStep.CoordinateSpaceType coordinateMode = TransitionStep.CoordinateSpaceType.Global, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.Move(Vector3.zero, endPosition, delay, duration, TransitionStep.TransitionModeType.FromCurrent, timeUpdateMethod, tweenType, animationCurve, coordinateMode, runAtStart, onStart, onUpdate, onComplete);
		}
	}
}
