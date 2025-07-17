using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Virus Data", menuName = "Scriptable Objects/Virus Data")]
public class VirusData : ScriptableObject
{
    public float maxHp;
    public float speed;
    public GameObject virusPrefab;
    public int damaged;
    public int value;
    
}
