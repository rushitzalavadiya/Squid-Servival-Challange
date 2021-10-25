using System.Collections;
using DG.Tweening;
using UnityEngine;

public class glassCntrl : MonoBehaviour
{
    public Transform glassParent;

    public bool startGame;

    private IEnumerator showPath()
    {
        foreach (Transform item in glassParent)
        {
            var child = item.GetChild(Random.Range(0, 2));
            child.tag = "Untagged";
            var i = child.GetComponent<MeshRenderer>();
            var cr = i.material.color;
            i.material.DOColor(Color.green, 0.3f);
            yield return new WaitForSeconds(0.5f);
            i.material.DOColor(cr, 0.2f);
        }
    }

    private void jump()
    {
        startGame = true;
    }

    public void StartGame()
    {
        print("Calling!");
        StartCoroutine(showPath());
        Invoke("jump", 0.5f);
    }
}