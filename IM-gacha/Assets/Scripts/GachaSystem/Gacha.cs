using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Gacha : MonoBehaviour
{
	public static bool multi;

	public int[] table =
	{
		30, //4 star
		10, //5 star
		60
	};
	public int total;
	public int randomNumber;
	private int currentPull = 0;
	public Sprite drop;
	static int random;
	public GameObject singleIcon;

	public GameObject[] multiIcons;

	public List<Sprite> star3 = new List<Sprite>();
	public List<Sprite> star4 = new List<Sprite>();
	public List<Sprite> star5 = new List<Sprite>();
	void Start()
	{
		int count = multi ? 10 : 1;
		total = table.Sum();
		for (int i = 0; i < count; i++)
		{
			randomNumber = UnityEngine.Random.Range(0, total);

			for (int j = 0; j < table.Length; j++)
			{
				if (randomNumber <= table[j])
				{
					character(table[j]);
					break;
				}
				else
				{
					randomNumber -= table[j];
				}
			}
		}
	}
	public void character(int rating)
	{
		switch (rating)
		{
			case 10:
				random = UnityEngine.Random.Range(0, star5.Count);
				drop = star5[random];
				Debug.Log(drop);
				break;
			case 30:
				random = UnityEngine.Random.Range(0, star4.Count);
				drop = star4[random];
				Debug.Log(drop);
				break;
			case 60:
				random = UnityEngine.Random.Range(0, star3.Count);
				drop = star3[random];
				Debug.Log(drop);
				break;
		}
		createBox(drop);
	}
	public void createBox(Sprite e)
	{
		if (!multi)
		{
			singleIcon.SetActive(true);
			singleIcon.GetComponent<Image>().sprite = e;
		}
		else
		{
			multiIcons[currentPull].SetActive(true);
			multiIcons[currentPull].GetComponent<Image>().sprite = e;
			currentPull++;
		}

	}
}
