using UnityEngine;
using System.Collections;

/*
    GameJam 2024-2025 - Team 3
    ButtonScript.cs
    Rougefort Luca B3JV1
*/

public class Ballon : MonoBehaviour
{
    public GameObject childObject; // L'objet 3D enfant à scaler
    public float maxScale = 3f; // Taille maximale
    public float inflateTime = 10f; // Temps pour atteindre la taille maximale
    public float deflateMultiplier = 2f; // Multiplicateur de vitesse de dégonflage
    public float targetHeight = 20f; // Hauteur cible augmentée pour un arc plus haut
    public float horizontalForce = 4f; // Force horizontale augmentée pour un déplacement plus rapide
    public float fallSpeed = 2f; // Vitesse de chute
    public float arcDuration = 3f; // Durée réduite pour compléter l'arc de cercle plus rapidement

    private float currentScaleTime = 0f;
    public float ScaleTime
    {
        get { return currentScaleTime; }
        private set { currentScaleTime = Mathf.Max(0f, value); }
    }

    private bool isInflating = false;
    private bool wasInflating = false;
    private bool isTouchingGround = false;
    private bool isFlying = false;
    private bool hasReachedMaxHeight = false;
    private Coroutine flyCoroutine;

    void Update()
    {
        if (isTouchingGround && Input.GetKey(KeyCode.Space))
        {
            Inflate();
        }
        else if (!Input.GetKey(KeyCode.Space))
        {
            Deflate();
            if (wasInflating && !hasReachedMaxHeight && !isFlying)
            {
                Fly();
            }
        }
        UpdateScale();
        wasInflating = isInflating;
    }

    private void Inflate()
    {
        isInflating = true;
        ScaleTime += Time.deltaTime;
    }

    private void Deflate()
    {
        isInflating = false;
        ScaleTime -= Time.deltaTime * deflateMultiplier;
    }

    private void Fly()
    {
        if (!isFlying)
        {
            isFlying = true;
            flyCoroutine = StartCoroutine(FlyCoroutine());
        }
    }

    private IEnumerator FlyCoroutine()
    {
        float startTime = Time.time;
        Vector3 startPosition = transform.position;

        // Calcule le pourcentage de gonflement
        float inflatePercentage = Mathf.Clamp01(ScaleTime / inflateTime);
        float adjustedTargetHeight = targetHeight * inflatePercentage;
        float adjustedHorizontalForce = horizontalForce * inflatePercentage;
        float adjustedArcDuration = arcDuration * inflatePercentage;
        float adjustedFallSpeed = fallSpeed * (1 - inflatePercentage); // Plus le ballon est gonflé, plus la vitesse de chute est lente

        while (Time.time - startTime < adjustedArcDuration)
        {
            float t = (Time.time - startTime) / adjustedArcDuration;
            float height = Mathf.Sin(Mathf.PI * t) * adjustedTargetHeight;
            float horizontal = t * adjustedHorizontalForce * adjustedArcDuration;
            transform.position = startPosition + new Vector3(horizontal, height, 0);
            yield return null;
        }

        hasReachedMaxHeight = true;
        while (true)
        {
            float t = (Time.time - startTime) / adjustedArcDuration;
            float height = Mathf.Sin(Mathf.PI * t) * adjustedTargetHeight - adjustedFallSpeed * (Time.time - startTime - adjustedArcDuration);
            float horizontal = (Time.time - startTime) * adjustedHorizontalForce;
            transform.position = startPosition + new Vector3(horizontal, height, 0);

            yield return null;
        }
    }

    private void UpdateScale()
    {
        ScaleTime = Mathf.Clamp(ScaleTime, 0f, inflateTime);
        float scaleProgress = Mathf.Clamp01(ScaleTime / inflateTime);
        float newScale = Mathf.Lerp(0f, maxScale, scaleProgress);
        childObject.transform.localScale = new Vector3(newScale, newScale, newScale);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = true;
            hasReachedMaxHeight = false;
            StopFlying();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = false;
        }
    }

    private void StopFlying()
    {
        if (flyCoroutine != null)
        {
            StopCoroutine(flyCoroutine);
            flyCoroutine = null;
        }
        isFlying = false;
    }
}

