using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(0, 1, -4);
        Debug.Log("Jestem");
    }

    // Update is called once per frame
    void Update()
    {
        //blokada ¿eby nie wylecia³ za kamere
        if (this.transform.position.x < -8f) this.transform.position = new Vector3(-8f, this.transform.position.y, this.transform.position.z);
        if (this.transform.position.x > 8f) this.transform.position = new Vector3(8f, this.transform.position.y, this.transform.position.z);
        if (this.transform.position.z < -4.3f) this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -4.3f);
        if (this.transform.position.z > 4.3f) this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 4.3f);

    }

    void FixedUpdate()
    {
        // ruch w ka¿d¹ strone

    }
}
