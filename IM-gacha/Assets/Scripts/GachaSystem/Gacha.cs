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
    public Sprite drop;
    static int random;
    public GameObject singleIcon;

    public GameObject[] multiIcons;

    public List<Sprite> star3 = new List<Sprite>();
    public List<Sprite> star4 = new List<Sprite>();
    public List<Sprite> star5 = new List<Sprite>();
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
            Debug.Log(drop);
        }
        else if (rating == 30)
        {
            random = UnityEngine.Random.Range(0, star4.Count);
            drop = star4[random];
            Debug.Log(drop);
        } else if (rating == 60){
            random = UnityEngine.Random.Range(0, star3.Count);
            drop = star3[random];
            Debug.Log(drop);
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

