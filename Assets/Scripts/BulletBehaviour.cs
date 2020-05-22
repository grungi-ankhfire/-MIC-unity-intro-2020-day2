using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    public float initialForce;

    public Transform playerTransform;


    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * initialForce, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Teleport") {
            playerTransform.position = collision.GetContact(0).point;
        }
    }

}
