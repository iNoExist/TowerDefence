using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
    public GameObject LevelMenu;
    int count;
    void Start()
    {
        count = LevelMenu.transform.childCount;
        for (int i = 1; i <= count; i++)
        {
            Debug.Log(i + " Check");
            if (PlayerPrefs.HasKey((i) + "Won"))
            {
                Debug.Log(i + " Key there");
                Button temp = LevelMenu.transform.Find((i+1).ToString()).gameObject.GetComponent<Button>();
                Debug.Log(temp);
                temp.interactable = true;
            }
        }
    }
    
    void Update()
    {

    }
}
