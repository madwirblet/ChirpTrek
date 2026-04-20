using UnityEngine;
using UnityEngine.InputSystem;

public class PressToContinue : MonoBehaviour
{
    public GameObject welcomeMenu;
    public GameObject nextPanel;
    public InputActionReference submitAction;

    private void OnEnable()
    {
        if (submitAction != null)
        {
            submitAction.action.performed += OnSubmit;
            submitAction.action.Enable();
            Debug.Log($"Action enabled: {submitAction.action.enabled}");
        }
    }

    private void OnDisable()
    {
        if (submitAction != null)
        {
            submitAction.action.performed -= OnSubmit;
            submitAction.action.Disable();
        }
    }

    // Temporary keyboard testing
    private void Update()
    {
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("Space pressed - triggering transition");
            TriggerTransition();
        }
    }

    private void OnSubmit(InputAction.CallbackContext ctx)
    {
        Debug.Log("OnSubmit called!");
        TriggerTransition();
    }

    private void TriggerTransition()
    {
        if (nextPanel != null)
        {
            nextPanel.SetActive(true);
            Debug.Log("Next panel activated");
        }
        if (welcomeMenu != null)
        {
            welcomeMenu.SetActive(false);
            Debug.Log("Welcome menu deactivated");
        }
    }
}