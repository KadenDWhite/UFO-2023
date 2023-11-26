using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public TMP_Text scoreText;
    public TMP_Text winText;

    Rigidbody2D rb2d;
    float v = 0.0f;
    float h = 0.0f;
    int score = 0;
    int minWinScore = 6;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(h, v);
        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.tag == "GoldPickup")
        if (other.gameObject.CompareTag("GoldPickup"))
        {
            other.gameObject.SetActive(false);
            score++; // score = score + 1;

            UpdateScoreText();

            if (winText != null && score >= minWinScore)
            {
                winText.text = "Gotta Eat Em All!";
            }
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score : " + score.ToString();
        }
    }
}
