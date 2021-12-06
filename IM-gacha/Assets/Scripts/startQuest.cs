using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startQuest : MonoBehaviour
{
    public static string questNr;

    public static void loadscene()
    {
        SceneManager.LoadScene(questNr, LoadSceneMode.Single);
    }
}
