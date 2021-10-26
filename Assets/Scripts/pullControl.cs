using UnityEngine;

public class pullControl : MonoBehaviour
{
    
    public bool startGame;

    public float pullSpeed = 5f;

    public Transform moveObj;

    public Rigidbody[] playerRb;

    public Rigidbody[] enemyRb;

    public Rigidbody[] rope;

    public Animator Leveranim;

    public GameObject[] Rotets;

    public AudioSource yellingAudio;

    private bool gameEnd;

    private bool Rotet;

    private void Update()
    {
        if (startGame && !gameEnd)
        {
            if (Input.GetMouseButtonDown(0))
            { 
                Rotet = true;
              
                moveObj.position += transform.forward * pullSpeed * Time.deltaTime;
                
            }
              
            else if (!Input.GetMouseButton(0)) moveObj.position += -transform.forward * 0.5f * Time.deltaTime;
        }
    }

    public void Roteshion()
    {
        for (int i = 0; i < Rotets.Length; i++)
        {
            
           
            
                Debug.Log("Aviyu se");
                Rotets[i].transform.Rotate(0, -80f, 0);
            
           
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !gameEnd)
        {
            gameEnd = true;
            print("Loose");
            var array = playerRb;
            foreach (var obj in array)
            {
                obj.transform.GetComponent<Animator>().enabled = false;
                obj.useGravity = true;
                obj.isKinematic = false;
                obj.AddForce(-transform.forward * 200f, ForceMode.Impulse);
                obj.transform.GetComponent<AudioSource>().Play();
            }

            array = rope;
            foreach (var obj2 in array)
            {
                obj2.useGravity = true;
                obj2.isKinematic = false;
            }

            array = enemyRb;
            for (var i = 0; i < array.Length; i++) array[i].transform.GetComponent<Animator>().SetTrigger("Victory");
            Leveranim.enabled = true;
            canvasmanager.Instance.Fail(2f);
            yellingAudio.Stop();
        }

        if (other.CompareTag("enemy") && !gameEnd)
        {
            gameEnd = true;
            var array = enemyRb;
            foreach (var obj3 in array)
            {
                obj3.transform.GetComponent<Animator>().enabled = false;
                obj3.useGravity = true;
                obj3.isKinematic = false;
                obj3.AddForce(transform.forward * 200f, ForceMode.Impulse);
                obj3.transform.GetComponent<AudioSource>().Play();
            }

            array = rope;
            foreach (var obj4 in array)
            {
                obj4.useGravity = true;
                obj4.isKinematic = false;
            }

            array = playerRb;
            for (var i = 0; i < array.Length; i++) array[i].transform.GetComponent<Animator>().SetTrigger("Victory");
            canvasmanager.Instance.Win(2f);
            Leveranim.enabled = true;
            yellingAudio.Stop();
            print("Win");
        }
    }

   
    public void StartGame()
    {
        startGame = true;
        Roteshion();
        var array = enemyRb;
        for (var i = 0; i < array.Length; i++) array[i].transform.GetComponent<Animator>().SetTrigger("Pull");
        array = playerRb;
        for (var i = 0; i < array.Length; i++) array[i].transform.GetComponent<Animator>().SetTrigger("Pull");
        yellingAudio.Play();
    }
}