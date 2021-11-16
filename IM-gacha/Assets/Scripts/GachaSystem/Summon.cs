using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Summon : MonoBehaviour
{
    public void summon(bool multiple)
    {
        SceneLoader.LoadScene("Summon");
        Gacha.multi = multiple;
    }

}
