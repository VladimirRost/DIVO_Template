using UnityEngine;
using UnityEngine.UI;

public class MobilePlatformDetector : MonoBehaviour
{
    public GameObject mobileUI;
    public Text TextPlatform;
    public MonoBehaviour mobileMovement;

    private string _mob = "Mobile";
    private string _pc = "PC";

#if UNITY_EDITOR
    [Tooltip("Принудительно эмулировать мобильное устройство в редакторе")]
    public bool simulateMobile = false;
#endif

    private void Start()
    {
        bool isMobile;

#if UNITY_EDITOR
        isMobile = simulateMobile;
#else
        // В билде определяем надёжным способом: Unity API + (если WebGL) плагин JavaScript
        isMobile = Application.isMobilePlatform || IsMobileViaWebGLPlugin();
#endif

        Debug.Log($"Is Mobile: {isMobile} | DeviceType: {SystemInfo.deviceType} | Platform: {Application.platform}");

        if (isMobile)
        {
            if (mobileUI != null) mobileUI.SetActive(true);
            if (mobileMovement != null) mobileMovement.enabled = true;
            TextPlatform.text = _mob;
            Debug.Log("Запуск как МОБИЛЬНОЕ устройство");
        }
        else
        {
            if (mobileUI != null) mobileUI.SetActive(false);
            if (mobileMovement != null) mobileMovement.enabled = false;
            TextPlatform.text = _pc;
            Debug.Log("Запуск как ДЕСКТОП");
        }
    }

#if !UNITY_EDITOR && UNITY_WEBGL
    // Импорт нашей JavaScript-функции из плагина
    [System.Runtime.InteropServices.DllImport("__Internal")]
    private static extern int IsMobile();

    private bool IsMobileViaWebGLPlugin()
    {
        try
        {
            return IsMobile() == 1;
        }
        catch
        {
            // Если вызов не удался (например, не WebGL), вернём false
            return false;
        }
    }
#else
    private bool IsMobileViaWebGLPlugin() => false;
#endif
}


















