using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battle : MonoBehaviour
{
	public List<charStat> charStats;

	public GameObject skillTxt;
	private bool brille;
	private bool monster;
	public List<GameObject> charObjects;
	public List<Slider> charSliders;
	public oppdragStat oppdragStats;
	public Slider hpSlider;

	public bool internetOff;
	public Slider countdown;
	private int bossHp;
	private List<int> charHps;
	public GameObject endimg;
	public GameObject endimg2;
	public int skillPoints;

	private int combinedAtk;
	// Start is called before the first frame update
	void Start()
	{
		bossHp = oppdragStats.hp;
		hpSlider.maxValue = bossHp;
		char1Slider.maxValue = char1.hp;
		char2Slider.maxValue = char2.hp;
		char3Slider.maxValue = char3.hp;
		foreach(chatStat c in charStats) charHps.Add(c.hp);
		for(int i=0;i<charStats.Count;++i) charObjects[i] = charStats[i].img;
		Application.targetFrameRate = 30;
	}

	// Update is called once per frame
	void Update()
	{
		if (skillPoints < 1200)++skillPoints;
		for(int i=0;i<size(charHps);++i) charHps[i] = charHps[i]<0?0:charHps[i];

		skillTxt.GetComponent<Text>().text = "" + skillPoints.ToString() + "/1200";

		combinedAtk = 0;
		for(int i=0;i<charStats.Count;++i) {
			combinedAtk += charStats[i].atk * (charHps[i]/1000);
			charHps[i] -= oppdragStats.atk / charStats[i].def < 1 ? 1 : oppdragStats.atk / charStats[i].def;
		}
		if (brille) combinedAtk *= 2;
		if (monster) combinedAtk += 100;

		if (internetOff)
		{
			for(int i=0;i<charHps.Count;++i) charHps[i] += 5000;
		}
		bossHp -= combinedAtk;

		hpSlider.value = bossHp;
		for(int i=0;i<charSliders.Count;++i) charSliders[i].value = charHps[i];

		if (bossHp <= 0)
		{
			endimg.SetActive(true);
			endimg2.SetActive(true);
		}
		if (countdown.value == 0)
		{
			SceneLoader.LoadScene("MainMenu");
		}
	}
	public void brilleSkill()
	{
		if (!brille)
		{
			if (skillPoints >= 500)
			{
				skillPoints -= 500;
				brille = true;
			}
		}

	}
	public void monsterSkill()
	{
		if (!monster)
		{
			if (skillPoints >= 300)
			{
				skillPoints -= 300;
				monster = true;
			}
		}

	}
	public void internetOffSkill()
	{
		if (!internetOff)
		{
			if (skillPoints >= 700)
			{
				skillPoints -= 700;
				internetOff = true;
			}
		}

	}
}
