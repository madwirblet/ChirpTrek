using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public Material daytimeSkybox;
    public Material sunriseSkybox;
    public Material sunsetSkybox;
    public Material stormySkybox;

    public void SetDaytime()  { RenderSettings.skybox = daytimeSkybox; }
    public void SetSunrise()  { RenderSettings.skybox = sunriseSkybox; }
    public void SetSunset()   { RenderSettings.skybox = sunsetSkybox; }
    public void SetStormy()   { RenderSettings.skybox = stormySkybox; }
}
