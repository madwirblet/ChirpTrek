using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static string SelectedEnvironment;

    public void ChooseEnvironment(string envName)
    {
        SelectedEnvironment = envName;
        SceneManager.LoadScene("MainScene");
    }
}
