using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    public float jumpForce;

    [SerializeField]
    float speed;

    bool isGround = true;
    bool rotate90 = false;
    Rigidbody rigidbody;
    Vector3 direction = new Vector3(0, 0, 1f);

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0f, 0f, speed) * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            isGround = false;
            rigidbody.velocity = new Vector3(0, jumpForce, 0);
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            rotate90 = !rotate90;
            if (rotate90)
                transform.eulerAngles = new Vector3(0, 90, 0);
            else
                transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }

        if(collision.gameObject.tag == "obstacle")
        {
            Debug.Log("Dead");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ground")
        {
            Destroy(other.gameObject);
        }
    }

}
