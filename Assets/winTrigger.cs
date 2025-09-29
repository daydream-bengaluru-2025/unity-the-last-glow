using UnityEngine;
using UnityEngine.UI; // Use this if you have legacy UI Text
using TMPro; // Uncomment this if using TextMeshPro

public class DoorTrigger : MonoBehaviour
{
    // public Text youWinText; // Assign your "You Win" UI Text here
    public TextMeshProUGUI youWinText; // Uncomment if using TextMeshPro

    private bool hasWon = false;

    void Start()
    {
        if (youWinText != null)
            youWinText.gameObject.SetActive(false); // hide at start
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("You Win!");
        Debug.Log(other.tag);
        // Check if the player entered
        if (!hasWon && other.CompareTag("Player"))
        {
            hasWon = true;

            if (youWinText != null)
                youWinText.gameObject.SetActive(true); // show the UI text

            Time.timeScale = 0f;
        }
    }
}
