using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    //Properties
    int health;
    int score;

    //Refs
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text healthText;

    public int Health
    { get { return health; } set { health = value; } }
    public int Score
    { get { return score; } set { score = value; } }

    public void SetScore(int addedScore)
    {
        score += addedScore;
        scoreText.text = "Score: " + score.ToString();
        
    }

    public void SetHealth(int minusHealth)
    {
        health -= minusHealth;
        healthText.text = "Health: " + health.ToString();

    }

    private void Start()
    {
        scoreText.text = "Score: 0";
        healthText.text = "Health: 40";
        score = 0;
        health = 40;
    }

    private void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.E))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity) && hit.gameObject.tag == "Trap")
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            }

        }
    }
}
