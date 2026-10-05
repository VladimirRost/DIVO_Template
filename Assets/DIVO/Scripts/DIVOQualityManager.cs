using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DIVOQualityManager : MonoBehaviour
{
    private const string ULTRA_LEVEL = "DIVO WebGL Ultra";
    private const string PC_LEVEL = "PC";
    private const string MOBILE_LEVEL = "Mobile";

    [Header("Global Volumes")]
    public Volume ultraVolume;
    public Volume pcVolume;
    public Volume mobileVolume;

    public Button buttonUltra;
    public Button buttonMedium;
    public Button buttonLow;

    private void Start()
    {
        // Единое начальное качество для всех платформ.
        SetMedium();
    }

    public void SetUltra()
    {
        SetQuality(ULTRA_LEVEL, 0);
        SetVolume(ultraVolume);
        // активность кнопок
        buttonMedium.interactable = true;
        buttonLow.interactable = true;
        buttonUltra.interactable = false;
    }

    public void SetMedium()
    {
        SetQuality(PC_LEVEL, 1);
        SetVolume(pcVolume);
        // активность кнопок
        buttonMedium.interactable = false;
        buttonLow.interactable = true;
        buttonUltra.interactable = true;

    }

    public void SetLow()
    {
        SetQuality(MOBILE_LEVEL, 2);
        SetVolume(mobileVolume);
        // активность кнопок
        buttonMedium.interactable = true;
        buttonLow.interactable = false;
        buttonUltra.interactable = true;
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

        // Переключаем Quality Level.
        // Он же переключает соответствующий URP Asset.
        QualitySettings.SetQualityLevel(levelIndex, true);

        // Переключаем глобальный Mipmap Limit.
        QualitySettings.globalTextureMipmapLimit = mipmapLimit;

        Debug.Log(
            $"DIVO Quality: {levelName} | " +
            $"Texture Mipmap Limit: " +
            $"{QualitySettings.globalTextureMipmapLimit}"
        );
    }

    private void SetVolume(Volume activeVolume)
    {
        // Отключаем все наши глобальные профили.
        if (ultraVolume != null)
            ultraVolume.weight = 0f;

        if (pcVolume != null)
            pcVolume.weight = 0f;

        if (mobileVolume != null)
            mobileVolume.weight = 0f;

        // Включаем выбранный.
        if (activeVolume != null)
        {
            activeVolume.weight = 1f;

            Debug.Log(
                $"DIVO Volume: {activeVolume.gameObject.name}"
            );
        }
        else
        {
            Debug.LogWarning(
                "DIVO Quality Manager: Active Volume is not assigned."
            );
        }
    }
}