using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public class Rotate : TransitionStepVector3
	{
		public Rotate(GameObject target, Vector3? startRotation = default(Vector3?), Vector3? endRotation = default(Vector3?), float delay = 0f, float duration = 0.5f, TransitionModeType transitionMode = TransitionModeType.Specified, TimeUpdateMethodType timeUpdateMethod = TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, CoordinateSpaceType coordinateSpace = CoordinateSpaceType.Global, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
			: base(target, startRotation, endRotation, delay, duration, transitionMode, TimeUpdateMethodType.GameTime, tweenType, animationCurve, coordinateSpace, onStart, onUpdate, onComplete)
		{
		}

		public override Vector3 GetCurrent()
		{
			if (base.CoordinateSpace == CoordinateSpaceType.Global)
			{
				return base.Target.transform.eulerAngles;
			}
			return base.Target.transform.localEulerAngles;
		}

		public override void SetCurrent(Vector3 rotation)
		{
			if (base.CoordinateSpace == CoordinateSpaceType.Global)
			{
				base.Target.transform.eulerAngles = rotation;
			}
			else
			{
				base.Target.transform.localEulerAngles = rotation;
			}
		}
	}
}
