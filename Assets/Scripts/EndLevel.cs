// EndLevel.cs
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public GameObject endLevelObject; // L'objet de fin de niveau
    public Ballon playerBallon; // Référence au script Ballon du joueur
    public float delayBeforeSceneChange = 0.5f; // Délai avant de changer de scène
    public float moveDuration = 2f; // Durée du déplacement vers la droite
    public float fadeDuration = 2f; // Durée du fondu en noir (identique à moveDuration)

    private bool isCoroutineRunning = false;
    [SerializeField] Animator _playerAnimator;
    [SerializeField] AudioSource _victorySFX;

    void Update()
    {
        if (playerBallon.transform.position.x > endLevelObject.transform.position.x)
        {
            playerBallon.StopFlying();
            if (playerBallon.fallCoroutine == null)
            {
                playerBallon.fallCoroutine = StartCoroutine(playerBallon.FallVertically());
            }

            if (!playerBallon.isFlying && !isCoroutineRunning)
            {
                StartCoroutine(HandleEndLevelSequence());
            }
        }
    }

    private IEnumerator HandleEndLevelSequence()
    {
        isCoroutineRunning = true;
        yield return new WaitUntil(() => !playerBallon.isFlying);
        _playerAnimator.SetBool("IsEnd", true);
        _victorySFX.Play();
        yield return MovePlayerRight();
        yield return FadeToBlack();
        yield return new WaitForSeconds(delayBeforeSceneChange);
        Debug.Log("FIN WIN");
        SceneManager.LoadScene("WinScene");
    }

    private IEnumerator MovePlayerRight()
    {
        float startTime = Time.time;
        Vector3 startPosition = playerBallon.transform.position;
        Vector3 endPosition = startPosition + Vector3.right * 2f; // Déplace de 2 unités vers la droite

        while (Time.time - startTime < moveDuration)
        {
            float t = (Time.time - startTime) / moveDuration;
            playerBallon.transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        playerBallon.transform.position = endPosition;
    }

    private IEnumerator FadeToBlack()
    {
        CanvasGroup canvasGroup = new GameObject("FadeCanvas").AddComponent<CanvasGroup>();
        canvasGroup.alpha = 0;
        canvasGroup.gameObject.AddComponent<Canvas>().renderMode = RenderMode.ScreenSpaceOverlay;
        DontDestroyOnLoad(canvasGroup.gameObject);

        float startTime = Time.time;

        while (Time.time - startTime < fadeDuration)
        {
            canvasGroup.alpha = (Time.time - startTime) / fadeDuration;
            yield return null;
        }

        canvasGroup.alpha = 1;
    }
}
