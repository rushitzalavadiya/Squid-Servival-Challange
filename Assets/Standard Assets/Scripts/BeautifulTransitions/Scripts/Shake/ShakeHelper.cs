using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BeautifulTransitions.Scripts.Shake
{
	[HelpURL("http://www.flipwebapps.com/beautiful-transitions/shake/")]
	public class ShakeHelper
	{
		private static readonly List<int> ActiveShakes = new List<int>(2);

		public static void Shake(MonoBehaviour caller, Transform transform, float duration, Vector3 range, float decayStart = 1f)
		{
			caller.StartCoroutine(ShakeCoroutine(transform, duration, range, decayStart));
		}

		private static IEnumerator ShakeCoroutine(Transform transform, float duration, Vector3 range, float decayStart = 1f)
		{
			if (ActiveShakes.Contains(transform.GetInstanceID()))
			{
				yield break;
			}
			ActiveShakes.Add(transform.GetInstanceID());
			Vector3 originalPosition = transform.localPosition;
			int randomAngle = Random.Range(0, 361);
			float decay = 0f;
			float decayFactor = Mathf.Approximately(decayStart, 1f) ? 0f : (1f / (1f - decayStart));
			for (float elapsedTime = 0f; elapsedTime < duration; elapsedTime += Time.deltaTime)
			{
				if (transform.gameObject != null)
				{
					float num = elapsedTime / duration;
					if (num >= decayStart)
					{
						decay = 1f - decayFactor + decayFactor * num;
					}
					randomAngle += 180 + Random.Range(-60, 60);
					float num2 = Mathf.Sin(randomAngle);
					float num3 = Mathf.Cos(randomAngle);
					Vector3 a = new Vector3(num3 * num2 * range.x, num2 * num2 * range.y, num3 * range.z);
					Vector3 vector2 = transform.localPosition = originalPosition + a * (1f - decay);
				}
				yield return null;
			}
			transform.localPosition = originalPosition;
			ActiveShakes.Remove(transform.GetInstanceID());
		}
	}
}
