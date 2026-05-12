using UnityEngine;
//                                                    Управление с мобильника  !!!!!!!!!!!!!!!!!!!!
public class CameraLook : MonoBehaviour
{
    public Transform cameraPivot;
    public float sensitivity = 120f;
    public float smooth = 10f;

    float yaw;
    float pitch;

    Vector2 currentLook;
    Vector2 targetLook;

    private void Awake()
    {
#if !UNITY_EDITOR
    if (!Application.isMobilePlatform)
    {
        enabled = false;
        return;
    }
#endif
    }
    void Start()
    {
    yaw = cameraPivot.transform.eulerAngles.y;
    }

    public void Look(Vector2 delta)
    {
        targetLook += delta * sensitivity * Time.deltaTime;
    }

    void Update()
    {
        currentLook = Vector2.Lerp(
            currentLook,
            targetLook,
            smooth * Time.deltaTime
        );

        yaw += currentLook.x;
        pitch -= currentLook.y;
        pitch = Mathf.Clamp(pitch, -89f, 89f);

        cameraPivot.localRotation =
        Quaternion.Euler(pitch, yaw, 0f);
        targetLook = Vector2.zero;
    }

}




