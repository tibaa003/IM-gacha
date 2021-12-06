using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class selectQuest : MonoBehaviour
{
    public static void LoadScene(string quest)
    {
        SceneManager.LoadScene("teamSetup", LoadSceneMode.Single);
        startQuest.questNr = quest;
    }
}
