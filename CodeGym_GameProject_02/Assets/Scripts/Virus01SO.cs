using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Virus01 Data", menuName = "Scriptable Objects/Virus01 Data")]
public class Virus01SO : ScriptableObject
{
    public int maxHp;
    public float speed;
    public GameObject virusPrefab;
    public int damaged;
    public int value;
    
}
