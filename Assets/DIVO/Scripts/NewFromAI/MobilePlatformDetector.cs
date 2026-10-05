using UnityEngine;
using UnityEngine.UI;

public class MobilePlatformDetector : MonoBehaviour
{
    public GameObject mobileUI;
    public MonoBehaviour mobileMovement;
    public MonoBehaviour cameraLookScript;  // <-- НОВАЯ ссылка на CameraLook



#if UNITY_EDITOR
    [Tooltip("Принудительно эмулировать мобильное устройство в редакторе")]
    public bool simulateMobile = false;
#endif

    private void Start()
    {
        bool isMobile;

#if UNITY_EDITOR
        // В редакторе управляем вручную
        isMobile = simulateMobile;
#else
        // В билде – проверка Unity (точно работает в WebGL на телефонах)
        isMobile = Application.isMobilePlatform;
#endif

        Debug.Log($"Is Mobile: {isMobile} | DeviceType: {SystemInfo.deviceType}");

        if (isMobile)
        {
            if (mobileUI != null) mobileUI.SetActive(true);
            if (mobileMovement != null) mobileMovement.enabled = true;
            if (cameraLookScript != null) cameraLookScript.enabled = true;   // включаем мобильный поворот
        }
        else
        {
            if (mobileUI != null) mobileUI.SetActive(false);
            if (mobileMovement != null) mobileMovement.enabled = false;
            if (cameraLookScript != null) cameraLookScript.enabled = false;  // выключаем мобильный поворот
        }
    }
}
