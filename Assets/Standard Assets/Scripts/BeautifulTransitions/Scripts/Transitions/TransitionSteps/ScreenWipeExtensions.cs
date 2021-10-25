using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public static class ScreenWipeExtensions
	{
		public static ScreenWipe ScreenWipe(this TransitionStep transitionStep, Texture2D maskTexture, bool invertMask = false, Color? color = default(Color?), Texture2D texture = null, float softness = 0f, float delay = 0f, float duration = 0.5f, TransitionStep.TimeUpdateMethodType timeUpdateMethod = TransitionStep.TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			ScreenWipe screenWipe = new ScreenWipe(transitionStep.Target, maskTexture, invertMask, color, texture, softness, delay, duration, timeUpdateMethod, tweenType, animationCurve, onStart, onUpdate, onComplete);
			screenWipe.AddToChain(transitionStep, runAtStart: false);
			return screenWipe;
		}
	}
}
