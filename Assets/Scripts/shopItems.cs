using UnityEngine;

public class shopItems : MonoBehaviour
{
    public bool isBuy;

    private void Start()
    {
        if (PlayerPrefs.GetInt(transform.name, 0) == 1 || isBuy)
        {
            isBuy = true;
            foreach (Transform item in transform) item.gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("hairselect", 0) == transform.GetSiblingIndex())
                transform.GetChild(1).gameObject.SetActive(true);
            else
                transform.GetChild(1).gameObject.SetActive(false);
        }
        else
        {
            canvasmanager.Instance.hats.Add(this);
        }
    }

    private void Update()
    {
    }

    public void OnSelect()
    {
        if (isBuy)
        {
            var componentsInChildren = transform.parent.GetComponentsInChildren<shopItems>();
            for (var i = 0; i < componentsInChildren.Length; i++)
                componentsInChildren[i].transform.GetChild(1).gameObject.SetActive(false);
            foreach (Transform item in transform) item.gameObject.SetActive(true);
            PlayerPrefs.SetInt("hat", transform.GetSiblingIndex());
            canvasmanager.Instance.SetHats();
            PlayerPrefs.SetInt("hairselect", transform.GetSiblingIndex());
        }
    }

    public void Buy()
    {
        isBuy = true;
        PlayerPrefs.SetInt(transform.name, 1);
        var componentsInChildren = transform.parent.GetComponentsInChildren<shopItems>();
        for (var i = 0; i < componentsInChildren.Length; i++)
            componentsInChildren[i].transform.GetChild(1).gameObject.SetActive(false);
        foreach (Transform item in transform) item.gameObject.SetActive(true);
        PlayerPrefs.SetInt("hat", transform.GetSiblingIndex());
        canvasmanager.Instance.SetHats();
        PlayerPrefs.SetInt("hairselect", transform.GetSiblingIndex());
        canvasmanager.Instance.hats.Remove(this);
    }
}