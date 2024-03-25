using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using StarterAssets;

public class Player : MonoBehaviour
{
    //Properties
    int health;
    int score;

    //Refs
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text healthText;
    [SerializeField] GameObject winLosePanel;
    [SerializeField] TMP_Text winLoseText;

    public int Health
    { get { return health; } set { health = value; } }
    public int Score
    { get { return score; } set { score = value; } }

    public void SetScore(int addedScore)
    {
        score += addedScore;
        scoreText.text = "Score: " + score.ToString();
        if(score >= 100)
        {
            winLosePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            this.gameObject.GetComponent<FirstPersonController>().enabled = false;
            winLoseText.text = "You Win!";
        }
        
    }

    public void SetHealth(int minusHealth)
    {
        health -= minusHealth;
        healthText.text = "Health: " + health.ToString();
        if(health <= 0)
        {
            winLosePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            this.gameObject.GetComponent<FirstPersonController>().enabled = false;
            winLoseText.text = "You Died";
        }

    }

    private void Start()
    {
        scoreText.text = "Score: 0";
        healthText.text = "Health: 40";
        score = 0;
        health = 40;
        winLosePanel.SetActive(false);
        this.gameObject.GetComponent<FirstPersonController>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            MineInteract();
        }
    }

    void MineInteract()
    {
        Vector3 playerPos = transform.position;
        Vector3 forwardDir = transform.forward;

        Ray interactRay = new Ray(playerPos, forwardDir);
        RaycastHit hit;
        float rayLength = 10f;
        bool didHit = Physics.Raycast(interactRay, out hit, rayLength);
        if(didHit && hit.transform.CompareTag("Trap"))
        {
            Debug.Log("Hit :)");
            Destroy(hit.transform.gameObject);
        }


    }
}
