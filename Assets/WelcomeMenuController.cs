using UnityEngine;
using UnityEngine.InputSystem;

public class PressAnyButtonToContinue : MonoBehaviour
{
    public GameObject welcomeMenu;
    public GameObject nextPanel;

    private InputAction anyButtonAction;

    void OnEnable()
    {
        anyButtonAction = new InputAction(type: InputActionType.Button, binding: "/*/<button>");
        anyButtonAction.performed += OnAnyButtonPressed;
        anyButtonAction.Enable();
    }

    void OnDisable()
    {
        if (anyButtonAction != null)
        {
            anyButtonAction.performed -= OnAnyButtonPressed;
            anyButtonAction.Disable();
            anyButtonAction.Dispose();
        }
    }

    private void OnAnyButtonPressed(InputAction.CallbackContext ctx)
    {
        if (nextPanel != null) nextPanel.SetActive(true);
        if (welcomeMenu != null) welcomeMenu.SetActive(false);
    }
}