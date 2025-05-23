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
    //public static Vector3 virusVelocity;
    //public static float damage = 10;

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
        velocity = new Vector3(0,0,-10);
    }

    // Update is called once per frame
    void Update()
    {
        //virusVelocity = velocity;
        virusPosition = transform.position;
        //transform.Translate(velocity.normalized * Time.deltaTime);
        Vector3 moveDir = (transform.position - target.position).normalized;

        Vector3 newPos = Vector3.MoveTowards(transform.position, target.position, velocity.magnitude * Time.deltaTime);
        transform.position = newPos;
        Quaternion targetRotate = Quaternion.LookRotation(moveDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotate, velocity.magnitude * Time.deltaTime);



        if (Vector3.Distance(transform.position, target.position) < 0.5)
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
