using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class enemies : MonoBehaviour
{
    public float moveSpeed = 7f;

    public Transform movePos;

    public NavMeshAgent agent;

    public Rigidbody[] rbs;

    public GameObject alert;

    public GameObject bloodParticle;

    public SkinnedMeshRenderer skin;

    public TextMeshPro number;

    public Transform movePosParent;

    public AudioClip[] clips;

    public AudioSource audio;

    private Animator anim;

    private bool canRun;

    private bool isDead;

    private bool reached;

    private bool startrun;

    private void Start()
    {
        movePos = movePosParent.GetChild(Random.Range(0, movePosParent.childCount));
        movePos.parent = null;
        agent = GetComponent<NavMeshAgent>();
        rbs = GetComponentsInChildren<Rigidbody>();
        anim = GetComponent<Animator>();
        AddForce(true, 0f);
        if ((bool)number) number.text = Random.Range(100, 900).ToString();
    }

    private void Update()
    {
        if (!canRun && Gamemanager.Instance.startLevel) agent.SetDestination(movePos.position);
        if (!reached && Vector3.Distance(transform.position, movePos.position) < 0.1f && !isDead)
        {
            isDead = true;
            anim.SetTrigger("JumpGoal");
            agent.speed = 0f;
        }

        if (!startrun && Gamemanager.Instance.startLevel)
        {
            startrun = true;
            StartRun(0f);
        }
    }

    public void AddForce(bool kinematic, float force)
    {
        var array = rbs;
        foreach (var rigidbody in array)
        {
            if (kinematic)
                rigidbody.isKinematic = true;
            else
                rigidbody.isKinematic = false;
            rigidbody.AddForce(-transform.forward * force, ForceMode.Impulse);
        }
    }

    public void StartRun(float delay)
    {
        canRun = false;
        Invoke("run", delay);
    }

    private void run()
    {
        anim.SetTrigger("Run");
        moveSpeed = Random.Range(2f, 3.1f);
        agent.speed = moveSpeed;
    }

    public void StopRun()
    {
        canRun = true;
        agent.speed = 0f;
        anim.SetTrigger("Idle");
    }

    public void Die()
    {
        audio.clip = clips[Random.Range(0, clips.Length)];
        audio.Play();
       // skin.material.DOColor(Color.grey, 0.5f);
        bloodParticle.SetActive(true);
        anim.enabled = false;
        AddForce(false, 10f);
        agent.speed = 0f;
    }
}