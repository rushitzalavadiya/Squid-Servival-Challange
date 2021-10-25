using UnityEngine;

public class followObject : MonoBehaviour
{
    [Header("Start Game")] public Vector3 startGamePos;
    public Quaternion startGameRot;

    [Header("Failed Game")] public Vector3 gameFailPos;
    public Quaternion gameFailRot;

    [Header("Win Game")] public Vector3 gameWinPos;
    public Quaternion gameWinRot;


    public float _smoothValue;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    public void StartGameplay()
    {
        transform.localPosition = Vector3.Lerp(transform.position, startGamePos, _smoothValue);
        transform.rotation = Quaternion.Lerp(transform.rotation, startGameRot, _smoothValue);
    }

    public void WinGame()
    {
        transform.localPosition = Vector3.Lerp(transform.position, gameWinPos, _smoothValue);
        transform.rotation = Quaternion.Lerp(transform.rotation, gameWinRot, _smoothValue);
    }

    public void FailedGamePlay()
    {
        transform.localPosition = Vector3.Lerp(transform.position, gameFailPos, _smoothValue);
        transform.rotation = Quaternion.Lerp(transform.rotation, gameFailRot, _smoothValue);
    }
}