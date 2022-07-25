using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    GameObject player;
    GameObject pointHandler;

    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        pointHandler = GameObject.FindWithTag("PointHandler");
    }

    // Update is called once per frame
    void Update()
    {
        moveHandler();
    }

    private void OnDestroy()
    {
        pointHandler.GetComponent<PointHandlerScript>().RegisterKill();
    }

    void moveHandler()
    {
        Vector3 enemyPos = transform.position;
        Vector3 playerPos = player.transform.position;
        Vector3 moveDirection = (playerPos - enemyPos).normalized;

        gameObject.GetComponent<Rigidbody>().velocity = moveDirection * moveSpeed;


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject tankPlayer = collision.gameObject;
            TankScript tankComponent = tankPlayer.GetComponent<TankScript>();
            tankComponent.Attack(1);
        }
    }
}
