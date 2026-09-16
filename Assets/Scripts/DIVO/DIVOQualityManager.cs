using UnityEngine;

public class DIVOQualityManager : MonoBehaviour
{
    public void SetUltra()
    {
        QualitySettings.SetQualityLevel(
            QualitySettings.names.Length > 0
                ? System.Array.IndexOf(QualitySettings.names, "DIVO WebGL Ultra")
                : 0
        );

        QualitySettings.globalTextureMipmapLimit = 0;
    }

    public void SetPC()
    {
        QualitySettings.SetQualityLevel(
            System.Array.IndexOf(QualitySettings.names, "PC")
        );

        QualitySettings.globalTextureMipmapLimit = 1;
    }

    public void SetMobile()
    {
        QualitySettings.SetQualityLevel(
            System.Array.IndexOf(QualitySettings.names, "Mobile")
        );

        QualitySettings.globalTextureMipmapLimit = 2;
    }
}