using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public static class ColorTransitionExtensions
	{
		public static ColorTransition ColorTransition(this TransitionStep transitionStep, Gradient gradient, float delay = 0f, float duration = 0.5f, TransitionStep.TransitionModeType transitionMode = TransitionStep.TransitionModeType.Specified, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			ColorTransition colorTransition = new ColorTransition(transitionStep.Target, gradient, delay, duration, transitionMode, timeUpdateMethod, tweenType, animationCurve, onStart, onUpdate, onComplete);
			colorTransition.AddToChain(transitionStep, runAtStart);
			return colorTransition;
		}

		public static ColorTransition ColorTransitionToOriginal(this TransitionStep transitionStep, Gradient gradient, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.ColorTransition(gradient, delay, duration, TransitionStep.TransitionModeType.ToOriginal, timeUpdateMethod, tweenType, animationCurve, runAtStart, onStart, onUpdate, onComplete);
		}

		public static ColorTransition ColorTransitionToCurrent(this TransitionStep transitionStep, Gradient gradient, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.ColorTransition(gradient, delay, duration, TransitionStep.TransitionModeType.ToCurrent, timeUpdateMethod, tweenType, animationCurve, runAtStart, onStart, onUpdate, onComplete);
		}

		public static ColorTransition ColorTransitionFromOriginal(this TransitionStep transitionStep, Gradient gradient, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.ColorTransition(gradient, delay, duration, TransitionStep.TransitionModeType.FromOriginal, timeUpdateMethod, tweenType, animationCurve, runAtStart, onStart, onUpdate, onComplete);
		}

		public static ColorTransition ColorTransitionFromCurrent(this TransitionStep transitionStep, Gradient gradient, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.ColorTransition(gradient, delay, duration, TransitionStep.TransitionModeType.FromCurrent, timeUpdateMethod, tweenType, animationCurve, runAtStart, onStart, onUpdate, onComplete);
		}

		public static ColorTransition ColorTransition(this TransitionStep transitionStep, Color startColor, Color endColor, float delay = 0f, float duration = 0.5f, TransitionStep.TransitionModeType transitionMode = TransitionStep.TransitionModeType.Specified, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			ColorTransition colorTransition = new ColorTransition(transitionStep.Target, startColor, endColor, delay, duration, transitionMode, timeUpdateMethod, tweenType, animationCurve, onStart, onUpdate, onComplete);
			colorTransition.AddToChain(transitionStep, runAtStart);
			return colorTransition;
		}

		public static ColorTransition ColorTransitionToOriginal(this TransitionStep transitionStep, Color startColor, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.ColorTransition(startColor, Color.black, delay, duration, TransitionStep.TransitionModeType.ToOriginal, timeUpdateMethod, tweenType, animationCurve, runAtStart, onStart, onUpdate, onComplete);
		}

		public static ColorTransition ColorTransitionToCurrent(this TransitionStep transitionStep, Color startColor, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.ColorTransition(startColor, Color.black, delay, duration, TransitionStep.TransitionModeType.ToCurrent, timeUpdateMethod, tweenType, animationCurve, runAtStart, onStart, onUpdate, onComplete);
		}

		public static ColorTransition ColorTransitionFromOriginal(this TransitionStep transitionStep, Color endColor, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.ColorTransition(Color.black, endColor, delay, duration, TransitionStep.TransitionModeType.FromOriginal, timeUpdateMethod, tweenType, animationCurve, runAtStart, onStart, onUpdate, onComplete);
		}

		public static ColorTransition ColorTransitionFromCurrent(this TransitionStep transitionStep, Color endColor, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			return transitionStep.ColorTransition(Color.black, endColor, delay, duration, TransitionStep.TransitionModeType.FromCurrent, timeUpdateMethod, tweenType, animationCurve, runAtStart, onStart, onUpdate, onComplete);
		}
	}
}
