using UnityEngine;
using System.Collections;

public class SpriteAlphaLerp : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer; // The sprite you want to modify
    [SerializeField] private float speed = 1f; // Speed of the lerp
    [SerializeField] private GameObject GameobjectToInactivate;
    private const float StartAlpha = 180f / 255f; // Starting alpha (180/255 = 0.71)
    private const float EndAlpha = 240f / 255f;  // Ending alpha (240/255 = 0.94)

    private void Start()
    {
        // Start the alpha transition
        StartCoroutine(LerpAlphaMultipleTimes(3));
    }

    private IEnumerator LerpAlphaMultipleTimes(int repeatCount)
    {
        for (int i = 0; i < repeatCount; i++) // Repeat the fade process 'repeatCount' times
        {
            // Fade in from StartAlpha to EndAlpha
            yield return StartCoroutine(LerpAlpha(StartAlpha, EndAlpha));
            // Fade out from EndAlpha to StartAlpha
            yield return StartCoroutine(LerpAlpha(EndAlpha, StartAlpha));
        }
        //gameobject inactivate task fire 
        if (GameobjectToInactivate != null)
        {
            // Deactivate the GameObject
            GameobjectToInactivate.SetActive(false);

            // Wait for 2 seconds
            yield return new WaitForSeconds(2f);

            // Reactivate the GameObject
            GameobjectToInactivate.SetActive(true);
        }
    }

    private IEnumerator LerpAlpha(float startAlpha, float endAlpha)
    {
        float elapsedTime = 0f;
        Color currentColor = spriteRenderer.color;

        while (elapsedTime < 1f / speed)
        {
            elapsedTime += Time.deltaTime;
            // Interpolate alpha value
            float alpha = Mathf.Lerp(startAlpha, endAlpha, elapsedTime * speed);
            currentColor.a = alpha; // Set the alpha value
            spriteRenderer.color = currentColor; // Apply the new color
            yield return null; // Wait until the next frame
        }

        // Ensure the final alpha value is precisely set
        currentColor.a = endAlpha;
        spriteRenderer.color = currentColor;
    }
}
