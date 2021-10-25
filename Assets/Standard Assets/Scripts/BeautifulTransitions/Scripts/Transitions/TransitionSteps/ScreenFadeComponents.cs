using UnityEngine;
using UnityEngine.UI;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public class ScreenFadeComponents
	{
		private GameObject _baseGameObject;

		private RawImage _fadeRawImage;

		public bool PersistantAcrossScenes
		{
			get;
			set;
		}

		public GameObject BaseGameObject
		{
			get
			{
				if (_baseGameObject == null)
				{
					CreateComponents();
				}
				return _baseGameObject;
			}
			private set
			{
				_baseGameObject = value;
			}
		}

		public RawImage FadeRawImage
		{
			get
			{
				if (_fadeRawImage == null)
				{
					CreateComponents();
				}
				return _fadeRawImage;
			}
			set
			{
				_fadeRawImage = value;
			}
		}

		private void CreateComponents()
		{
			BaseGameObject = new GameObject("(Beautiful Transitions - ScreenFade");
			if (PersistantAcrossScenes)
			{
				BaseGameObject.transform.SetParent(TransitionController.Instance.gameObject.transform);
			}
			BaseGameObject.SetActive(value: false);
			Canvas canvas = BaseGameObject.AddComponent<Canvas>();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			canvas.sortingOrder = 999;
			FadeRawImage = BaseGameObject.AddComponent<RawImage>();
		}

		public void DeleteComponents()
		{
			if (BaseGameObject != null)
			{
				UnityEngine.Object.Destroy(BaseGameObject);
			}
		}
	}
}
