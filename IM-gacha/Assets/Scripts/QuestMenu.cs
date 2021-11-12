using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestMenu : MonoBehaviour
{
    public GameObject Story;
    public GameObject Quests1;
    public GameObject Quests2;
    public GameObject Quests3;


    public void ShowQuests(int Chapter)
    {

        Quests1.SetActive(false);
        Quests2.SetActive(false);
        Quests3.SetActive(false);
        Story.SetActive(false);


        if (Chapter == 1)
        {
            if (Quests1.activeInHierarchy == true)
            {
                Quests1.SetActive(false);
            }
            else
            {
                Quests1.SetActive(true);
                
            }
        }

        if (Chapter == 2)
        {
            if (Quests2.activeInHierarchy == true)
            {
                Quests2.SetActive(false);
            }
            else
            {
                Quests2.SetActive(true);
            }
        }

        if (Chapter == 3)
        {
            if (Quests3.activeInHierarchy == true)
            {
                Quests3.SetActive(false);
            }
            else
            {
                Quests3.SetActive(true);
            }
        }


    }
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ShowStory()
    {
        if (Story.activeInHierarchy == true)
        {


            Story.SetActive(false);

        }

        else
        {
            Story.SetActive(true);
            Quests1.SetActive(false);
            Quests2.SetActive(false);
            Quests3.SetActive(false);
        }

    }
}


 

