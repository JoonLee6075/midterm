using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float gold;
    public Text text;
    public Text text2;
    public static int goal = 10;
    public GameObject enemy;
    public Transform spawnPoint;
    public float spawnTimer = 10;
    public static int health = 1;
    public Sprite[] sprites;
    public Image healthSprite;
    public GameObject player;
    public GameObject gameEndText;
    public GameObject finalStage;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        //text.text = "TOTAL GOLD OBTAINED: " + gold.ToString();
        text2.text = "TOTAL MAP FRAGMENT NEEDED " + (goal.ToString());

        if(spawnTimer <= 0)
        {
            Spawn();
            spawnTimer = 10;
        }

        if(goal <= 0)
        {
            player.transform.position = finalStage.transform.position;
            goal = 3;
        }

        if(health <= 0)
        {
            healthSprite.sprite = sprites[1];
            GameOver();
            gameEndText.SetActive(true);
            Destroy(player);
            

        }

    }

    public void Spawn()
    {
        var offset = new Vector3(Random.RandomRange(-15, 15), Random.RandomRange(-15, 15), spawnPoint.transform.position.z);
        Instantiate(enemy, spawnPoint.transform.position + offset, spawnPoint.rotation);
    }

    public void GameOver()
    {
        Debug.Log("game is over");
    }
}
