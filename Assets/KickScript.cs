using UnityEngine;

public class KickScript : MonoBehaviour
{
    Vector3 ballForce = Vector3.zero;
    bool resetPosition = false;
    public GameObject destroyEffect;
    public Animator animator;

    public float smallShot = 1f;
    public float bigShot = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Transform tr = GetComponent<Transform>();
        // animator = GetComponent<Animator>();
        tr.position = Vector3.zero;

        // LineRenderer
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal"), y = Input.GetAxis("Vertical");

        if (Input.GetButton("Jump"))
        {
            if (ballForce.z > -400)
                ballForce.z = -400;
            ballForce.z -= 1600 * Time.deltaTime;
            Debug.Log(ballForce);
        }

        if (Input.GetButtonUp("Jump"))
        {
            if (ballForce.z > 1200)
                ballForce.z = 1200;

            ballForce.x = x * ballForce.z;
            ballForce.y = -y * ballForce.z;

            if (ballForce.z < -800)
            {
                animator.SetTrigger("releaseBigShot");
                Invoke("releaseShot", bigShot);
            }
            else
            {
                animator.SetTrigger("releaseSmallShot");
                Invoke("releaseShot", smallShot);
            }
        }

        if (resetPosition)
        {
            resetPosition = false;
            Invoke("reset", 1);
        }

        // Transform tr = GetComponent<Transform>();
        // if (tr.position.y < -10)
        // Destroy(this);
        // resetPosition = true;
    }

    void releaseShot ()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(ballForce);
        ballForce = Vector3.zero;
        Invoke("reset", 2);
    }

    void OnCollisionEnter (Collision c)
    {
        if (c.collider.tag == "goal")
        {
            Debug.Log("You Won, Mothafucka!");
            FindObjectOfType<AudioManager>().Play("cheer", .7f);
            animator.SetTrigger("cheer");
            Destroy (Instantiate(destroyEffect, c.gameObject.transform.position, c.gameObject.transform.rotation) as GameObject, 2);
            Destroy(c.gameObject);
        }

        Transform tr = GetComponent<Transform>();
        // if (tr.position.z < -4)
            // Destroy(this, 1);
        // resetPosition = true;
    }

    void reset ()
    {
        Transform tr = GetComponent<Transform>();
        Rigidbody rb = GetComponent<Rigidbody>();
        
        tr.position = Vector3.zero;
        rb.velocity = Vector3.zero;
        ballForce = Vector3.zero;
    }
}
