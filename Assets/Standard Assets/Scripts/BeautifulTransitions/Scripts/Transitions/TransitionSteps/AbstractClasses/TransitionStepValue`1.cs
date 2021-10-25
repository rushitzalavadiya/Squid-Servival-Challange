using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses
{
	public abstract class TransitionStepValue<T> : TransitionStep where T : struct
	{
		public T StartValue
		{
			get;
			set;
		}

		public T EndValue
		{
			get;
			set;
		}

		public T Value
		{
			get;
			set;
		}

		public T OriginalValue
		{
			get;
			set;
		}

		public TransitionStepValue(GameObject target = null, float delay = 0f, float duration = 0.5f, TransitionModeType transitionMode = TransitionModeType.Specified, TimeUpdateMethodType timeUpdateMethod = TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, CoordinateSpaceType coordinateSpace = CoordinateSpaceType.Global, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
			: base(target, delay, duration, transitionMode, timeUpdateMethod, tweenType, animationCurve, coordinateSpace, onStart, onUpdate, onComplete)
		{
		}

		public virtual T GetCurrent()
		{
			return default(T);
		}

		public virtual void SetCurrent(T value)
		{
		}
	}
}
