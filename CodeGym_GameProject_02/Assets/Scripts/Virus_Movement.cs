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
    
    
    public VirusData virusData;
   //public Virus virus;
    

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
        velocity = new Vector3(1f,0,0).normalized;
    }

    void GetNextWayPoints()
    {
        if (Vector3.Distance(transform.position, target.position) < 0.5f)
        {
            if (wayPointsIndex >= WayPoints.wayPoints.Length - 1)
            {
                EndPath();
                return;
            }
            wayPointsIndex++;
            target = WayPoints.wayPoints[wayPointsIndex];
        }
    }

    void EndPath()
    {
        PlayerStats.lives -= virusData.damaged;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {  
        Vector3 moveDir = (target.position - transform.position).normalized;
        Vector3 newPos = Vector3.MoveTowards(transform.position, target.position, velocity.magnitude * GetComponent<Virus>().VirusUpdateSpeed * Time.deltaTime);
        transform.position = newPos;
        Quaternion targetRotate = Quaternion.LookRotation(moveDir);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotate, velocity.magnitude * GetComponent<Virus>().VirusUpdateSpeed * Time.deltaTime);
        GetNextWayPoints();

        GetComponent<Virus>().VirusUpdateSpeed = virusData.speed;





    }
}
