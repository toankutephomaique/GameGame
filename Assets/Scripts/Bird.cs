using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    private Rigidbody2D rigibody;
    public float jumpForce;
    private bool levelStart;
    public GameObject gameController;
    public GameObject message;
    private int score;
    public Text scoreText;

    private void Awake()
    {
        rigibody = this.gameObject.GetComponent<Rigidbody2D>();
        levelStart = false;
        rigibody.gravityScale = 0;
        score = 0;
        scoreText.text = score.ToString();
        message.GetComponent<SpriteRenderer>().enabled = true;
    }


    void Update()
    {
        //kiem tra xem phim space co duoc bam khong
        if (Input.GetKeyDown(KeyCode.Space))
        {
                SoundController.instance.PlayThisSound("wing", 0.5f);
                if (levelStart == false)
                {
                    levelStart = true;
                    rigibody.gravityScale = 10;
                    gameController.GetComponent<PipeGenerator>().enableGenratePipe = true;
                    message.GetComponent<SpriteRenderer>().enabled = false;
                }           
                BirdMoveUp();
        }
    }
    private void BirdMoveUp() //lam chim bay len mot khoang
    {
        rigibody.velocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SoundController.instance.PlayThisSound("hit", 0.5f);
        ReloadScene();
        score = 0;
        scoreText.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundController.instance.PlayThisSound("point", 0.5f);
        score += 1;
        scoreText.text = score.ToString();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("GamePlay");
    }
}
