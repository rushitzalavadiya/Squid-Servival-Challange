using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class candySoilder : MonoBehaviour
{
    public Animator anim;

    public GameObject gun;

    public GameObject gunEffect;

    public GameObject playCam;

    public GameObject finalCam;

    public GameObject boxObj;

    public GameObject objectsParent;

    // public GameObject FinalobjectsParent;

    public int piecesCount;

    public Transform piece;

    public GameObject popEffect;

    public TextMeshProUGUI timerText;

    public AudioSource audio;

    public AudioSource bgAudio;

    private bool startGame;

    private float timer = 30f;

    private bool timerOn;

    private void Start()
    {
        anim.SetFloat("Blend", 1f);
        if (PlayerPrefs.GetInt("candy", 0) == 3) timer = 60f;
    }

    private void Update()
    {
        if (startGame && !Gamemanager.Instance.gameOver)
        {
            piecesCount = piece.childCount;
            if (timer > 0f)
            {
                float num = Mathf.FloorToInt(timer / 60f);
                float num2 = Mathf.FloorToInt(timer % 60f);
                timer -= Time.deltaTime;
                timerText.text = num + ":" + num2;
            }
            else
            {
                bgAudio.Stop();
                timerText.text = "0:0";
                canvasmanager.Instance.Fail(1f);
                timerText.enabled = false;
                Gamemanager.Instance.gameOver = true;
            }

            if (timer < 10f && !timerOn)
            {
                timerText.color = Color.red;
                timerOn = true;
                audio.Play();
            }

            if (piecesCount == 0)
            {
                bgAudio.Stop();
                audio.Stop();
                timerText.enabled = false;
                Gamemanager.Instance.gameOver = true;
                popEffect.SetActive(true);
                Invoke("CandyWin", 1f);
            }
        }
    }

    public void TurnOnGun()
    {
        gun.SetActive(true);
    }

    public void StartGame()
    {
        playCam.SetActive(true);
        boxObj.SetActive(false);
        var num = PlayerPrefs.GetInt("candy", 0);
        if (num >= objectsParent.transform.childCount) num = Random.Range(0, objectsParent.transform.childCount);
        objectsParent.transform.GetChild(num).gameObject.SetActive(true);
        // FinalobjectsParent.transform.GetChild(num).gameObject.SetActive(true);
        piece = objectsParent.transform.GetChild(num).GetChild(1);
        piecesCount = piece.childCount;
        startGame = true;
    }

    public void CandyWin()
    {
        finalCam.SetActive(true);
        canvasmanager.Instance.Win(3f);
    }

    public void Die()
    {
        bgAudio.Stop();
        audio.Stop();
        timerText.enabled = false;
        playCam.SetActive(false);
        transform.localRotation =  Quaternion.Lerp(Quaternion.identity, Quaternion.Euler(0,160,0),0.5f);;
        anim.SetTrigger("Fire");
    }

    public void Shoot()
    {
        gunEffect.SetActive(true);
    }
}