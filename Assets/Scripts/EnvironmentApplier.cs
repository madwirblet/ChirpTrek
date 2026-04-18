using UnityEngine;

public class EnvironmentApplier : MonoBehaviour
{
    public Material DaytimeSkybox;
    public Material SunriseSkybox;
    public Material SunsetSkybox;
    public Material StormySkybox;

    void Start()
    {
        switch (SceneLoader.SelectedEnvironment)
        {
            case "Daytime":
                RenderSettings.skybox = DaytimeSkybox;
                break;

            case "Sunrise":
                RenderSettings.skybox = SunriseSkybox;
                break;

            case "Sunset":
                RenderSettings.skybox = SunsetSkybox;
                break;

            case "Stormy":
                RenderSettings.skybox = StormySkybox;
                break;
        }
    }
}
