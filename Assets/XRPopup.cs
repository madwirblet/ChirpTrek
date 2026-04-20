using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class XRPopup : MonoBehaviour
{
    public GameObject popupUI;
    public TextMeshProUGUI popupText;

    [TextArea]
    public string message;

    private UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable interactable;

    void Awake()
    {
        interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRBaseInteractable>();

        interactable.hoverEntered.AddListener(ShowPopup);
        interactable.hoverExited.AddListener(HidePopup);
    }

    void ShowPopup(HoverEnterEventArgs args)
    {
        popupText.text = message;
        popupUI.SetActive(true);
    }

    void HidePopup(HoverExitEventArgs args)
    {
        popupUI.SetActive(false);
    }
}