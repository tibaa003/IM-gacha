using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MultiSummon : MonoBehaviour
{
    public void summon(bool multiple)
    {
        SceneLoader.LoadScene("Summon");
        Gacha.multi = multiple;
    }
}
