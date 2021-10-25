using UnityEngine;
using UnityEngine.UI;

namespace BeautifulTransitions.Scripts.Transitions.TransitionSteps
{
	public class ScreenWipeComponents
	{
		private GameObject _baseGameObject;

		private RawImage _wipeRawImage;

		private Material _wipeMaterial;

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

		public RawImage WipeRawImage
		{
			get
			{
				if (_wipeRawImage == null)
				{
					CreateComponents();
				}
				return _wipeRawImage;
			}
			set
			{
				_wipeRawImage = value;
			}
		}

		public Material WipeMaterial
		{
			get
			{
				if (_wipeMaterial == null)
				{
					CreateComponents();
				}
				return _wipeMaterial;
			}
			set
			{
				_wipeMaterial = value;
			}
		}

		private void CreateComponents()
		{
			BaseGameObject = new GameObject("(Beautiful Transitions - ScreenWipe");
			if (PersistantAcrossScenes)
			{
				BaseGameObject.transform.SetParent(TransitionController.Instance.gameObject.transform);
			}
			BaseGameObject.SetActive(value: false);
			Canvas canvas = BaseGameObject.AddComponent<Canvas>();
			canvas.renderMode = RenderMode.ScreenSpaceOverlay;
			canvas.sortingOrder = 999;
			WipeRawImage = BaseGameObject.AddComponent<RawImage>();
			Shader shader = Shader.Find("FlipWebApps/BeautifulTransitions/WipeScreen");
			if (shader != null && shader.isSupported)
			{
				Material material3 = WipeRawImage.material = (WipeMaterial = new Material(shader));
			}
			else
			{
				UnityEngine.Debug.Log("WipScreen: Shader is not found or supported on this platform.");
			}
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
