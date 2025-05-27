using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class VirusMovement : MonoBehaviour
{
    public static Vector3 velocity;
    private Transform target;
    private int wayPointsIndex = 0;
    public static Vector3 virusPosition;
    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Tower"))
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        target = WayPoints.wayPoints[0];
        velocity = new Vector3(10f,0,0);
    }

    // Update is called once per frame
    void Update()
    {
       
        virusPosition = transform.position;
        
        Vector3 moveDir = (target.position - transform.position).normalized;

        Vector3 newPos = Vector3.MoveTowards(transform.position, target.position, velocity.magnitude * Time.deltaTime);
        transform.position = newPos;
        Quaternion targetRotate = Quaternion.LookRotation(moveDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotate, velocity.magnitude * Time.deltaTime);



        if (Vector3.Distance(transform.position, target.position) < 0.5f)
        {
            if (wayPointsIndex >= WayPoints.wayPoints.Length - 1)
            {
                Destroy(gameObject);
                return;
            }
            wayPointsIndex++;
            target = WayPoints.wayPoints[wayPointsIndex];
        }

    }
}
