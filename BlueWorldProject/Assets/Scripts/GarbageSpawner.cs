using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageSpawner : MonoBehaviour
{
    // reference to prefabs
    public GameObject waterBottle;

    Vector2 whereToSpawn;
    float randomNumberForSpawnType;
    float nextSpawn = 1.0f;

    private GameManager gameManager;
    private DifficultyManager difficultyManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        difficultyManager = GameObject.FindObjectOfType<DifficultyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isAlive)
        {
            if (Time.time > nextSpawn)
            {
                whereToSpawn = GetWhereToSpawn();
                 // create a masked customer 
                 Instantiate(waterBottle, whereToSpawn, Quaternion.identity);
            }
        }
    }

    /*
     * This method works by spawning all Customers on a half circle then snapping
     * them to the edges of the screen. The center of the half circle is two thrids
     * up the screen (0, GameManager.screenBounds.y * 1 / 3). The radius of the
     * half circle is the distance from the center to the top corners.
     */
    private Vector2 GetWhereToSpawn()
    {

        float radius = GetRadius();

        // A random angle between 0 and PI rads
        float angle = Random.Range(0, Mathf.PI);

        float x = radius * Mathf.Cos(angle);
        float y = radius * Mathf.Sin(angle);

        // Convert to scene coordinates
        float screenXPos = x;
        float screenYPos = y + (GameManager.screenBounds.y * 1 / 3);

        // Snap x position to edge of screen
        screenXPos = Mathf.Min(screenXPos, GameManager.screenBounds.x);
        screenXPos = Mathf.Max(screenXPos, -GameManager.screenBounds.x);

        // Snap y position to edge of screen
        screenYPos = Mathf.Min(screenYPos, GameManager.screenBounds.y);
        screenYPos = Mathf.Max(screenYPos, -GameManager.screenBounds.y);

        return new Vector2(screenXPos, screenYPos);
    }

    /*
     * Simple helper method to get the radius.
     */
    private float GetRadius()
    {
        float x_max = GameManager.screenBounds.x;
        float y_max = GameManager.screenBounds.y * 2 / 3;

        return Mathf.Sqrt(x_max * x_max + y_max * y_max);
    }
}
