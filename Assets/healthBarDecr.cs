using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarWhenMaskGone : MonoBehaviour
{
    [Header("References")]
    public Slider slider;
    public ShrinkMaskToTarget shrink;
    public TextMeshProUGUI gameOverText; // Assign a UI Text in inspector

    [Header("Settings")]
    [Range(0f, 1f)]
    public float decreasePercent = 0.25f; // 25% decrease each time
    public float resetDelay = 1f;         // seconds before resetting mask

    private bool hasDecreased = false;
    private bool isGameOver = false;

    void Start()
    {
        if (gameOverText != null)
            gameOverText.gameObject.SetActive(false); // Hide Game Over at start
    }

    void Update()
    {
        if (shrink == null || slider == null || isGameOver)
            return;

        // When mask reaches target radius for the first time
        if (shrink.HasReachedTargetRadius && !hasDecreased)
        {
            hasDecreased = true;

            // Decrease by 25% of the max value
            float decreaseAmount = slider.maxValue * decreasePercent;
            slider.value = Mathf.Max(slider.value - decreaseAmount, 0f);

            Debug.Log("Slider decreased by 25%! Current value: " + slider.value);

            // Check if health reached 0
            if (slider.value <= 0f)
            {
                isGameOver = true;
                Debug.Log("Game Over!");

                // Show Game Over text
                if (gameOverText != null)
                    gameOverText.gameObject.SetActive(true);
            }

            // Start coroutine to reset mask after a short delay
            StartCoroutine(ResetMaskAfterDelay());
        }
    }

    private System.Collections.IEnumerator ResetMaskAfterDelay()
    {
        yield return new WaitForSeconds(resetDelay);
        if (!isGameOver) // only reset if the game is not over
        {
            shrink.ResetMask(); // make sure your ShrinkMaskToTarget script has this method
            hasDecreased = false; // allow the process to repeat
        }
    }
}
