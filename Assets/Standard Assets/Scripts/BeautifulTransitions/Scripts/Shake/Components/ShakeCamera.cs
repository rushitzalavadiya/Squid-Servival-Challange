using System.Collections.Generic;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Shake.Components
{
	[AddComponentMenu("Beautiful Transitions/Shake/Shake Camera")]
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/shake/")]
	public class ShakeCamera : MonoBehaviour
	{
		[Tooltip("A list of cameras to shake. If left empty cameras on the same gameobject as the component will be used, or if none are found the main camera.")]
		public List<Camera> Cameras;

		[Tooltip("The duration to shake the camera for.")]
		public float Duration = 1f;

		[Tooltip("The offset relative to duration after which to start decaying (slowing down) the movement in the range 0 to 1.")]
		[Range(0f, 1f)]
		public float DecayStart = 0.75f;

		[Tooltip("The shake movement range from the origin. Set any dimension to 0 to stop movement along that axis.")]
		public Vector3 Range = Vector3.one;

		public static ShakeCamera Instance
		{
			get;
			private set;
		}

		public static bool IsActive => Instance != null;

		private void Awake()
		{
			if (Instance != null)
			{
				if (Instance != this)
				{
					UnityEngine.Object.Destroy(base.gameObject);
				}
			}
			else
			{
				Instance = this;
				Setup();
			}
		}

		private void OnDestroy()
		{
			bool flag = Instance == this;
		}

		private void Setup()
		{
			if (Cameras.Count < 1)
			{
				if ((bool)GetComponent<Camera>())
				{
					Cameras.Add(GetComponent<Camera>());
				}
				if (Cameras.Count < 1 && (bool)Camera.main)
				{
					Cameras.Add(Camera.main);
				}
			}
		}

		public void Shake()
		{
			Shake(Duration, Range, DecayStart);
		}

		public void Shake(float duration, Vector3 range, float decayStart)
		{
			foreach (Camera camera in Cameras)
			{
				ShakeHelper.Shake(this, camera.transform, duration, range, decayStart);
			}
		}
	}
}
