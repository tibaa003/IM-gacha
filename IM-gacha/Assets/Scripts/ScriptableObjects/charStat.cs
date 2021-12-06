using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character/4star")]
public class charStat : ScriptableObject
{
    public int id;
    public new string name;
    public int atk;
    public int hp;
    public int def;
    public Sprite img;
}
