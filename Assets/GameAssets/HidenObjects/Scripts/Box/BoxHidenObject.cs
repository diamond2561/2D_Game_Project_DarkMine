using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BoxHidenObject : BaseHidenObjects
{
    [SerializeField] private Light2D _boxLight; // Ссылка на свет коробки
    [SerializeField] private SpriteRenderer _boxSprite;
    [SerializeField] private Sprite _normalBoxSprite;
    [SerializeField] private Sprite _hidenBoxSprite;

    private void Start()
    {
        TurnOffTheObjectLight();
    }

    public override void TurnOnTheObjectLight()
    {
        if (_boxLight != null)
        {
            _boxLight.enabled = true;
            _boxSprite.sprite = _hidenBoxSprite;
        }
    }

    public override void TurnOffTheObjectLight()
    {
        if (_boxLight != null)
        {
            _boxLight.enabled = false;
            _boxSprite.sprite = _normalBoxSprite;
        }
    }
}