using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Detector : MonoBehaviour
{
    public Transform dollHead;

    public TextMeshPro timerText;

    public float timer = 60f;

    public Transform guardParent;

    public List<soilder> guards;

    public AudioSource audio;

    private float buzztimer;

    private player Player;

    private bool turnhead;

    private void Start()
    {
        buzztimer = timer - Random.Range(0.5f, 3.1f);
        foreach (Transform item in guardParent) guards.Add(item.GetComponent<soilder>());
        Player = FindObjectOfType<player>();
    }

    private void Update()
    {
        if (!Gamemanager.Instance.gameOver && Gamemanager.Instance.startLevel)
        {
            float num = Mathf.FloorToInt(timer / 60f);
            float num2 = Mathf.FloorToInt(timer % 60f);
            timerText.text = num + ":" + num2;
            if (!turnhead && buzztimer >= timer)
            {
                turnhead = true;
                print("TurnHead");
                StartCoroutine(TurnHead());
            }

            if (timer <= 0f)
            {
                timer = 0f;
                canvasmanager.Instance.Fail(1f);
                Gamemanager.Instance.gameOver = true;
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    public IEnumerator ShootSoilders()
    {
        foreach (var s in guards)
        {
            yield return new WaitForSeconds(0.1f);
            s.Shoot();
        }
    }

    public void StopSoilders()
    {
        foreach (var guard in guards) guard.Stop();
    }

    public IEnumerator TurnHead()
    {
        audio.Play();
        dollHead.DORotate(new Vector3(-90f,0f, 180f), 0.5f);
        dollHead.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        Gamemanager.Instance.StopAI();
        Gamemanager.Instance.Alert();
        Gamemanager.Instance.stopmovement = true;
        yield return new WaitForSeconds(0.7f);
        StartCoroutine(ShootSoilders());
        yield return new WaitForSeconds(0.3f);
        Player.DeadMethod();
        Gamemanager.Instance.DestroyAI();
        yield return new WaitForSeconds(1f);
        Gamemanager.Instance.stopmovement = false;
        dollHead.DORotate(new Vector3(-90f, 0f, 0f), 0.5f);
        dollHead.GetChild(0).gameObject.SetActive(false);
        turnhead = false;
        buzztimer = timer - Random.Range(2, 6);
        var delay = Random.Range(0.2f, 1f);
        Gamemanager.Instance.StartAI(delay);
        StopSoilders();
    }
}