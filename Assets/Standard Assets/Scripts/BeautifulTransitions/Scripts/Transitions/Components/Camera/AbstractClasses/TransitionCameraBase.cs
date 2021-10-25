using BeautifulTransitions.Scripts.Transitions.TransitionSteps;
using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.Components.Camera.AbstractClasses
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(UnityEngine.Camera))]
	public abstract class TransitionCameraBase : TransitionBase
	{
		public bool SkipIdleRendering;

		protected RenderTexture CrossTransitionRenderTexture;

		protected UnityEngine.Camera CrossTransitionTarget;

		public void CrossTransition(UnityEngine.Camera target)
		{
			CrossTransitionTarget = target;
			TransitionOut();
		}

		protected override void TransitionOutStart(TransitionStep transitionStep)
		{
			if (CrossTransitionTarget != null)
			{
				CrossTransitionRenderTexture = new RenderTexture(UnityEngine.Screen.width, UnityEngine.Screen.height, 24);
				CrossTransitionTarget.gameObject.SetActive(value: true);
				CrossTransitionTarget.targetTexture = CrossTransitionRenderTexture;
			}
			base.TransitionOutStart(transitionStep);
		}

		protected override void TransitionOutComplete(TransitionStep transitionStep)
		{
			if (CrossTransitionTarget != null)
			{
				CrossTransitionTarget.gameObject.SetActive(value: false);
				CrossTransitionTarget.targetTexture = null;
				UnityEngine.Object.Destroy(CrossTransitionRenderTexture);
				CrossTransitionRenderTexture = null;
				base.transform.position = CrossTransitionTarget.transform.position;
				base.transform.rotation = CrossTransitionTarget.transform.rotation;
				base.transform.localScale = CrossTransitionTarget.transform.localScale;
				CrossTransitionTarget = null;
				TransitionStepFloat transitionStepFloat = base.CurrentTransitionStep as TransitionStepFloat;
				if (transitionStepFloat != null)
				{
					transitionStepFloat.Value = 0f;
				}
			}
			base.TransitionOutComplete(transitionStep);
		}

		public override TransitionStep CreateTransitionStep()
		{
			return new TransitionStepFloat();
		}

		public override void SetupTransitionStepIn(TransitionStep transitionStep)
		{
			TransitionStepFloat transitionStepFloat = transitionStep as TransitionStepFloat;
			if (transitionStepFloat != null)
			{
				transitionStepFloat.StartValue = 1f;
				transitionStepFloat.EndValue = 0f;
			}
			base.SetupTransitionStepIn(transitionStep);
		}

		public override void SetupTransitionStepOut(TransitionStep transitionStep)
		{
			TransitionStepFloat transitionStepFloat = transitionStep as TransitionStepFloat;
			if (transitionStepFloat != null)
			{
				transitionStepFloat.StartValue = 0f;
				transitionStepFloat.EndValue = 1f;
			}
			base.SetupTransitionStepOut(transitionStep);
		}
	}
}
