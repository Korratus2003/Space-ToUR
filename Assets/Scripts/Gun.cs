using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject ammo;
    public void Fire()
    {
        Instantiate(ammo, transform.position, transform.rotation);
    }
}
