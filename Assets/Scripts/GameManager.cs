using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;
    
    public TextMeshProUGUI scoreText;
    public GameObject tapToStart;
    public int score = 0;
    bool gameStarted = false;

    void Update()
    {
        if (Input.GetMouseButton(0) && !gameStarted)
        {
            tapToStart.SetActive(false);
            StartSpawning();
            gameStarted = true;
        }
    }

    void StartSpawning()
    {
        InvokeRepeating("SpawnBlocks",0.5f,spawnRate);
    }
    void SpawnBlocks()
    {
        Vector3 spawnPos = spawnPoint.position;
        spawnPos.x = Random.Range(-maxX, maxX);
        Instantiate(block, spawnPos, Quaternion.identity);
        score++;

        scoreText.text = score.ToString();
        
    }
}
