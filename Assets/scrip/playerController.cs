using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;



public class playerController : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    //public static int score;
   // public TextMeshProUGUI scoreText;
    //public static int health = 100;
   // public TextMeshProUGUI healthText;
//    public playerInfo info;
    public List<GameObject> enemies;
    // Start is called before the first frame update
    void Start()
    {
        // if(info == null){
        //     info = GameObject.Find("PlayerInfo").GetComponent<playerInfo>();
        // }
        // FindStats();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = enemies.Count-1;i > -1;i--)
        {
            if(enemies[i]== null)
            {
                enemies.RemoveAt(i);
            }
        }
        print("enemies:"+ enemies.Count);
        // scoreText.text = "Score:" + info.score.ToString();
        // healthText.text = "Health: " + info.health.ToString();

        if(Input.GetKeyDown("space"))
        {
            print("shoot");
            shootBullet();
        }

        // if(info.score >= 500){
        //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // }
        if(enemies.Count == 0){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        // // if(info.health <= 0){
        // //     Destroy(this.gameObject);
        // //     Time.timeScale = 0;
        // }
        
    }
    
    // public void DestroyEnemy()
    // {
    //     enemies.RemoveAt(0);
    // }

    // void FindStats()
    // {
    //     if(healthText == null)
    //     {
    //         healthText = GameObject.Find("health").GetComponent<TextMeshProUGUI>();
    //     }
    //     if(scoreText == null)
    //     {
    //         scoreText = GameObject.Find("score").GetComponent<TextMeshProUGUI>();
    //     }
    // }




    private void shootBullet()
    {
        GameObject clone = Instantiate(bulletPrefab) as GameObject;
        clone.transform.position = new Vector2(transform.position.x, transform.position.y);
    }

    // // public void ChangeScore(int value)
    // {
    //     info.score += value;
    //     enemies.RemoveAt(0);
    // }
    // public void ChangeHealth(int value)
    // {
    //     info.health -= value;
    // }
    void FixedUpdate()
    {
        //movement on x-axis
        float horizontalMove = Input.GetAxis("Horizontal") * speed;
        horizontalMove *= Time.deltaTime;
        transform.Translate(horizontalMove, 0, 0);

        //movement on y-axis 
        float verticalMovement = Input.GetAxis("Vertical") * speed;
        verticalMovement *= Time.deltaTime;
        transform.Translate(0, verticalMovement, 0);

        //set x and y boundaries
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -8.9f, 8.9f), 
        Mathf.Clamp(transform.position.y, -3.86f, 3.86f), transform.position.z);
    }
}
