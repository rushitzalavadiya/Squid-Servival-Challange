using BeautifulTransitions.Scripts.Transitions.Components.GameObject.AbstractClasses;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.Components.GameObject
{
	[AddComponentMenu("Beautiful Transitions/GameObject + UI/Animate Transition")]
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/")]
	public class TransitionAnimation : TransitionGameObjectBase
	{
		[Serializable]
		public class InSettings
		{
			[Tooltip("The Animator Speed.")]
			public float Speed = 1f;
		}

		[Serializable]
		public class OutSettings
		{
			[Tooltip("The Animator Speed.")]
			public float Speed = 1f;
		}

		[Header("Animation Specific")]
		public InSettings InConfig;

		public OutSettings OutConfig;

		public override TransitionStep CreateTransitionStep()
		{
			return new TriggerAnimation(Target);
		}

		public override void SetupTransitionStepIn(TransitionStep transitionStep)
		{
			TriggerAnimation triggerAnimation = transitionStep as TriggerAnimation;
			if (triggerAnimation != null)
			{
				triggerAnimation.Speed = InConfig.Speed;
				triggerAnimation.Trigger = "TransitionIn";
				triggerAnimation.TargetState = "TransitionIn";
			}
			base.SetupTransitionStepIn(transitionStep);
		}

		public override void SetupTransitionStepOut(TransitionStep transitionStep)
		{
			TriggerAnimation triggerAnimation = transitionStep as TriggerAnimation;
			if (triggerAnimation != null)
			{
				triggerAnimation.Speed = OutConfig.Speed;
				triggerAnimation.Trigger = "TransitionOut";
				triggerAnimation.TargetState = "TransitionOut";
			}
			base.SetupTransitionStepOut(transitionStep);
		}

		public override void InitTransitionIn()
		{
			base.InitTransitionIn();
			TriggerAnimation triggerAnimation = base.CurrentTransitionStep as TriggerAnimation;
			if (triggerAnimation != null)
			{
				triggerAnimation.Animator.enabled = true;
				triggerAnimation.Animator.speed = 0f;
			}
		}

		public override void InitTransitionOut()
		{
			TriggerAnimation triggerAnimation = base.CurrentTransitionStep as TriggerAnimation;
			if (triggerAnimation != null)
			{
				triggerAnimation.Animator.enabled = true;
				triggerAnimation.Animator.speed = 0f;
			}
			base.InitTransitionOut();
		}
	}
}
