using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    private float objectWidth;
    public float speed = 8.0f;
    private GameManager gameManager;
    private int state;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        objectWidth = transform.localScale.x / 2;
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!gameManager.isAlive)
        //    return;

        state = 0;

        if (Input.touchCount > 0)
        {
            int i = 0;
            while (i < Input.touchCount)
            {
                Touch touch = Input.GetTouch(i);
                Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                if (touchPosition.x < 0 && touchPosition.x > -GameManager.screenBounds.x / 2)
                {
                    transform.Translate(Vector3.right * Time.deltaTime * speed);
                    state = 1;
                }
                else if (touchPosition.x < -GameManager.screenBounds.x / 2)
                {
                    transform.Translate(Vector3.left * Time.deltaTime * speed);
                    state = -1;
                }
                i++;
            }
        }

        animator.SetInteger("State", state);

        // Range check
        if (transform.position.x - objectWidth < -GameManager.screenBounds.x)
        {
            transform.position = new Vector3(-GameManager.screenBounds.x + objectWidth, transform.position.y, transform.position.z);
        }
        if (transform.position.x + objectWidth > GameManager.screenBounds.x)
        {
            transform.position = new Vector3(GameManager.screenBounds.x - objectWidth, transform.position.y, transform.position.z);
        }

    }
}
