using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    public float initialForce;

    public Transform playerTransform;

    public AudioSource impactSound;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * initialForce, ForceMode.Impulse);
    }

    protected void PlayImpactSound() {
        impactSound.Play();
        impactSound.transform.parent = null;
        Destroy(impactSound.gameObject, 5);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.collider.tag == "Teleport") {
            playerTransform.position = collision.GetContact(0).point;
        }

        PlayImpactSound();

        // Alternative pour (collision.collider.tag != "Bounce")
        if (!collision.collider.CompareTag("Bounce"))
            Destroy(gameObject);
        
    }

}
