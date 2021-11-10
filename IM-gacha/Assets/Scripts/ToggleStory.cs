using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleStory : MonoBehaviour
{
    public GameObject Square;

    void Start()
    {

    }


    void Update()
    {

    }
    public void WhenButtonClicked()
    {
        if (Square.activeInHierarchy == true)
            Square.SetActive(false);
        else
            Square.SetActive(true);
    }
}
