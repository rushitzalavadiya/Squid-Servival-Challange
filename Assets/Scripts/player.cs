using TMPro;
using UnityEngine;

public class player : MonoBehaviour
{
    public float speed = 7f;

    public Animator anim;

    public Rigidbody[] rbs;

    public TextMeshPro number;

    public GameObject alert;

    public GameObject indicator;

    public AudioSource audio;

    public GameObject popEffect;

    public AudioSource bgAudio;

    public Transform hatsParent;

    private bool isDead;

    private void Start()
    {
        if (Gamemanager.Instance.levels == Gamemanager.stages.green)
        {
            rbs = GetComponentsInChildren<Rigidbody>();
            IsKinematic(true);
            number.text = Random.Range(100, 900).ToString();
        }

        SetHats();
    }

    private void Update()
    {
        if (Gamemanager.Instance.gameOver || !Gamemanager.Instance.startLevel ||
            Gamemanager.Instance.levels != 0) return;
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Run");
            audio.Play();
        }

        if (Input.GetMouseButtonUp(0))
        {
            anim.SetTrigger("Idle");
            audio.Stop();
        }

        if (Input.GetMouseButton(0))
        {
            if (Gamemanager.Instance.stopmovement && !isDead)
            {
                isDead = true;
                alert.SetActive(true);
                indicator.SetActive(false);
                print("BooYah!");
            }

            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            bgAudio.Stop();
            popEffect.SetActive(true);
            audio.Stop();
            print("Win!");
            Gamemanager.Instance.gameOver = true;
            canvasmanager.Instance.Win(3f);
            anim.SetTrigger("JumpGoal");
        }
    }

    public void DeadMethod()
    {
        if (isDead)
        {
            Gamemanager.Instance.gameOver = true;
            speed = 0f;
            alert.gameObject.SetActive(false);
            canvasmanager.Instance.Fail(2f);
            IsKinematic(false);
            bgAudio.Stop();
        }
    }

    public void SetHats()
    {
        foreach (Transform item in hatsParent) item.gameObject.SetActive(false);
        var @int = PlayerPrefs.GetInt("hat", 0);
        hatsParent.GetChild(@int).gameObject.SetActive(true);
    }

    private void IsKinematic(bool option)
    {
        Rigidbody[] array;
        if (option)
        {
            array = rbs;
            for (var i = 0; i < array.Length; i++) array[i].isKinematic = true;
            return;
        }

        anim.enabled = false;
        array = rbs;
        foreach (var obj in array)
        {
            obj.isKinematic = false;
            obj.AddForce(-transform.forward * 2f, ForceMode.Impulse);
        }
    }
}