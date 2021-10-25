using DG.Tweening;
using UnityEngine;

public class glassPlayer : MonoBehaviour
{
    public Animator anim;

    public Transform camObj;

    public Rigidbody[] rbs;

    public GameObject finalCam;

    public GameObject indicator;

    public AudioSource audio;

    public AudioSource Jumpaudio;

    public glassCntrl GlassCntrl;

    public GameObject popEffect;

    private bool canJump;

    private bool gameOver;

    private bool isDead;

    private void Start()
    {
        rbs = GetComponentsInChildren<Rigidbody>();
        IsKinematic(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "break" && !isDead)
        {
            audio.Play();
            indicator.SetActive(false);
            isDead = true;
            print("Die");
            other.transform.GetComponent<MeshRenderer>().enabled = false;
            other.transform.GetChild(0).gameObject.SetActive(true);
            finalCam.SetActive(true);
            IsKinematic(false);
            canvasmanager.Instance.Fail(3.5f);
        }

        if (other.tag == "Untagged" && other.name == "Final")
        {
            print("Win");
            gameOver = true;
            popEffect.SetActive(true);
            EndMovement();
        }
    }

    public void Movement(bool right)
    {
        if (!isDead && !canJump && !gameOver && GlassCntrl.startGame)
        {
            canJump = true;
            anim.SetTrigger("Jump");
            transform.DOMoveZ(transform.position.z + 4f, 1f);
            camObj.DOMoveZ(transform.position.z + 4f, 1f).OnComplete(delegate { canJump = false; });
            transform.DOMoveY(16.26f, 0.5f);
            camObj.DOMoveY(16.26f, 0.5f);
            transform.DOMoveY(14.4f, 0.5f).SetDelay(0.5f);
            camObj.DOMoveY(14.4f, 0.5f).SetDelay(0.5f);
            if (right)
                transform.DOMoveX(1.5f, 1f);
            else
                transform.DOMoveX(-1.5f, 1f);
            Jumpaudio.Play();
        }
    }

    public void EndMovement()
    {
        indicator.SetActive(false);
        anim.SetTrigger("JumpGoal");
        transform.DOMoveZ(transform.position.z + 4f, 1f);
        camObj.DOMoveZ(transform.position.z + 4f, 1f);
        transform.DOMoveY(16.26f, 0.5f);
        camObj.DOMoveY(16.26f, 0.5f);
        transform.DOMoveY(15.4f, 0.5f).SetDelay(0.5f);
        camObj.DOMoveY(15.4f, 0.5f).SetDelay(0.5f);
        transform.DOMoveX(0f, 1f);
        canvasmanager.Instance.Win(3f);
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
        for (var i = 0; i < array.Length; i++) array[i].isKinematic = false;
    }
}