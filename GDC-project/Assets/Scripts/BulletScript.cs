using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float lifeTime = 3;//seconds
    public float bulletSpeed;
    Rigidbody rb;
    float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
        Physics.IgnoreLayerCollision(6, 7, true);
        Physics.IgnoreLayerCollision(7, 7, true);
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        bool isExpired = spawnTime + lifeTime <= Time.time;
        if (isExpired)
        {
            Destroy(gameObject);
        }
    }
}
