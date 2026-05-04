using UnityEngine;
using UnityEngine.UI;

public class MobilePlatformDetector : MonoBehaviour
{
    public GameObject mobileUI;
   // public Text TextPlatform;
    public MonoBehaviour mobileMovement;

    //private string _mob = "Mobile";
    //private string _pc = "PC";

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
            //TextPlatform.text = _mob;
            //Debug.Log("Запуск как МОБИЛЬНОЕ устройство");
        }
        else
        {
            if (mobileUI != null) mobileUI.SetActive(false);
            if (mobileMovement != null) mobileMovement.enabled = false;
            //TextPlatform.text = _pc;
            //Debug.Log("Запуск как ДЕСКТОП");
        }
    }
}


















