using UnityEngine;
using UnityEngine.InputSystem;

public class PressAnyButtonToContinue : MonoBehaviour
{
    public GameObject welcomeMenu;
    public GameObject nextPanel;
    private InputAction anyButtonAction;
    
    void OnEnable()
    {
        // Create a composite that listens to multiple VR controller inputs
        anyButtonAction = new InputAction(type: InputActionType.Button);
        
        // Add bindings for common VR controller buttons
        anyButtonAction.AddBinding("<XRController>{LeftHand}/triggerPressed");
        anyButtonAction.AddBinding("<XRController>{RightHand}/triggerPressed");
        anyButtonAction.AddBinding("<XRController>{LeftHand}/gripPressed");
        anyButtonAction.AddBinding("<XRController>{RightHand}/gripPressed");
        anyButtonAction.AddBinding("<XRController>{LeftHand}/primaryButton");
        anyButtonAction.AddBinding("<XRController>{RightHand}/primaryButton");
        anyButtonAction.AddBinding("<XRController>{LeftHand}/secondaryButton");
        anyButtonAction.AddBinding("<XRController>{RightHand}/secondaryButton");
        
        // Also keep keyboard for testing
        anyButtonAction.AddBinding("<Keyboard>/anyKey");
        
        anyButtonAction.performed += OnAnyButtonPressed;
        anyButtonAction.Enable();
        
        Debug.Log("PressAnyButtonToContinue enabled and listening");
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
        Debug.Log($"Button pressed! Control: {ctx.control.name}");
        if (nextPanel != null) nextPanel.SetActive(true);
        if (welcomeMenu != null) welcomeMenu.SetActive(false);
    }
}