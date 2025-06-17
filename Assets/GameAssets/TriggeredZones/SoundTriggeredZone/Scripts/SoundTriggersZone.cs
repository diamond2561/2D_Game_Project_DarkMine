using System.Collections.Generic;
using UnityEngine;

public class SoundTriggersZone : MonoBehaviour
{
    // Список AudioSource, из которых будет выбираться случайный звук
    [SerializeField] private List<AudioSource> _triggerSounds = new List<AudioSource>();

    public void PlayRandomTriggerSound()
    {
        // Проверяем, есть ли звуки в списке
        if (_triggerSounds == null || _triggerSounds.Count == 0)
        {
            Debug.LogWarning("Список звуков пуст!");
            return;
        }

        // Выбираем случайный AudioSource из списка
        int randomIndex = Random.Range(0, _triggerSounds.Count);
        AudioSource randomSound = _triggerSounds[randomIndex];

        // Воспроизводим выбранный звук
        randomSound.Play();
        Debug.Log($"Played sound: {randomSound.clip.name}");
    }
}
