using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        Bird bird = other.collider.GetComponent<Bird>();
        if (bird != null){
            Destroy(gameObject);
        }

        Enemies enemies = other.collider.GetComponent<Enemies>();
        if (enemies != null){
            return;
        }

        if (other.contacts[0].normal.y < -0.5){
            Destroy(gameObject);
        }
    }
}
