using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using System.Collections;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public class TriggerAnimation : TransitionStepFloat
	{
		public float Speed
		{
			get;
			set;
		}

		public Animator Animator
		{
			get;
			set;
		}

		public string Trigger
		{
			get;
			set;
		}

		public string TargetState
		{
			get;
			set;
		}

		public TriggerAnimation(GameObject target, float speed = 1f, float delay = 0f, float duration = 0.5f, string trigger = "TransitionIn", string targetState = "TransitionOut", Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
			: base(target, null, null, delay, duration, TransitionModeType.Specified, TimeUpdateMethodType.GameTime, TransitionHelper.TweenType.linear, null, CoordinateSpaceType.Global, onStart, onUpdate, onComplete)
		{
			SetupComponentReferences();
			Animator.enabled = false;
			Speed = speed;
			Trigger = trigger;
			TargetState = targetState;
		}

		protected override IEnumerator TransitionLoop()
		{
			if (Mathf.Approximately(base.Delay + base.Duration, 0f))
			{
				SetProgressToEnd();
				TransitionStarted();
				yield break;
			}
			SetProgressToStart();
			TransitionStarted();
			if (!Mathf.Approximately(base.Delay, 0f))
			{
				yield return new WaitForSeconds(base.Delay);
			}
			Animator.enabled = true;
			Animator.SetTrigger(Trigger);
			Animator.speed = Speed;
			bool stateReached = false;
			while (!stateReached)
			{
				yield return new WaitForEndOfFrame();
				if (!Animator.IsInTransition(0))
				{
					stateReached = (Animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f || !Animator.GetCurrentAnimatorStateInfo(0).IsName(TargetState));
				}
			}
			if (Mathf.Approximately(base.Progress, 1f) && !base.IsStopped)
			{
				TransitionCompleted();
			}
		}

		private void SetupComponentReferences()
		{
			Animator = base.Target.GetComponent<Animator>();
		}
	}
}
