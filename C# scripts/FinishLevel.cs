using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    private bool finished = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (finished) return;

        if (other.CompareTag("Player"))
        {
            finished = true;

            Debug.Log("Level Finished!");
            Time.timeScale = 1f;

            // Load your end scene (you said it's named "end")
            SceneManager.LoadScene("end", LoadSceneMode.Single);
        }
    }
}
