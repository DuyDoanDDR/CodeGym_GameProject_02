using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Rendering;

public class Defender_Controller : MonoBehaviour
{           
    private Transform targetPos;

    private float range;
    private GameObject currentTarget;
    private string targetTag;
    private float rotateSpeed;
    

    private float fireRate;
    private float fireCountdown = 0f;
    private GameObject bulletPrefs;
    private float slowAmount = 0.3f;

    public Transform firePoint;

    public ParticleSystem burstEffect;
    public LineRenderer laserBeam;

    [Header ("Data")]
    public VirusData virusData;
    public DefenderData defenderData;

    public LayerMask virusLayer;

    private void Awake()
    {
      
        range = defenderData.range;
        fireRate = defenderData.fireRate;
        fireCountdown = defenderData.fireCountdown;
        rotateSpeed = defenderData.rotateSpeed;
        bulletPrefs = defenderData.BulletPrefab;
        targetTag = defenderData.targetTag;
       

    }
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
            if (Physics.Raycast(transform.position, targetDir, out RaycastHit hit, range, virusLayer))
            {
                if (hit.collider.gameObject == currentTarget)
                {
                    Quaternion defenderRotate = Quaternion.LookRotation(targetDir);
                    transform.rotation = Quaternion.Slerp(transform.rotation, defenderRotate, rotateSpeed * Time.deltaTime);
                    if (defenderData.BurstType == BurstType.BulletType)
                    {
                        if (fireCountdown <= 0f)
                        {

                            Shoot();
                            fireCountdown = 1f / fireRate;
                        }
                        fireCountdown -= Time.deltaTime;
                    }
                    else if (defenderData.BurstType == BurstType.BeamType)
                    {

                        Laser();
                    }
                }
                else
                {
                    currentTarget = null;
                }
            }

            //    if (distanceToVirus <= range)
            //{
               
               
            //}
           
        }
        else
        {
            if (defenderData.BurstType == BurstType.BeamType)
            {
                if (laserBeam.enabled)
                {
                    laserBeam.enabled = false;
                }

            }
            
            if (VirusManager.instance != null && VirusManager.instance.allViruses != null)

            {
                foreach (GameObject virus in VirusManager.instance.allViruses)
                {
                    if (virus == null)
                    {
                        continue;
                    }
                    Vector3 targetDir = (virus.transform.position - transform.position).normalized;
                    if (Physics.Raycast(transform.position, targetDir, out RaycastHit hit, range, virusLayer))
                    {
                        if (hit.collider.gameObject == virus)
                        {
                            currentTarget = virus;
                            targetPos = currentTarget.transform;
                            break;
                        }
                        
                    }
                    //if (Vector3.Distance(transform.position, virus.transform.position) <= range)
                    //{
                        
                    //}
                }
            }
            
        }       
    }

    void Laser()
    {
        currentTarget.GetComponent<Virus>().TakeDamage(defenderData.damage * Time.deltaTime);
        currentTarget.GetComponent<Virus>().Slow(slowAmount);
        
        if (!laserBeam.enabled)
        {
            laserBeam.enabled = true;
        }
        BurstEffect();
        laserBeam.SetPosition(0, firePoint.position);
        laserBeam.SetPosition(1, targetPos.position);
    }
    void Shoot()
    {
        Debug.Log("Shoot");

        GameObject bulletGO = (GameObject)Instantiate(bulletPrefs, firePoint.position, firePoint.rotation);
        Bullet bulletInstance = bulletGO.GetComponent<Bullet>();

        BurstEffect();

        if (bulletInstance != null)
        {
            bulletInstance.Seek(targetPos);
        }
    }

    void BurstEffect()
    {
        if (burstEffect != null)
        {
            burstEffect.Stop();
            burstEffect.Clear();
            burstEffect.Play();
        }
    }

}
