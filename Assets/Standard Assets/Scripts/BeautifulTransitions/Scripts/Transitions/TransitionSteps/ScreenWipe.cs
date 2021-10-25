using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public class ScreenWipe : TransitionStepScreen
	{
		public Texture2D Texture;

		public Color Color;

		public Texture2D MaskTexture;

		public bool InvertMask;

		public float Softness;

		private readonly ScreenWipeComponents _screenWipeComponents;

		public ScreenWipe(GameObject target, Texture2D maskTexture, bool invertMask = false, Color? color = default(Color?), Texture2D texture = null, float softness = 0f, float delay = 0f, float duration = 0.5f, TimeUpdateMethodType timeUpdateMethod = TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
			: base(target, SceneChangeModeType.None, null, skipOnCrossTransition: true, delay, duration, timeUpdateMethod, tweenType, animationCurve, onStart, onUpdate, null, onComplete)
		{
			_screenWipeComponents = new ScreenWipeComponents
			{
				PersistantAcrossScenes = true
			};
			MaskTexture = maskTexture;
			InvertMask = invertMask;
			Color = (color.HasValue ? color.Value : Color.white);
			Texture = texture;
			Softness = softness;
		}

		public override void Start()
		{
			SetConfiguration(Texture, Color, MaskTexture, InvertMask, Softness);
			base.Start();
		}

		public override void SetCurrent(float progress)
		{
			TargetComponents().WipeMaterial.SetFloat("_Amount", base.Value);
		}

		private void SetConfiguration(Texture2D texture, Color color, Texture2D maskTexture, bool invertMask, float softness = 0f)
		{
			TargetComponents().WipeRawImage.texture = texture;
			TargetComponents().WipeMaterial.SetColor("_Color", color);
			TargetComponents().WipeMaterial.SetTexture("_MaskTex", maskTexture);
			if (invertMask)
			{
				TargetComponents().WipeMaterial.EnableKeyword("INVERT_MASK");
			}
			else
			{
				TargetComponents().WipeMaterial.DisableKeyword("INVERT_MASK");
			}
			TargetComponents().WipeMaterial.SetFloat("_Softness", softness);
		}

		protected override void SetTransitionDisplayedState(bool isDisplayed)
		{
			if (base.SiblingRawImage != null)
			{
				base.SetTransitionDisplayedState(isDisplayed);
			}
			else
			{
				TargetComponents().BaseGameObject.SetActive(isDisplayed);
			}
			if (base.SceneChangeMode == SceneChangeModeType.CrossTransition)
			{
				if (isDisplayed)
				{
					TargetComponents().WipeRawImage.texture = TransitionController.Instance.ScreenSnapshot;
				}
				else
				{
					TargetComponents().DeleteComponents();
				}
			}
		}

		private ScreenWipeComponents TargetComponents()
		{
			if (base.SceneChangeMode != SceneChangeModeType.CrossTransition)
			{
				return TransitionController.Instance.SharedScreenWipeComponents;
			}
			return _screenWipeComponents;
		}
	}
}
