using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuestMenu : MonoBehaviour
{
	private GameObject Story;
	private List<GameObject> Quests = new List<GameObject>();

	public void Start(){
		Story = transform.Find("StoryPopup").gameObject;
		Transform QuestPopup = transform.Find("QuestPopup");
		foreach(Transform child in QuestPopup){
			Quests.Add(child.gameObject);
		}
	}
	public void ShowQuests(int Chapter)
	{
		foreach(GameObject quest in Quests){
			quest.SetActive(false);
		}
		Story.SetActive(false);
		switch (Chapter)
		{
			default:
				Quests[Chapter-1].SetActive(!Quests[Chapter-1].activeInHierarchy);
				break;
		}
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
			foreach(GameObject quest in Quests){
				quest.SetActive(false);
			}
		}
	}
}
