using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet01 : MonoBehaviour
{
    private Transform target;
    public float speed = 70;
    public int damage;
    public static Bullet01 instance;

    public Defender01SO defender01;

    
 
    public void Seek(Transform _target)
    {
        target = _target;  
       
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        damage = defender01.damage;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 targetDir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime; 

        if (targetDir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(targetDir.normalized * distanceThisFrame, Space.World);     
    }
  
  void Damage(Transform virus)
    {
        if (virus.tag  == "Virus")
        {
            Virus01 v = virus.GetComponent<Virus01>(); 
           if (v != null)
            {
                v.TakeDamage(damage);
            }
        }
    }

    void HitTarget()
    {       
        Damage(target);
        Debug.Log("Hit");
        Destroy(gameObject);      
    }
}
