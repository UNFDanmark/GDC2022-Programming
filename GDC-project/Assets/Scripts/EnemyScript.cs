using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 enemyPos = transform.position;
        Vector3 playerPos = player.transform.position;
        Vector3 moveDirection = playerPos - enemyPos;

        gameObject.GetComponent<Rigidbody>().velocity = moveDirection;
    }
}
