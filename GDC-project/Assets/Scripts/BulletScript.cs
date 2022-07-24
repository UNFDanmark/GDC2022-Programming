using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float lifeTime = 3;//seconds
    public float bulletSpeed;
    Rigidbody rb;
  //  Transform transform;
    float spawnTime;
    public float explosionForceMultiplier;

    public float explosionRadius;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = Time.time;
        Physics.IgnoreLayerCollision(6, 7, true);
        Physics.IgnoreLayerCollision(7, 7, true);
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * bulletSpeed);


  //      transform = gameObject.GetComponent<Transform>();
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


    private void OnCollisionEnter(Collision other)
    {
        Vector3 explosionOrigin = transform.position;
        Collider[] objectsHit = Physics.OverlapSphere(explosionOrigin, explosionRadius);

        foreach(Collider currentcollider in objectsHit)
        {
            Explosion(currentcollider);
        }
        
    }

    void Explosion(Collider other)
    {
        bool otherShouldExplode = other.gameObject.tag == "Exploding";
        print("Bool result: " + otherShouldExplode);

        if (otherShouldExplode)
        {
            Vector3 thisPos = transform.position;
            Vector3 otherPos = other.gameObject.GetComponent<Transform>().position;
            Vector3 direction = (otherPos - thisPos).normalized;

            other.gameObject.GetComponent<Rigidbody>().AddForce(direction * explosionForceMultiplier);
        }
    }
}
