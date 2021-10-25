using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public static class AnimationExtensions
	{
		public static TriggerAnimation TriggerAnimation(this TransitionStep transitionStep, float speed = 1f, float delay = 0f, float duration = 0.5f, string trigger = "TransitionIn", string targetState = "TransitionOut", bool runAtStart = false, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
		{
			TriggerAnimation triggerAnimation = new TriggerAnimation(transitionStep.Target, speed, delay, duration, trigger, targetState, onStart, onUpdate, onComplete);
			triggerAnimation.AddToChain(transitionStep, runAtStart);
			return triggerAnimation;
		}
	}
}
