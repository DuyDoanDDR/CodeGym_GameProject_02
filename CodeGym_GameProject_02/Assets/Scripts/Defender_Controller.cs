using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Rendering;

public class Defender_Controller : MonoBehaviour
{
    private Transform targetPos;

    public float range = 11.5f;
    private GameObject currentTarget;
    public string targetTag = "Virus";
    public float rotateSpeed;

    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject bulletPrefs;
    public Transform firePoint;

    public ParticleSystem burstEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }


    // Update is called once per frame
    void Update()
    {
        if (currentTarget != null)
        {
            float distanceToVirus = Vector3.Distance(transform.position, currentTarget.transform.position);
            Vector3 targetDir = (currentTarget.transform.position - transform.position).normalized;
            targetDir.y = 0;
            if (distanceToVirus <= range)
            {
                Quaternion defenderRotate = Quaternion.LookRotation(targetDir);
                transform.rotation = Quaternion.Slerp(transform.rotation, defenderRotate, rotateSpeed * Time.deltaTime);
                if (fireCountdown <= 0f)
                {
                    Shoot();
                    fireCountdown = 1f / fireRate;
                }
                fireCountdown -= Time.deltaTime;
            }
            else
            {
                currentTarget = null;
            }
        }
        else
        {
            GameObject[] viruses = GameObject.FindGameObjectsWithTag(targetTag);
            foreach (GameObject virus in viruses)
            {
                if (virus == null)
                {
                    continue;
                }
                if (Vector3.Distance(transform.position, virus.transform.position) <= range)
                {
                    currentTarget = virus;
                    targetPos = currentTarget.transform;
                    break;
                }
            }
        }

       

    }

    void Shoot()
    {
        Debug.Log("Shoot");

        GameObject bulletGO = (GameObject)Instantiate(bulletPrefs, firePoint.position, firePoint.rotation);
        Bullet bulletInstance = bulletGO.GetComponent<Bullet>();
        
        if (burstEffect != null)
        {
            burstEffect.Stop();
            burstEffect.Clear();
            burstEffect.Play();
        }

        if (bulletInstance != null)
        {
            bulletInstance.Seek(targetPos);
        }
    }

}
