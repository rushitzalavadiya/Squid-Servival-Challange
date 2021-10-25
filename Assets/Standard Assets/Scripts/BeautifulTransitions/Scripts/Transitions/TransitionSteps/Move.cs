using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public class Move : TransitionStepVector3
	{
		public Move(GameObject target, Vector3? startPosition = default(Vector3?), Vector3? endPosition = default(Vector3?), float delay = 0f, float duration = 0.5f, TransitionModeType transitionMode = TransitionModeType.Specified, TimeUpdateMethodType timeUpdateMethod = TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, CoordinateSpaceType coordinateSpace = CoordinateSpaceType.Global, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
			: base(target, startPosition, endPosition, delay, duration, transitionMode, timeUpdateMethod, tweenType, animationCurve, coordinateSpace, onStart, onUpdate, onComplete)
		{
		}

		public override Vector3 GetCurrent()
		{
			if (base.CoordinateSpace == CoordinateSpaceType.Global)
			{
				return base.Target.transform.position;
			}
			if (base.CoordinateSpace == CoordinateSpaceType.Local)
			{
				return base.Target.transform.localPosition;
			}
			return ((RectTransform)base.Target.transform).anchoredPosition;
		}

		public override void SetCurrent(Vector3 position)
		{
			if (base.CoordinateSpace == CoordinateSpaceType.Global)
			{
				base.Target.transform.position = position;
			}
			else if (base.CoordinateSpace == CoordinateSpaceType.Local)
			{
				base.Target.transform.localPosition = position;
			}
			else
			{
				((RectTransform)base.Target.transform).anchoredPosition = position;
			}
		}
	}
}
