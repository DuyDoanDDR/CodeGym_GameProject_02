using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Defender01 Data", menuName = "Scriptable Objects/Defender01 Data")]
public class Defender01SO : ScriptableObject
{
    public GameObject Prefab;
    public int damage;
    public int cost;
    public float range;
    public float fireRate;
    
}
