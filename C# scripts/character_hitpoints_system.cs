using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class character_hitpoints_system : MonoBehaviour
{
    public int hitpoints = 3;
    public string gameOverPanelName = "game_over_text";
    private GameObject gameOverPanel;

    public string hitpointsThreeTextName = "hitpoints_3_text";
    private GameObject hitpointsThreeText;
    public string hitpointsTwoTextName = "hitpoints_2_text";
    private GameObject hitpointsTwoText;
    public string hitpointsOneTextName = "hitpoints_1_text";
    private GameObject hitpointsOneText;
    public string hitpointsZeroTextName = "hitpoints_0_text";
    private GameObject hitpointsZeroText;

    private bool isGameOver = false;

    void Start()
    {
        hitpointsThreeText = GameObject.Find(hitpointsThreeTextName);
        hitpointsTwoText = GameObject.Find(hitpointsTwoTextName);
        hitpointsOneText = GameObject.Find(hitpointsOneTextName);
        hitpointsZeroText = GameObject.Find(hitpointsZeroTextName);

        if (hitpointsThreeText != null) hitpointsThreeText.SetActive(true);
        if (hitpointsTwoText != null) hitpointsTwoText.SetActive(false);
        if (hitpointsOneText != null) hitpointsOneText.SetActive(false);
        if (hitpointsZeroText != null) hitpointsZeroText.SetActive(false);

        Vector2 screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
        Vector2 worldCenter = Camera.main.ScreenToWorldPoint(new Vector3(screenCenter.x, screenCenter.y, 10f));

        if (hitpointsThreeText != null) hitpointsThreeText.transform.position = worldCenter;
        if (hitpointsTwoText != null) hitpointsTwoText.transform.position = worldCenter;
        if (hitpointsOneText != null) hitpointsOneText.transform.position = worldCenter;
        if (hitpointsZeroText != null) hitpointsZeroText.transform.position = worldCenter;

        gameOverPanel = GameObject.Find(gameOverPanelName);

        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    void Update()
    {
        if (isGameOver) return;

        if (hitpoints == 2)
        {
            TwoHitpointsText();
        }

        if (hitpoints == 1)
        {
            OneHitpointsText();
        }

        if (hitpoints <= 0 && !isGameOver)
        {
            isGameOver = true;

            Debug.Log("You are killed!");
            ShowGameOver();
            ZeroHitpointsText();

            character_movement move = GetComponent<character_movement>();
            character_jump_movement jump = GetComponent<character_jump_movement>();

            if (move != null) move.ToggleMovement(false);
            if (jump != null) jump.ToggleJumpMovement(false);

            Time.timeScale = 1f; // safe reset in case it was changed somewhere

            // Load End Scene (your scene asset name is "end")
            SceneManager.LoadScene("end", LoadSceneMode.Single);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("enemy"))
        {
            TakeDamage();
        }
    }

    void TakeDamage()
    {
        hitpoints--;
        Debug.Log("You took damage!");
    }

    void ShowGameOver()
    {
        if (gameOverPanel != null)
        {
            Vector2 screenCenter = new Vector2(Screen.width * 0.5f, Screen.height * 0.5f);
            Vector2 worldCenter = Camera.main.ScreenToWorldPoint(new Vector3(screenCenter.x, screenCenter.y, 10f));

            gameOverPanel.transform.position = worldCenter;
            gameOverPanel.SetActive(true);
        }
        else
        {
            Debug.LogError("Game Over panel not found. Check gameOverPanelName.");
        }
    }

    void TwoHitpointsText()
    {
        if (hitpointsThreeText != null) hitpointsThreeText.SetActive(false);
        if (hitpointsTwoText != null) hitpointsTwoText.SetActive(true);
    }

    void OneHitpointsText()
    {
        if (hitpointsTwoText != null) hitpointsTwoText.SetActive(false);
        if (hitpointsOneText != null) hitpointsOneText.SetActive(true);
    }

    void ZeroHitpointsText()
    {
        if (hitpointsOneText != null) hitpointsOneText.SetActive(false);
        if (hitpointsZeroText != null) hitpointsZeroText.SetActive(true);
    }
}
