using UnityEngine;

public class ShrinkMaskToTarget : MonoBehaviour
{
    public float shrinkSpeed = 1f;
    public Transform target;
    public float targetRadius = 7f;

    private float startRadius; // remember original size
    public bool HasReachedTargetRadius { get; private set; } = false;

    void Start()
    {
        // Store initial scale
        startRadius = transform.localScale.x;
    }

    void Update()
    {
        if (target != null)
            transform.position = target.position;

        float newScale = Mathf.MoveTowards(transform.localScale.x, targetRadius, shrinkSpeed * Time.deltaTime);
        transform.localScale = new Vector3(newScale, newScale, 1f);

        HasReachedTargetRadius = Mathf.Approximately(transform.localScale.x, targetRadius);
    }

    public void ResetMask()
    {
        transform.localScale = new Vector3(startRadius, startRadius, 1f);
        HasReachedTargetRadius = false;
    }
}
