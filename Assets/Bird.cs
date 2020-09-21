using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 initialPosition;
    [SerializeField] private float launchPower = 250;
    private void Awake(){
        initialPosition = transform.position;
    }

    private void Update(){

        if (transform.position.y > 10 || transform.position.y < -10 || transform.position.x > 10 || transform.position.x < -10){
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
        }

        /*
        if (transform.position.y > 10) {
            SceneManager.LoadScene(sceneName);
        }

        if (transform.position.x < -10){
            SceneManager.LoadScene(sceneName);
        }

        if (transform.position.x > 10){
            SceneManager.LoadScene(sceneName);
        }*/

    }

    private void OnMouseDown() {
       GetComponent<SpriteRenderer>().color = Color.red;
    }

    private void OnMouseUp(){
        GetComponent<SpriteRenderer>().color = Color.white;

        Vector2 directionToInitialDirection = initialPosition - transform.position;
        GetComponent<Rigidbody2D>().AddForce(directionToInitialDirection * launchPower);
        GetComponent<Rigidbody2D>().gravityScale = 1;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(newPosition.x,newPosition.y);
    }
}
