using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankScript : MonoBehaviour
{
    public float speed = 1;
    public float turnSpeed = 1;
    public float jumpForce = 1;
    public GameObject bullet;
    public float shotCooldownTime = 3;
    public GameObject tankModel;
    public AudioClip shootSoundClip;
    public AudioClip jumpSoundClip;


    float lastShotTime;
    bool isGrounded;
    Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        lastShotTime = Time.time - shotCooldownTime;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveHandler();

        ShootHandler();
    }

    void ShootHandler()
    {
        bool wantsToShoot = Input.GetButtonDown("Fire1");

        bool canShoot = lastShotTime + shotCooldownTime <= Time.time;

        if (wantsToShoot && canShoot)
        {
            Instantiate(bullet, transform.position+Vector3.up*0.2f,transform.rotation);
            lastShotTime = Time.time;

            Animator tankAnimator = tankModel.GetComponent<Animator>();
            tankAnimator.SetTrigger("isShooting");

            AudioSource soundSource = gameObject.GetComponent<AudioSource>();
            soundSource.PlayOneShot(shootSoundClip);
        }


    }

    void MoveHandler()
    {
        float moveInput = Input.GetAxis("Vertical");//Variable for move input
        float turnInput = Input.GetAxis("Horizontal");
        bool isMoving = moveInput != 0;
        bool isTurning = turnInput != 0;
        if (isMoving || isTurning)
        {
            Animator tankAnimator = tankModel.GetComponent<Animator>();
            tankAnimator.SetBool("isDriving", true);
        } else
        {
            Animator tankAnimator = tankModel.GetComponent<Animator>();
            tankAnimator.SetBool("isDriving", false);
        }

        float moveSpeed = speed * moveInput;

        Vector3 newVelocity = transform.forward * moveSpeed;
        newVelocity.y = rb.velocity.y;

        bool wantsToJump = Input.GetButtonDown("Jump");

        if (wantsToJump && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isGrounded = false;

            AudioSource soundSource = gameObject.GetComponent<AudioSource>();
            soundSource.PlayOneShot(jumpSoundClip);
        }

        gameObject.GetComponent<Transform>().Rotate(Vector3.up * turnInput * turnSpeed); // Rotates the tank around Y-axis

        rb.velocity = newVelocity; //Sets velocity of the tank to movespeed in the forward direction
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
