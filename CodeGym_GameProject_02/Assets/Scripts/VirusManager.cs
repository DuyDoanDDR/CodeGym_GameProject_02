using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusManager : MonoBehaviour
{
   public static VirusManager instance;
    public List<GameObject> allViruses = new List<GameObject>();

    private void Awake()
    {
        instance = this;
    }
    public void AddVirus(GameObject virus)
    {
        allViruses.Add(virus);
    }
    public void DeleteVirus(GameObject virus)
    {
        allViruses.Remove(virus);
    }

}
