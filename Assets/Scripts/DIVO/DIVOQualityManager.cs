
using UnityEngine;

public class DIVOQualityManager : MonoBehaviour
{
    private const string ULTRA_LEVEL = "DIVO WebGL Ultra";
    private const string PC_LEVEL = "PC";
    private const string MOBILE_LEVEL = "Mobile";

    private void Start()
    {
        // Единое начальное качество для всех платформ.
        // Пользователь может изменить его кнопками.
        SetMedium();
    }

    public void SetUltra()
    {
        SetQuality(ULTRA_LEVEL, 0);
    }

    public void SetMedium()
    {
        SetQuality(PC_LEVEL, 1);
    }

    public void SetLow()
    {
        SetQuality(MOBILE_LEVEL, 2);
    }

    private void SetQuality(string levelName, int mipmapLimit)
    {
        int levelIndex = System.Array.IndexOf(
            QualitySettings.names,
            levelName
        );

        if (levelIndex < 0)
        {
            Debug.LogError(
                $"DIVO Quality Manager: Quality Level '{levelName}' not found!"
            );
            return;
        }

        QualitySettings.SetQualityLevel(levelIndex, true);

        QualitySettings.globalTextureMipmapLimit = mipmapLimit;

        Debug.Log(
            $"DIVO Quality: {levelName} | " +
            $"Texture Mipmap Limit: " +
            $"{QualitySettings.globalTextureMipmapLimit}"
        );
    }
}



//                                      То же рабочий вариант, но с автоматическим выбором качества в зависимости от платформы.
//using UnityEngine;

//public class DIVOQualityManager : MonoBehaviour
//{
//    private const string ULTRA_LEVEL = "DIVO WebGL Ultra";
//    private const string PC_LEVEL = "PC";
//    private const string MOBILE_LEVEL = "Mobile";

//    private void Start()
//    {
//        // При запуске автоматически выбираем
//        // начальное качество в зависимости от устройства.

//        if (Application.isMobilePlatform)
//        {
//            SetLow();
//        }
//        else
//        {
//            SetMedium();
//        }
//    }

//    public void SetUltra()
//    {
//        SetQuality(ULTRA_LEVEL, 0);
//    }

//    public void SetMedium()
//    {
//        SetQuality(PC_LEVEL, 1);
//    }

//    public void SetLow()
//    {
//        SetQuality(MOBILE_LEVEL, 2);
//    }

//    private void SetQuality(string levelName, int mipmapLimit)
//    {
//        int levelIndex = System.Array.IndexOf(
//            QualitySettings.names,
//            levelName
//        );

//        if (levelIndex < 0)
//        {
//            Debug.LogError(
//                $"DIVO Quality Manager: Quality Level '{levelName}' not found!"
//            );
//            return;
//        }

//        // Переключаем Quality Level
//        QualitySettings.SetQualityLevel(levelIndex, true);

//        // Переключаем разрешение Mipmap
//        QualitySettings.globalTextureMipmapLimit = mipmapLimit;

//        Debug.Log(
//            $"DIVO Quality: {levelName} | " +
//            $"Texture Mipmap Limit: " +
//            $"{QualitySettings.globalTextureMipmapLimit}"
//        );
//    }
//}