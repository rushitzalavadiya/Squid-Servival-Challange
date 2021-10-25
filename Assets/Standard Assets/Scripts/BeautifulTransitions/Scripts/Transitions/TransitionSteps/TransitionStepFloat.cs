using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public class TransitionStepFloat : TransitionStepValue<float>
	{
		public TransitionStepFloat(GameObject target = null, float? startValue = default(float?), float? endValue = default(float?), float delay = 0f, float duration = 0.5f, TransitionModeType transitionMode = TransitionModeType.Specified, TimeUpdateMethodType timeUpdateMethod = TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, CoordinateSpaceType coordinateSpace = CoordinateSpaceType.Global, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
			: base(target, delay, duration, transitionMode, timeUpdateMethod, tweenType, animationCurve, coordinateSpace, onStart, onUpdate, onComplete)
		{
			base.StartValue = startValue.GetValueOrDefault();
			base.EndValue = endValue.GetValueOrDefault();
			base.OriginalValue = GetCurrent();
		}

		private TransitionStep SetStartValue(float value)
		{
			base.StartValue = value;
			return this;
		}

		private TransitionStep SetEndValue(float value)
		{
			base.EndValue = value;
			return this;
		}

		public override void Start()
		{
			if (base.TransitionMode == TransitionModeType.ToOriginal)
			{
				base.EndValue = base.OriginalValue;
			}
			else if (base.TransitionMode == TransitionModeType.ToCurrent)
			{
				base.EndValue = GetCurrent();
			}
			else if (base.TransitionMode == TransitionModeType.FromCurrent)
			{
				base.StartValue = GetCurrent();
			}
			else if (base.TransitionMode == TransitionModeType.FromOriginal)
			{
				base.StartValue = base.OriginalValue;
			}
			base.Start();
		}

		protected override void ProgressUpdated()
		{
			base.Value = ValueFromProgressTweened(base.StartValue, base.EndValue);
			SetCurrent(base.Value);
		}
	}
}
