using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleControllerPC : MonoBehaviour
{
    private Vector2 screenBounds;
    private float objectWidth;
    private float horizontalInput;
    public float speed = 8.0f;
    private GameManager gameManager;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.localScale.x / 2;
        gameManager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        //if (!gameManager.isAlive)
        //    return;
        //horizontalInput = Input.GetAxis("Horizontal");
       // animator.SetFloat("Horizontal", horizontalInput);
        // Move left and right
        //transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        // Range check
        //if (transform.position.x - objectWidth < -screenBounds.x)
        //{
        //    transform.position = new Vector3(-screenBounds.x + objectWidth, transform.position.y, transform.position.z);
        //}
        //if (transform.position.x + objectWidth > screenBounds.x)
        //{
        //    transform.position = new Vector3(screenBounds.x - objectWidth, transform.position.y, transform.position.z);
        //}

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            position.x--;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            position.x++;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Vector3 position = this.transform.position;
            position.y++;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            position.y--;
            this.transform.position = position;
        }

    }
}
