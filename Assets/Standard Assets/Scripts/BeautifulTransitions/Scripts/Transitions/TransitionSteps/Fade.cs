using BeautifulTransitions.Scripts.Transitions.TransitionSteps.AbstractClasses;
using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public class Fade : TransitionStepFloat
	{
		private CanvasGroup[] _canvasGroups = new CanvasGroup[0];

		private Image[] _images = new Image[0];

		private RawImage[] _rawImages = new RawImage[0];

		private Text[] _texts = new Text[0];

		private SpriteRenderer[] _spriteRenderers = new SpriteRenderer[0];

		private Material[] _materials = new Material[0];

		private bool _hasComponentReferences;

		public Fade(GameObject target, float startTransparency = 0f, float endTransparency = 1f, float delay = 0f, float duration = 0.5f, TransitionModeType transitionMode = TransitionModeType.Specified, TimeUpdateMethodType timeUpdateMethod = TimeUpdateMethodType.GameTime, TransitionHelper.TweenType tweenType = TransitionHelper.TweenType.linear, AnimationCurve animationCurve = null, Action<TransitionStep> onStart = null, Action<TransitionStep> onUpdate = null, Action<TransitionStep> onComplete = null)
			: base(target, startTransparency, endTransparency, delay, duration, transitionMode, timeUpdateMethod, tweenType, animationCurve, CoordinateSpaceType.Global, onStart, onUpdate, onComplete)
		{
		}

		public override float GetCurrent()
		{
			if (!_hasComponentReferences)
			{
				SetupComponentReferences();
			}
			if (_canvasGroups.Length != 0)
			{
				return _canvasGroups[0].alpha;
			}
			if (_images.Length != 0)
			{
				return _images[0].color.a;
			}
			if (_rawImages.Length != 0)
			{
				return _rawImages[0].color.a;
			}
			if (_texts.Length != 0)
			{
				return _texts[0].color.a;
			}
			if (_spriteRenderers.Length != 0)
			{
				return _spriteRenderers[0].color.a;
			}
			if (_materials.Length != 0)
			{
				return _materials[0].color.a;
			}
			return 1f;
		}

		public override void SetCurrent(float transparency)
		{
			if (!_hasComponentReferences)
			{
				SetupComponentReferences();
			}
			CanvasGroup[] canvasGroups = _canvasGroups;
			for (int i = 0; i < canvasGroups.Length; i++)
			{
				canvasGroups[i].alpha = transparency;
			}
			Image[] images = _images;
			foreach (Image image in images)
			{
				image.color = new Color(image.color.r, image.color.g, image.color.b, transparency);
			}
			RawImage[] rawImages = _rawImages;
			foreach (RawImage rawImage in rawImages)
			{
				rawImage.color = new Color(rawImage.color.r, rawImage.color.g, rawImage.color.b, transparency);
			}
			Text[] texts = _texts;
			foreach (Text text in texts)
			{
				text.color = new Color(text.color.r, text.color.g, text.color.b, transparency);
			}
			SpriteRenderer[] spriteRenderers = _spriteRenderers;
			foreach (SpriteRenderer spriteRenderer in spriteRenderers)
			{
				spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, transparency);
			}
			Material[] materials = _materials;
			foreach (Material material in materials)
			{
				material.color = new Color(material.color.r, material.color.g, material.color.b, transparency);
			}
		}

		private void SetupComponentReferences()
		{
			_canvasGroups = new CanvasGroup[0];
			_images = new Image[0];
			_rawImages = new RawImage[0];
			_texts = new Text[0];
			_spriteRenderers = new SpriteRenderer[0];
			_materials = new Material[0];
			CanvasGroup component = base.Target.GetComponent<CanvasGroup>();
			if (component != null)
			{
				_canvasGroups = _canvasGroups.Concat(Enumerable.Repeat(component, 1)).ToArray();
			}
			else
			{
				Image component2 = base.Target.GetComponent<Image>();
				if (component2 != null)
				{
					_images = _images.Concat(Enumerable.Repeat(component2, 1)).ToArray();
				}
				RawImage component3 = base.Target.GetComponent<RawImage>();
				if (component3 != null)
				{
					_rawImages = _rawImages.Concat(Enumerable.Repeat(component3, 1)).ToArray();
				}
				Text component4 = base.Target.GetComponent<Text>();
				if (component4 != null)
				{
					_texts = _texts.Concat(Enumerable.Repeat(component4, 1)).ToArray();
				}
			}
			SpriteRenderer component5 = base.Target.GetComponent<SpriteRenderer>();
			if (component5 != null)
			{
				_spriteRenderers = _spriteRenderers.Concat(Enumerable.Repeat(component5, 1)).ToArray();
			}
			MeshRenderer component6 = base.Target.GetComponent<MeshRenderer>();
			if (component6 != null && component6.material != null)
			{
				_materials = _materials.Concat(Enumerable.Repeat(component6.material, 1)).ToArray();
			}
			_hasComponentReferences = true;
		}
	}
}
