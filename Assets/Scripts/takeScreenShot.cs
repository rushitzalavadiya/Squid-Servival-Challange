using UnityEngine;

public class takeScreenShot : MonoBehaviour
{
    public KeyCode key = KeyCode.G;

    private string resolution;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            resolution = Screen.width + "X" + Screen.height;
            ScreenCapture.CaptureScreenshot(
                Application.productName + "_ScreenShot-" + resolution + "-" + PlayerPrefs.GetInt("number", 0) + ".png",
                1);
            PlayerPrefs.SetInt("number", PlayerPrefs.GetInt("number", 0) + 1);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            resolution = Screen.width + "X" + Screen.height;
            ScreenCapture.CaptureScreenshot(
                Application.productName + "_HIGH_ScreenShot-" + resolution + "-" + PlayerPrefs.GetInt("number", 0) +
                ".png", 5);
            PlayerPrefs.SetInt("number", PlayerPrefs.GetInt("number", 0) + 1);
        }
    }
}