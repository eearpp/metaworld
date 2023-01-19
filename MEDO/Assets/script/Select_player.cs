using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Select_player : MonoBehaviour
{
    public static Select_player Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

    }

    public List<GameObject> characterHold;
    [SerializeField] GameObject characterRoot;
    [SerializeField] GameObject avartarhold_gobj;

    public int listCount = 0;

    void Start()
    {
        for (int i = 0; i < characterHold.Count; i++)
        {
            Instantiate(characterHold[i], avartarhold_gobj.transform.position, Quaternion.identity, avartarhold_gobj.transform);
        }

        SelectShowAvater(0);
    }

    public void LeftClick()
    {
        if (listCount <= 0)
        {
            listCount = characterHold.Count-1;
        }
        else
        {
            listCount--;
        }

        SelectShowAvater(listCount);        
    }

    public void RightClick()
    {
        if (listCount >= characterHold.Count-1)
        {
            listCount = 0;
        }
        else
        {
            listCount++;
        }

        SelectShowAvater(listCount);
    }

    void SelectShowAvater(int num)
    {
        foreach (Transform child in avartarhold_gobj.transform)
        {
            if (child != avartarhold_gobj.transform.GetChild(num))
            {
                child.gameObject.SetActive(false);
            }
            else
            {
                child.gameObject.SetActive(true);
            }

        }
    }

}
