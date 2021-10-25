using UnityEngine;

public class soilder : MonoBehaviour
{
    public ParticleSystem bulletParticle;

    public AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        bulletParticle = GetComponentInChildren<ParticleSystem>();
    }

    public void Shoot()
    {
        if (Gamemanager.Instance.DummyList.Count != 0)
        {
            bulletParticle.transform.LookAt(Gamemanager.Instance
                .DummyList[Random.Range(0, Gamemanager.Instance.DummyList.Count)].transform);
            bulletParticle.Play();
        }

        audio.Play();
    }

    public void Stop()
    {
    }
}