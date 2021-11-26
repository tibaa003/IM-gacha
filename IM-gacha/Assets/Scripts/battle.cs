using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class battle : MonoBehaviour
{
    public charStat char1;

    public GameObject skillTxt;
    public charStat char2;

    public charStat char3;

    private bool brille;
    private bool monster;
    public GameObject char1Object;
    public GameObject char2Object;
    public GameObject char3Object;
    public oppdragStat oppdragStats;
    public Slider hpSlider;

    public bool internetOff;
    public Slider char1Slider;
    public Slider char2Slider;
    public Slider char3Slider;
    public Slider countdown;
    private int bossHp;
    private int char1Hp;
    private int char2Hp;
    private int char3Hp;
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
        char1Hp = char1.hp;
        char2Hp = char2.hp;
        char3Hp = char3.hp;
        char1Object.GetComponent<Image>().sprite = char1.img;
        char2Object.GetComponent<Image>().sprite = char2.img;
        char3Object.GetComponent<Image>().sprite = char3.img;
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (skillPoints < 1200)
        {
            skillPoints++;
        }
        if (char1Hp < 0)
        {
            char1Hp = 0;
        }
        if (char2Hp < 0)
        {
            char2Hp = 0;
        }
        if (char3Hp < 0)
        {
            char3Hp = 0;
        }

        skillTxt.GetComponent<Text>().text = "" + skillPoints.ToString() + "/1200";

        combinedAtk = ((char1.atk * (char1Hp / 1000)) + (char2.atk * (char2Hp / 1000)) + (char3.atk * (char3Hp / 1000))) / oppdragStats.def;

        if (brille)
        {
            combinedAtk = combinedAtk * 2;
        }

        if (monster)
        {
            combinedAtk += 100;
        }

        if (internetOff)
        {
            char1Hp += 5000;
            char2Hp += 5000;
            char3Hp += 5000;
        }
        bossHp -= combinedAtk;

        if (oppdragStats.atk / char1.def < 1)
        {
            char1Hp -= 1;
        }
        else
        {
            char1Hp -= oppdragStats.atk / char1.def;
        }
        if (oppdragStats.atk / char2.def < 1)
        {
            char2Hp -= 1;
        }
        else
        {
            char2Hp -= oppdragStats.atk / char2.def;
        }
        if (oppdragStats.atk / char3.def < 1)
        {
            char3Hp -= 1;
        }
        else
        {
            char3Hp -= oppdragStats.atk / char3.def;
        }
        hpSlider.value = bossHp;
        char1Slider.value = char1Hp;
        char3Slider.value = char3Hp;
        char2Slider.value = char2Hp;

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
