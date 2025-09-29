using UnityEngine;
using UnityEngine.UI;

public class DecreasingBar : MonoBehaviour
{
    public Image barFill;          // Assign in Inspector
    public float duration = 10f;   // Seconds to empty

    private float timer;

    void Start()
    {
        timer = duration;
    }

    void Update()
    {
        // Decrease timer
        timer -= Time.deltaTime;

        // Clamp to 0 so it doesn’t go negative
        float percent = Mathf.Clamp01(timer / duration);

        // Update the fill
        barFill.fillAmount = percent;
    }
}
