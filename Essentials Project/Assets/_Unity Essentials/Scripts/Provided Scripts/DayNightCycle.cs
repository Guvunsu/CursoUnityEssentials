using UnityEngine;

public class DayNightCycle : MonoBehaviour {
    [Header("Sun Settings")]
    public Light sun; // Luz principal
    public float dayDuration = 60f; // Duración de un día en segundos

    [Header("Skybox Settings")]
    public Material daySkybox;
    public Material nightSkybox;

    private float timeElapsed;
    private bool isDay = true;

    private void Update() {
        // Avanzar tiempo
        timeElapsed += Time.deltaTime;

        // Calcular rotación del sol
        float sunRotation = (timeElapsed / dayDuration) * 360f;
        sun.transform.rotation = Quaternion.Euler(new Vector3(sunRotation - 90f, 170f, 0f));

        // Cambiar de día a noche
        UpdateSkyboxAndLight();

        // Reiniciar el ciclo
        if (timeElapsed >= dayDuration) {
            timeElapsed = 0f;
        }
    }

    private void UpdateSkyboxAndLight() {
        // Interpolación para transición suave
        float cycleProgress = Mathf.PingPong(timeElapsed / (dayDuration / 2f), 1f);

        if (cycleProgress > 0.5f && isDay) {
            isDay = false;
            RenderSettings.skybox = nightSkybox;
        } else if (cycleProgress <= 0.5f && !isDay) {
            isDay = true;
            RenderSettings.skybox = daySkybox;
        }

        // Ajustar intensidad de la luz
        sun.intensity = Mathf.Lerp(0.2f, 1f, cycleProgress);
    }
}

