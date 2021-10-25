using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace BeautifulTransitions.Scripts.Transitions.Components
{
	public abstract class TransitionBase : MonoBehaviour
	{
		public enum TransitionModeType
		{
			None,
			In,
			Out
		}

		[Serializable]
		public class TransitionSettings
		{
			[Tooltip("Whether the transition should auto run.\nFor in transitions this will happen when the gameobject is activated, for out transitions after the in transition is complete.")]
			public bool AutoRun;

			[Tooltip("Whether to automatically check and run transitions on child GameObjects.")]
			public bool TransitionChildren;

			[Tooltip("Whether this must be transitioned specifically. If not set it will run automatically when a parent transition is run that has the TransitionChildren property set.")]
			public bool MustTriggerDirect;

			[Tooltip("Time in seconds before this transition should be started.")]
			public float Delay;

			[Tooltip("How long this transition will / should run for.")]
			public float Duration = 0.3f;

			[Tooltip("What time source is used to update transitions")]
			public TransitionStep.TimeUpdateMethodType TimeUpdateMethod;

			[Tooltip("How the transition should be run.")]
			public TransitionHelper.TweenType TransitionType = TransitionHelper.TweenType.linear;

			[Tooltip("A custom curve to show how the transition should be run.")]
			public AnimationCurve AnimationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);

			[Tooltip("The transitions looping mode.")]
			public TransitionStep.LoopModeType LoopMode;

			[Tooltip("Methods that should be called when the transition is started.")]
			public TransitionStepEvent OnTransitionStart;

			[Tooltip("Methods that should be called when the transition progress is updated.")]
			public TransitionStepEvent OnTransitionUpdate;

			[Tooltip("Methods that should be called when the transition has completed.")]
			public TransitionStepEvent OnTransitionComplete;
		}

		[Serializable]
		public class TransitionStepEvent : UnityEvent<TransitionStep>
		{
		}

		[Tooltip("Whether to set up ready for transitioning in.")]
		public bool InitForTransitionIn = true;

		[Tooltip("Whether to automatically run the transition in effect in the OnEnable state.")]
		public bool AutoRun;

		[Tooltip("Whether to repeat initialisation and /or auto run in subsequent enabling of the gameitem.")]
		public bool RepeatWhenEnabled;

		public TransitionSettings TransitionInConfig;

		public TransitionSettings TransitionOutConfig;

		private bool _isInitialStateSet;

		public TransitionModeType TransitionMode
		{
			get;
			set;
		}

		public TransitionStep CurrentTransitionStep
		{
			get;
			set;
		}

		public virtual void OnEnable()
		{
			if (_isInitialStateSet && RepeatWhenEnabled)
			{
				Setup();
			}
		}

		public virtual void Start()
		{
			Setup();
		}

		private void Setup()
		{
			if (InitForTransitionIn || AutoRun)
			{
				InitTransitionIn();
			}
			if (AutoRun)
			{
				TransitionIn();
			}
		}

		public virtual void InitTransitionIn()
		{
			SetupInitialStateOnce();
			TransitionMode = TransitionModeType.In;
			CurrentTransitionStep = CreateTransitionStepIn();
			CurrentTransitionStep.SetProgressToStart();
		}

		public virtual void TransitionIn()
		{
			SetupInitialStateOnce();
			InitTransitionIn();
			CurrentTransitionStep.Start();
		}

		public virtual void InitTransitionOut()
		{
			SetupInitialStateOnce();
			TransitionMode = TransitionModeType.Out;
			CurrentTransitionStep = CreateTransitionStepOut();
			CurrentTransitionStep.SetProgressToStart();
		}

		public virtual void TransitionOut()
		{
			SetupInitialStateOnce();
			InitTransitionOut();
			CurrentTransitionStep.Start();
		}

		private void SetupInitialStateOnce()
		{
			if (!_isInitialStateSet)
			{
				_isInitialStateSet = true;
				SetupInitialState();
			}
		}

		public virtual void SetupInitialState()
		{
		}

		protected virtual void TransitionInStart(TransitionStep transitionStep)
		{
			if (TransitionInConfig.OnTransitionStart != null)
			{
				TransitionInConfig.OnTransitionStart.Invoke(transitionStep);
			}
		}

		protected virtual void TransitionOutStart(TransitionStep transitionStep)
		{
			if (TransitionOutConfig.OnTransitionStart != null)
			{
				TransitionOutConfig.OnTransitionStart.Invoke(transitionStep);
			}
		}

		protected virtual void TransitionInUpdate(TransitionStep transitionStep)
		{
			if (TransitionInConfig.OnTransitionUpdate != null)
			{
				TransitionInConfig.OnTransitionUpdate.Invoke(transitionStep);
			}
		}

		protected virtual void TransitionOutUpdate(TransitionStep transitionStep)
		{
			if (TransitionOutConfig.OnTransitionUpdate != null)
			{
				TransitionOutConfig.OnTransitionUpdate.Invoke(transitionStep);
			}
		}

		protected virtual void TransitionInComplete(TransitionStep transitionStep)
		{
			TransitionMode = TransitionModeType.Out;
			if (TransitionInConfig.OnTransitionComplete != null)
			{
				TransitionInConfig.OnTransitionComplete.Invoke(transitionStep);
			}
		}

		protected virtual void TransitionOutComplete(TransitionStep transitionStep)
		{
			if (TransitionOutConfig.OnTransitionComplete != null)
			{
				TransitionOutConfig.OnTransitionComplete.Invoke(transitionStep);
			}
		}

		public abstract TransitionStep CreateTransitionStep();

		public virtual TransitionStep CreateTransitionStepIn()
		{
			TransitionStep transitionStep = CurrentTransitionStep ?? CreateTransitionStep();
			SetupTransitionStepIn(transitionStep);
			return transitionStep;
		}

		public virtual void SetupTransitionStepIn(TransitionStep transitionStep)
		{
			transitionStep.Delay = TransitionInConfig.Delay;
			transitionStep.Duration = TransitionInConfig.Duration;
			transitionStep.TimeUpdateMethod = TransitionInConfig.TimeUpdateMethod;
			transitionStep.TweenType = TransitionInConfig.TransitionType;
			transitionStep.AnimationCurve = TransitionInConfig.AnimationCurve;
			transitionStep.LoopMode = TransitionInConfig.LoopMode;
			transitionStep.OnStart = TransitionInStart;
			transitionStep.OnComplete = TransitionInComplete;
			transitionStep.OnUpdate = TransitionInUpdate;
		}

		public virtual TransitionStep CreateTransitionStepOut()
		{
			TransitionStep transitionStep = CurrentTransitionStep ?? CreateTransitionStep();
			SetupTransitionStepOut(transitionStep);
			return transitionStep;
		}

		public virtual void SetupTransitionStepOut(TransitionStep transitionStep)
		{
			transitionStep.Delay = TransitionOutConfig.Delay;
			transitionStep.Duration = TransitionOutConfig.Duration;
			transitionStep.TimeUpdateMethod = TransitionOutConfig.TimeUpdateMethod;
			transitionStep.TweenType = TransitionOutConfig.TransitionType;
			transitionStep.AnimationCurve = TransitionOutConfig.AnimationCurve;
			transitionStep.LoopMode = TransitionOutConfig.LoopMode;
			transitionStep.OnStart = TransitionOutStart;
			transitionStep.OnComplete = TransitionOutComplete;
			transitionStep.OnUpdate = TransitionOutUpdate;
		}
	}
}
