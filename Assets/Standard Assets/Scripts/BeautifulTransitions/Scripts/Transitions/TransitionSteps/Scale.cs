using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public class Scale : TransitionStepVector3
	{
		public Scale(GameObject target, Vector3? startScale = default(Vector3?), Vector3? endScale = default(Vector3?), float delay = 0f, float duration = 0.5f, TransitionModeType transitionMode = TransitionModeType.Specified, TimeUpdateMethodType timeUpdateMethod = TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
			: base(target, startScale, endScale, delay, duration, transitionMode, timeUpdateMethod, tweenType, animationCurve, CoordinateSpaceType.Global, onStart, onUpdate, onComplete)
		{
		}

		public override Vector3 GetCurrent()
		{
			return base.Target.transform.localScale;
		}

		public override void SetCurrent(Vector3 scale)
		{
			base.Target.transform.localScale = scale;
		}
	}
}
