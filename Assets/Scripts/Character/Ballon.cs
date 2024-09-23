// Rougefort Luca B3JV1 Prog
// Ballon.cs
// GameJam rentrée 2024-2025

using UnityEngine;
using System.Collections;

public class Ballon : MonoBehaviour
{
    public GameObject childObject; // L'objet 3D enfant à scaler
    public float maxScale; // Taille maximale du ballon
    public float inflateTime; // Temps pour atteindre la taille maximale
    public float slowDeflateMultiplier; // Multiplicateur de vitesse de dégonflage sans maintenir
    public float fastDeflateMultiplier; // Multiplicateur de vitesse de dégonflage en maintenant
    public float HauteurMax; // Hauteur cible pour un arc plus haut
    public float horizontalForce; // Force horizontale pour un déplacement plus rapide
    public float fallSpeedEnBallon; // Vitesse de chute
    public float emptyFallSpeed; // Vitesse de chute lorsque le ballon est vide
    public float arcDuration; // Durée pour compléter l'arc de cercle
    public float DelayBallon; // Temps de repos avant que le ballon commence à se dégonfler

    public KeyCode GonflerBallon = KeyCode.Space; // Touche pour gonfler
    public KeyCode GarderAir = KeyCode.B; // Touche pour dégonfler lentement
    public KeyCode Descendre = KeyCode.V; // Touche pour dégonfler rapidement

    private float currentScaleTime = 0f;
    public float ScaleTime
    {
        get { return currentScaleTime; }
        private set { currentScaleTime = Mathf.Max(0f, value); }
    }

    private bool isInflating = false;
    private bool wasInflating = false;
    private bool isTouchingGround = false;
    public bool isFlying = false;
    private bool hasReachedMaxHeight = false;
    private Coroutine flyCoroutine;
    public Coroutine fallCoroutine;
    private float lastInflateTime = 0f;

    //VFX
    [SerializeField] ParticleSystem _inflateVFX;
    [SerializeField] ParticleSystem _deflateVFX;
    [SerializeField] Animator _playerAnimator;
    [SerializeField] Animator _ballonAnimator;

    void Update()
    {
        HandleInput();
        UpdateScale();
        wasInflating = isInflating;
    }

    private void HandleInput()
    {
        if (isTouchingGround && Input.GetKey(GonflerBallon))
        {
            Inflate();
        }
        else
        {
            HandleDeflation();
            if (wasInflating && !hasReachedMaxHeight && !isFlying)
            {
                Fly();
            }
        }

        if (!isTouchingGround){
            HandleDeflation();
        }
    }



    private void HandleDeflation(){
        if (Time.time - lastInflateTime >= DelayBallon){
            Deflate(Input.GetKey(GarderAir) ? slowDeflateMultiplier : fastDeflateMultiplier);
        }else{
            if (_inflateVFX.isPlaying){
                _inflateVFX.Stop();
            }
        }
    }

    private void Inflate(){
        isInflating = true;
        ScaleTime += Time.deltaTime;
        lastInflateTime = Time.time;

        // Intégration des VFX
        _playerAnimator.SetBool("IsInflating", true);
        if (!_inflateVFX.isPlaying)
        {
            _inflateVFX.Play();
        }
    }

    private void Deflate(float deflateMultiplier)
    {
        isInflating = false;
        ScaleTime -= Time.deltaTime * deflateMultiplier;

        if (ScaleTime == 0)
        {
            StopFlying();
            if (fallCoroutine == null)
            {
                fallCoroutine = StartCoroutine(FallVertically());
            }
        }
        else if (Input.GetKey(GarderAir))
        {
            transform.position += Vector3.down * fallSpeedEnBallon * deflateMultiplier * Time.deltaTime;
        }
        // Intégration des VFX
        _playerAnimator.SetBool("IsInflating", false);
        _playerAnimator.SetBool("IsFloating", true);
        _inflateVFX.Stop();
        _deflateVFX.Play();
        // TODO: Ajouter des animations ou VFX pour le dégonflage
    }


    public IEnumerator FallVertically() // Rendre public
    {
        while (!isTouchingGround)
        {
            transform.position += Vector3.down * emptyFallSpeed * Time.deltaTime;

            // VFX
            _playerAnimator.SetBool("IsFalling", true);
            _playerAnimator.SetBool("IsFloating", false);

            yield return null;
        }
        fallCoroutine = null;
    }

    private void Fly()
    {
        if (!isFlying)
        {
            isFlying = true;
            flyCoroutine = StartCoroutine(FlyCoroutine());
        }

        // VFX
        _playerAnimator.SetBool("IsFloating", true);
        _ballonAnimator.SetBool("IsFloating", false);
    }

    private IEnumerator FlyCoroutine()
    {
        while (true)
        {
            yield return FlyArc(transform.position, ScaleTime);
            hasReachedMaxHeight = true;
            yield return new WaitForSeconds(DelayBallon);
            yield return CheckFall();
        }
    }

    private IEnumerator FlyArc(Vector3 startPosition, float remainingScaleTime)
    {
        float startTime = Time.time;
        float inflatePercentage = Mathf.Clamp01(remainingScaleTime / inflateTime);
        float adjustedTargetHeight = HauteurMax * inflatePercentage;
        float adjustedHorizontalForce = horizontalForce * inflatePercentage;
        float adjustedArcDuration = arcDuration * inflatePercentage;

        while (Time.time - startTime < adjustedArcDuration && ScaleTime > 0)
        {
            if (Input.GetKey(Descendre))
            {
                transform.position += Vector3.down * emptyFallSpeed * Time.deltaTime;
            }
            else
            {
                float t = (Time.time - startTime) / adjustedArcDuration;
                float height = Mathf.Sin(Mathf.PI * t) * adjustedTargetHeight;
                float horizontal = t * adjustedHorizontalForce * adjustedArcDuration;
                transform.position = startPosition + new Vector3(horizontal, height, 0);
            }
            yield return null;
        }
    }

    private IEnumerator CheckFall()
    {
        while (true)
        {
            if (ScaleTime == 0 && !isFlying)
            {
                yield break;
            }

            if (Input.GetKey(Descendre))
            {
                transform.position += Vector3.down * emptyFallSpeed * Time.deltaTime;
            }
            else if (Input.GetKeyUp(Descendre))
            {
                StopFlying();
                Fly();
            }
            yield return null;
        }
    }

    private void UpdateScale()
    {
        ScaleTime = Mathf.Clamp(ScaleTime, 0f, inflateTime);
        float scaleProgress = Mathf.Clamp01(ScaleTime / inflateTime);
        float newScale = Mathf.Lerp(0f, maxScale, scaleProgress);
        childObject.transform.localScale = new Vector3(newScale, newScale, newScale);
        // Intégration des VFX
        // TODO: Ajouter des animations ou VFX pour la mise à jour de l'échelle
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = true;
            hasReachedMaxHeight = false;
            StopFlying();
            if (fallCoroutine != null)
            {
                StopCoroutine(fallCoroutine);
                fallCoroutine = null;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isTouchingGround = false;
        }
    }

    public void StopFlying() // Rendre public
    {
        if (flyCoroutine != null)
        {
            StopCoroutine(flyCoroutine);
            flyCoroutine = null;
        }
        isFlying = false;
        // VFX
        _playerAnimator.SetBool("IsFloating", false);
    }
}
