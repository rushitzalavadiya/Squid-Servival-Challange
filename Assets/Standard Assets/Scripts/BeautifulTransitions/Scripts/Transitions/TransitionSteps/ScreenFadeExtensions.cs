using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public static class ScreenFadeExtensions
	{
		public static ScreenFade ScreenFade(this TransitionStep transitionStep, Color? color = default(Color?), Texture2D texture = null, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			ScreenFade screenFade = new ScreenFade(transitionStep.Target, color, texture, delay, duration, timeUpdateMethod, tweenType, animationCurve, onStart, onUpdate, onComplete);
			screenFade.AddToChain(transitionStep, runAtStart: false);
			return screenFade;
		}
	}
}
