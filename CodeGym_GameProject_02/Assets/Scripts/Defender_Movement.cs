using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender_Movement : MonoBehaviour
{
    
    private Vector3 defenderDir;

    
    // Start is called before the first frame update
    void Start()
    {
       
       
    }

    // Update is called once per frame
    void Update()
    {
        defenderDir = (transform.position - VirusMovement.virusPosition).normalized;
        Quaternion defenderRotate = Quaternion.LookRotation(defenderDir);

        transform.rotation = Quaternion.Slerp(transform.rotation, defenderRotate, (VirusMovement.velocity).magnitude * Time.deltaTime);
    }
}
