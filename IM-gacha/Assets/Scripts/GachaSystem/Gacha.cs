using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

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
    public int rn;
    private int currentPull = 0;
    public charStat drop;
    static int random;
    public GameObject singleIcon;
    public GameObject singleBorder;

    public GameObject[] multiIcons;
    public GameObject[] multiBorders;
    public Sprite starborder3;
    public Sprite starborder4;
    public Sprite starborder5;

    public List<charStat> star3 = new List<charStat>();
    public List<charStat> star4 = new List<charStat>();
    public List<charStat> star5 = new List<charStat>();
    public List<charStat> pulled = new List<charStat>();
    void Start()
    {
        //Animatio
        if (!multi)
        {
            total = 0;
            foreach (var item in table)
            {
                total += item; //finner ut hvor mange total weight er
            }

            randomNumber = UnityEngine.Random.Range(0, total);
            rn = randomNumber;

            for (int i = 0; i < table.Length; i++)
            {
                if (randomNumber <= table[i])
                {
                    character(table[i]);
                    break;
                }
                else
                {
                    randomNumber -= table[i];
                }

            }
        }
        else
        {
            for (int i = 0; i < 10; i++)
            {
                total = 0;
                foreach (var item in table)
                {
                    total += item; //finner ut hvor mange total weight er
                }

                randomNumber = UnityEngine.Random.Range(0, total);
                rn = randomNumber;

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
    }
    public void character(int rating)
    {
        if (rating == 10)
        {
            random = UnityEngine.Random.Range(0, star5.Count);
            drop = star5[random];
            if (!multi)
            {
                singleBorder.SetActive(true);
                singleBorder.GetComponent<Image>().sprite = starborder5;
            }
            else
            {
                multiBorders[currentPull].SetActive(true);
                multiBorders[currentPull].GetComponent<Image>().sprite = starborder5;
            }
        }
        else if (rating == 30)
        {
            random = UnityEngine.Random.Range(0, star4.Count);
            drop = star4[random];
            if (!multi)
            {
                singleBorder.SetActive(true);
                singleBorder.GetComponent<Image>().sprite = starborder4;
            }
            else
            {
                multiBorders[currentPull].SetActive(true);
                multiBorders[currentPull].GetComponent<Image>().sprite = starborder4;
            }
        }
        else if (rating == 60)
        {
            random = UnityEngine.Random.Range(0, star3.Count);
            drop = star3[random];
            if (!multi)
            {
                singleBorder.SetActive(true);
                singleBorder.GetComponent<Image>().sprite = starborder3;
            }
            else
            {
                multiBorders[currentPull].SetActive(true);
                multiBorders[currentPull].GetComponent<Image>().sprite = starborder3;
            }
        }
        createBox(drop);
        // SaveSystem.SaveChar(drop);
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


    //Lagt til fra random ass video
}



