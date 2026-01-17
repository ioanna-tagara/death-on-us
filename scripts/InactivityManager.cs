using UnityEngine;
using UnityEngine.UI;

public class InactivityManager : MonoBehaviour
{
    public GameObject inactivityMessage; // The UI panel for inactivity warning
    public GameObject healthBar; // The UI health bar
    public float inactivityTime = 10f; // Time before showing inactivity message

    private float lastInputTime;
    private bool isPaused = false;

    void Start()
    {
        lastInputTime = Time.time;
        inactivityMessage.SetActive(false); // Hide inactivity message at start
        healthBar.SetActive(true); // Ensure health bar is visible at start
    }

    void Update()
    {
        // Detect player activity
        if (Input.anyKeyDown) // Detects only fresh key presses

        {
            lastInputTime = Time.time;
            inactivityMessage.SetActive(false);
            healthBar.SetActive(true);
            Debug.Log("Player is active. Resetting timer.");
        }

        // Show message if inactive
        if (Time.time - lastInputTime > inactivityTime)
        {
            inactivityMessage.SetActive(true);
            healthBar.SetActive(false);
            Debug.Log("Player is inactive. Showing message.");
        }

        // Check for Escape key to pause/unpause
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        if (!isPaused) // If not paused, pause the game
        {
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        else // If paused, resume the game
        {
            Time.timeScale = 1;
            Cursor.visible = false;
        }
        isPaused = !isPaused; // Toggle the pause state
    }
}
