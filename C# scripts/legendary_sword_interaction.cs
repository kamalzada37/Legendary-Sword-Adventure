using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class legendary_sword_interaction : MonoBehaviour
{
    public string interactButtonName = "talk_text";
    public float interactionRange = 1f;

    // NEW: End sound
    public AudioClip endSfx;

    private AudioSource audioSource;
    private GameObject interactButton;

    private GameObject dialogue_one;
    private GameObject dialogue_two;
    private GameObject dialogue_three;

    private bool endingStarted = false;

    void Start()
    {
        dialogue_one = GameObject.Find("congrats_game_over_text");
        dialogue_two = GameObject.Find("legendary_sword_text");
        dialogue_three = GameObject.Find("thanks_for_playing_text");

        if (dialogue_one != null) dialogue_one.SetActive(false);
        if (dialogue_two != null) dialogue_two.SetActive(false);
        if (dialogue_three != null) dialogue_three.SetActive(false);

        interactButton = GameObject.Find(interactButtonName);
        if (interactButton == null)
        {
            Debug.LogError("Interact button not found. Check interactButtonName.");
        }
        else
        {
            interactButton.SetActive(false);
        }

        // AudioSource (add automatically if missing)
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.spatialBlend = 0f; // 2D
        }
    }

    void Update()
    {
        CheckPlayerDistance();
    }

    void CheckPlayerDistance()
    {
        if (endingStarted) return;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= interactionRange)
        {
            ShowInteractButton();

            if (Input.GetKeyDown(KeyCode.I))
            {
                character_movement characterMovement = player.GetComponent<character_movement>();
                character_jump_movement characterJumpMovement = player.GetComponent<character_jump_movement>();

                if (characterMovement != null) characterMovement.ToggleMovement(false);
                if (characterJumpMovement != null) characterJumpMovement.ToggleJumpMovement(false);

                if (!dialogue_one.activeSelf && !dialogue_two.activeSelf && !dialogue_three.activeSelf)
                {
                    StartDialogue();
                }
                else if (dialogue_one.activeSelf && !dialogue_two.activeSelf && !dialogue_three.activeSelf)
                {
                    ContinueDialogue();
                }
                else if (dialogue_one.activeSelf && dialogue_two.activeSelf && !dialogue_three.activeSelf)
                {
                    EndDialogue();

                    // play end sound + load end scene once
                    if (!endingStarted)
                    {
                        endingStarted = true;

                        if (endSfx != null && audioSource != null)
                            audioSource.PlayOneShot(endSfx);

                        StartCoroutine(LoadEndSceneAfterDelay(2f));
                    }
                }
            }
        }
        else
        {
            HideInteractButton();
        }
    }

    IEnumerator LoadEndSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Time.timeScale = 1f;
        SceneManager.LoadScene("end", LoadSceneMode.Single);
    }

    void ShowInteractButton()
    {
        if (interactButton != null) interactButton.SetActive(true);
    }

    void HideInteractButton()
    {
        if (interactButton != null) interactButton.SetActive(false);
    }

    void StartDialogue()
    {
        if (dialogue_one != null) dialogue_one.SetActive(true);
    }

    void ContinueDialogue()
    {
        if (dialogue_two != null) dialogue_two.SetActive(true);
    }

    void EndDialogue()
    {
        if (dialogue_three != null) dialogue_three.SetActive(true);
    }
}
