using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BurstType { BulletType, BeamType };
[CreateAssetMenu( menuName = "Scriptable Objects/Defender Data")]


public class DefenderData : ScriptableObject
{
    public BurstType BurstType;
    public LineRenderer Beam;
    public GameObject Prefab;
    public GameObject BulletPrefab;

    public Material Material;
    public int damage;
    public int cost;
    public float range;
    public float fireRate;
    public float fireCountdown;
    public float rotateSpeed;
    public string targetTag;    
}
