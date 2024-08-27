using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject ammo;
    public float fireRate = 0.5f;
    private bool isFiring = false;
    private float nextFireTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        ammo = Resources.Load<GameObject>("Ammo/Laser");
    }




    void Update()
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            if (Time.time >= nextFireTime)
            {
                StartCoroutine(FireContinuously());
            }
        }
        else
        {
            isFiring = false;
        }
    }

    private IEnumerator FireContinuously()
    {
        isFiring = true;
        while (isFiring && Time.time >= nextFireTime)
        {
            Fire();
            nextFireTime = Time.time + fireRate;
            yield return new WaitForSeconds(fireRate);
        }
    }



    private void Fire()
    {
        
        
        ammo.transform.position = this.transform.position;
        ammo.transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles);

        Instantiate(ammo);
    }

    public void ChangeAmmo(string ammoName)
    {
        ammo = Resources.Load<GameObject>($"Ammo/{ammoName}");
    }
}
