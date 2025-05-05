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
            _globalLight.color = new Color(0.01f, 0.01f, 0.01f);
            _globalLight.intensity = 0.1f;

        }
    }
}
