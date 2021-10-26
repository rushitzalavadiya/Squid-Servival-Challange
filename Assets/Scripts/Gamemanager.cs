using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamemanager : MonoBehaviour
{
    public enum stages
    {
        green,
        candy,
        pull,
        glass
    }

    public static Gamemanager Instance;

    public bool stopmovement;

    public List<enemies> enemiesList;

    public List<enemies> DummyList;

    public bool gameOver;

    public GameObject winObject;

    
    public GameObject FailObject;
    
    public GameObject directionLight;
    
    public stages levels;

    public bool startLevel;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (levels == stages.candy && startLevel && !gameOver && Input.GetMouseButton(0)) RayMethod();
    }

    public void DestroyAI()
    {
        if (enemiesList.Count != 0) StartCoroutine(AiDead());
    }

    private IEnumerator AiDead()
    {
        foreach (var dummy in DummyList)
        {
            dummy.alert.SetActive(false);
            dummy.Die();
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void RayMethod()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var hitInfo))
        {
            if (hitInfo.transform.tag == "extra")
            {
                print("throw");
                hitInfo.transform.tag = "Untagged";
                var component = hitInfo.transform.GetComponent<Rigidbody>();
                component.isKinematic = false;
                component.useGravity = true;
                hitInfo.transform.parent = null;
                hitInfo.transform.GetComponent<AudioSource>().Play();
            }
            else if (hitInfo.transform.tag == "inside")
            {
                print("Fail");
                FindObjectOfType<followObject>().FailedGamePlay();
                gameOver = true;
                hitInfo.transform.tag = "Untagged";
                var component2 = hitInfo.transform.GetComponent<Rigidbody>();
                component2.isKinematic = false;
                component2.useGravity = true;
                Invoke("CandyDie", 1f);
                hitInfo.transform.GetComponent<AudioSource>().Play();
                canvasmanager.Instance.Fail(3.5f);
            }
        }
    }

    private void CandyDie()
    {
        FindObjectOfType<candySoilder>().Die();
    }

    public void StartGame()
    {
        startLevel = true;
        if (levels == stages.candy) FindObjectOfType<followObject>().StartGameplay();
    }

    public void Alert()
    {
        if (enemiesList.Count == 0) return;

        var num = Random.Range(2, 5);
        if (DummyList.Count != 0) DummyList.Clear();

        for (var i = 0; i < num; i++)
            if (enemiesList.Count != 0)
            {
                var index = Random.Range(0, enemiesList.Count);
                DummyList.Add(enemiesList[index]);
                enemiesList[index].alert.SetActive(true);
                enemiesList.Remove(enemiesList[index]);
            }
    }

    public void StartAI(float delay)
    {
        foreach (var enemies in enemiesList) enemies.StartRun(delay);
    }

    public void StopAI()
    {
        foreach (var enemies in enemiesList) enemies.StopRun();
    }
}