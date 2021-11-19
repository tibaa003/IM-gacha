using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeightedLoottable : MonoBehaviour
{
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
        "Peder VG2",
        "Ali VG2"
    };

    
    public void start()
    {
        total = 0;
        foreach (var item in table)
        {
            total += item; //finner ut hvor mange total weight er
        }

        randomNumber = Random.Range(0, total);
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
    public void character(int rating) {
        if (rating == 10)
        {
            
        } else if (rating == 30){
        random = Random.Range(0, Fstar.Length);
            drop = Fstar[random];
            Debug.Log(drop);
        } else{}
    }
}
