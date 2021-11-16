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
        60, //3 star i %
        30, //4 star
        10  //5 star
    };
    public int total;
    public int randomNumber;
    public int rn;
    public string drop;
    static int random;
    public string[] Fstar = {
        "Titas VG2",
        "Srimon VG2",
        "Tias VG2",
        "PederVG2",
        "Ali VG2"
    };
    public GameObject singleIcon;

    public Sprite peder;

    public int latestPull;
    public string[] pulled;

    void Start()
    {
        //Animation
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
                    return;
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
                        return;
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

        }
        else if (rating == 30)
        {
            random = UnityEngine.Random.Range(0, Fstar.Length);
            drop = Fstar[random];
            Debug.Log(drop);
        }
        else { }
        Array.Resize<string>(ref pulled, pulled.Length + 1);
        pulled[latestPull] = drop;
        createBox();
    }
    public void createBox(){
        singleIcon.SetActive(true);
        singleIcon.GetComponent<Image>().sprite = peder;
    }
}

