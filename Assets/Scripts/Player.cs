using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    public GameObject gameOverPng;
    private GameManager gameManager;
    //private TextMeshProUGUI scText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Debug.Log("entering in loop");
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (touchPos.x < 0)
            {
                rb.AddForce(Vector2.left * moveSpeed);
                //Debug.Log("entering in loop n left");
            }
            else
            {
                rb.AddForce(Vector2.right * moveSpeed);
               // Debug.Log("entering in loop n right");
            }
        }
        else
        {
            rb.velocity = Vector2.zero;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("block"))
        {
            gameOverPng.SetActive(true);
            gameManager.scoreText.gameObject.SetActive(false);
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
