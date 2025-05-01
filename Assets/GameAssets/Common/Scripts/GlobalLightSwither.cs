using UnityEngine;
using UnityEngine.Rendering.Universal;

public class GlobalLightSwither : MonoBehaviour
{
    [SerializeField] private Light2D _globalLight; // Ссылка на глобальный источник света

    private void Start()
    {
        if (_globalLight != null)
        {
            // Отключаем глобальный источник света
            _globalLight.enabled = false;
            _globalLight.intensity = 0f;
            Debug.Log("Global 2D Light has been disabled.");
        }
        else
        {
            Debug.LogWarning("Global Light2D is not assigned!");
        }
    }
}
