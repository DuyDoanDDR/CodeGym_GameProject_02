using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender_Movement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        float distanceToVirus = Vector3.Distance(transform.position, VirusMovement.virusPosition);
        Vector3 defenderDir = (transform.position - VirusMovement.virusPosition).normalized;
        if (distanceToVirus < 11.5f)
        {
            if (Physics.Raycast(transform.position, defenderDir.normalized, out RaycastHit hit, distanceToVirus))
            {
                //Debug.Log("Targeted to Virus");
            }
            Quaternion defenderRotate = Quaternion.LookRotation(defenderDir);
            transform.rotation = Quaternion.Slerp(transform.rotation, defenderRotate, (VirusMovement.velocity).magnitude * Time.deltaTime);
        }
    }
}
