using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelection : MonoBehaviour
{
    private GameObject[] characterList;

    private void Start()
    {
        characterList = new GameObject[transform.childCount];
        //Fill the array with our models
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }
        //We toggle off their renderer
        foreach (GameObject go in characterList)
        {
            go.SetActive(false);
        }
        // We toggle on the first index
        if (characterList[0])
        {
            characterList[0].SetActive(true);
        }
    }
}
