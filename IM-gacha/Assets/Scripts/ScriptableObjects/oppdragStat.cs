using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Oppdrag", menuName = "Oppdrag")]
public class oppdragStat : ScriptableObject
{
    public new string name;
    public int atk;
    public int hp;
    public int def;
}
