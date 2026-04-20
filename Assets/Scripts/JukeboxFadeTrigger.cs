using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System.Collections;

public class JukeboxFadeTrigger : MonoBehaviour
{
    public CanvasGroup fadePanel;
    public AudioSource jukeboxAudio;
    public float fadeDuration = 2f;
    public float targetVolume = 0f;

    private XRSimpleInteractable interactable;
    private bool hasTriggered = false;

    void Awake()
    {
        Debug.Log("=== JUKEBOX AWAKE ===");

        interactable = GetComponent<XRSimpleInteractable>();
        if (interactable == null)
        {
            Debug.Log("Adding XRSimpleInteractable component...");
            interactable = gameObject.AddComponent<XRSimpleInteractable>();
        }

        interactable.selectEntered.AddListener(OnJukeboxSelected);
        Debug.Log("Subscribed to selectEntered event");
    }

    void Start()
    {
        Debug.Log("=== JUKEBOX DEBUG START ===");
        Debug.Log("Script is running on: " + gameObject.name);
        Debug.Log("Interactable exists: " + (interactable != null));
        Debug.Log("Fade Panel assigned: " + (fadePanel != null));
        Debug.Log("Audio assigned: " + (jukeboxAudio != null));
        Debug.Log("Has collider: " + (GetComponent<Collider>() != null));

        if (interactable != null)
        {
            Debug.Log("Interactable is enabled: " + interactable.enabled);
            Debug.Log("Interactable layer mask: " + interactable.interactionLayers.value);
        }

        if (fadePanel != null)
        {
            fadePanel.alpha = 0f;
            fadePanel.interactable = false;
            fadePanel.blocksRaycasts = false;
            Debug.Log("Fade panel starting alpha: " + fadePanel.alpha);
        }
    }

    void OnDestroy()
    {
        if (interactable != null)
        {
            interactable.selectEntered.RemoveListener(OnJukeboxSelected);
        }
    }

    private void OnJukeboxSelected(SelectEnterEventArgs args)
    {
        if (hasTriggered) return;
        hasTriggered = true;

        Debug.Log("!!! JUKEBOX WAS SELECTED !!!");
        Debug.Log("Selected by: " + args.interactorObject);
        StartFade();
    }

    public void StartFade()
    {
        Debug.Log("StartFade() called");

        if (fadePanel == null)
        {
            Debug.LogError("Fade Panel is not assigned!");
            return;
        }

        StartCoroutine(FadeSequence());
    }

    IEnumerator FadeSequence()
    {
        Debug.Log("Fade sequence starting...");

        float startAlpha = fadePanel.alpha;
        float startVolume = jukeboxAudio != null ? jukeboxAudio.volume : 0f;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float t = Mathf.Clamp01(time / fadeDuration);

            fadePanel.alpha = Mathf.Lerp(startAlpha, 1f, t);

            if (jukeboxAudio != null)
            {
                jukeboxAudio.volume = Mathf.Lerp(startVolume, targetVolume, t);
            }

            yield return null;
        }

        fadePanel.alpha = 1f;

        if (jukeboxAudio != null)
        {
            jukeboxAudio.volume = targetVolume;
        }

        Debug.Log("Fade complete!");
    }
}