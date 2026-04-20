using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JukeboxFadeTrigger : MonoBehaviour
{
    public CanvasGroup fadePanel;
    public AudioSource jukeboxAudio;
    public float fadeDuration = 2f;
    public float targetVolume = 1f;

    public void StartFade()
    {
        StartCoroutine(FadeSequence());
    }

    IEnumerator FadeSequence()
    {
        float startAlpha = fadePanel.alpha;
        float startVolume = jukeboxAudio.volume;
        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            float t = time / fadeDuration;

            fadePanel.alpha = Mathf.Lerp(startAlpha, 1f, t);
            jukeboxAudio.volume = Mathf.Lerp(startVolume, targetVolume, t);

            yield return null;
        }

        fadePanel.alpha = 1f;
        jukeboxAudio.volume = targetVolume;

        // Optional: Load next scene or teleport
        // SceneManager.LoadScene("NextScene");
    }
}
