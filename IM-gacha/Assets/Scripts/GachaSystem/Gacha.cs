using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Gacha : MonoBehaviour
{
	public static bool multi;

	public GameObject singleBorder;
	public GameObject[] multiBorders;
	public Sprite starborder3;
	public Sprite starborder4;
	public Sprite starborder5;
	public int[] table =
	{
		30, //4 star
		10, //5 star
		60
	};
	public int total;
	public int randomNumber;
	private int currentPull = 0;
	public charStat drop;
	static int random;
	public GameObject singleIcon;

	public GameObject[] multiIcons;

	public List<charStat> star3 = new List<charStat>();
	public List<charStat> star4 = new List<charStat>();
	public List<charStat> star5 = new List<charStat>();
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
		Sprite starborder;
		switch (rating)
		{
			case 10:
				random = UnityEngine.Random.Range(0, star5.Count);
				drop = star5[random];
				starborder = starborder5;
				break;
			case 30:
				random = UnityEngine.Random.Range(0, star4.Count);
				drop = star4[random];
				starborder = starborder4;
				break;
			case 60:
				random = UnityEngine.Random.Range(0, star3.Count);
				drop = star3[random];
				starborder = starborder3;
				break;
		}
		if(multi){
			multiBorders[currentPull].SetActive(true);
			multiBorders[currentPull].GetComponent<Image>().sprite = starborder;
		}else{
			singleBorder.SetActive(true);
			singleBorder.GetComponent<Image>().sprite = starborder;
		}
		createBox(drop);
	}
	public void createBox(charStat e)
	{
		if (!multi)
		{
			singleIcon.SetActive(true);
			singleIcon.GetComponent<Image>().sprite = e.img;
		}
		else
		{
			multiIcons[currentPull].SetActive(true);
			multiIcons[currentPull].GetComponent<Image>().sprite = e.img;
			currentPull++;
		}
	}
}
