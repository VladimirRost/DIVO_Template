using UnityEngine;
using System;
using UnityEngine.UI;

public class SunPositionController : MonoBehaviour
{
    public Text MonthCounter;


    [Header("Location")]
    [Range(-90f, 90f)] public float latitude = 43.25f;   // Алматы
    [Range(-180f, 180f)] public float longitude = 76.95f;

    [Header("Date & Time")]
    public int year = 2025;
    [Range(1, 12)] public int month = 6;
    [Range(1, 31)] public int day = 21;
    [Range(0f, 24f)] public float timeOfDay = 12f;

    public Button ButtonSwitchMountPlus;  //  Кнопка Увеличения месяца
    public Button ButtonSwitchMountMinus;  //  Кнопка Уменьшения месяца

    [Header("References")]
    public Light sunLight;

    private void Start()
    {
        MonthCounter.text = month.ToString();
    }

    void Update()
    {
        UpdateSun();
    }

    public void UpdateSun()
    {
        DateTime date = new DateTime(year, month, day);
        int dayOfYear = date.DayOfYear;

        float latRad = Mathf.Deg2Rad * latitude;

        // Солнечное склонение
        float declination = 23.45f * Mathf.Sin(Mathf.Deg2Rad * (360f / 365f * (dayOfYear - 81)));
        float declRad = Mathf.Deg2Rad * declination;

        // Часовой угол
        float hourAngle = (timeOfDay - 12f) * 15f;
        float hourRad = Mathf.Deg2Rad * hourAngle;

        //// Высота солнца
        ///
        float sinAlt = Mathf.Sin(latRad) * Mathf.Sin(declRad) +
               Mathf.Cos(latRad) * Mathf.Cos(declRad) * Mathf.Cos(hourRad);
        sinAlt = Mathf.Clamp(sinAlt, -1f, 1f);
        float altitude = Mathf.Asin(sinAlt);
        //float altitude = Mathf.Asin(
        //    Mathf.Sin(latRad) * Mathf.Sin(declRad) +
        //    Mathf.Cos(latRad) * Mathf.Cos(declRad) * Mathf.Cos(hourRad)
        //);

        // Азимут
        float denom = Mathf.Cos(altitude) * Mathf.Cos(latRad);
        float azimuth;

        if (Mathf.Abs(denom) < 1e-6f)   // зенит или очень близко → азимут не определён
        {
            azimuth = 0f;               // можно поставить любое значение, например 0
        }
        else
        {
            float cosAz = (Mathf.Sin(declRad) - Mathf.Sin(altitude) * Mathf.Sin(latRad)) / denom;
            cosAz = Mathf.Clamp(cosAz, -1f, 1f);
            azimuth = Mathf.Acos(cosAz);
        }



        //float azimuth = Mathf.Acos(
        //    (Mathf.Sin(declRad) - Mathf.Sin(altitude) * Mathf.Sin(latRad)) /
        //    (Mathf.Cos(altitude) * Mathf.Cos(latRad))
        //);

        float altitudeDeg = Mathf.Rad2Deg * altitude;
        float azimuthDeg = Mathf.Rad2Deg * azimuth;

        if (timeOfDay > 12f)
            azimuthDeg = 360f - azimuthDeg;

        // Поворот солнца
        //sunLight.transform.rotation = Quaternion.Euler(altitudeDeg, azimuthDeg, 0f);
        sunLight.transform.rotation = Quaternion.Euler(altitudeDeg, azimuthDeg - 180f, 0f);
    }


    public void ButtomPlusMounth()
    {
        
        if (month<12)
        {
            month++;
        }
        //Debug.Log(month);
        MonthCounter.text = month.ToString();
    }
    public void ButtomMinusMounth()
    {
        if (month > 1)
        {
            month--;
        }
        //Debug.Log(month);
        MonthCounter.text = month.ToString();
    }
}
