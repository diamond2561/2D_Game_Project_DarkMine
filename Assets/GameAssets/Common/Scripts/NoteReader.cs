using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoteReader : MonoBehaviour
{
    [SerializeField] private PlayerCollisionDetector _playerCollisionDetector;
    [SerializeField] private TextMeshProUGUI _noteTitleText;
    [SerializeField] private TextMeshProUGUI _noteContentText;
    [SerializeField] private PlayerNotepad _playerNotepad;

    [SerializeField] private Button _closeButton;

    private NewspaperArticle _newspaperArticle;


    private void Start()
    {
        _closeButton.onClick.AddListener(HideNoteReader);
    }

    public void ShowNoteReader()
    {
        gameObject.SetActive(true);
    }

    public void HideNoteReader()
    {
        gameObject.SetActive(false);
    }

    public void GetNewspaperArticle()
    {
        // Получаем текущий собираемый предмет
        BasePickableItem _currentPickItem = _playerCollisionDetector.GetPickableItem();

        // Проверяем, является ли предмет газетной статьей
        if (_currentPickItem is NewspaperArticle newspaper)
        {
            // Отображаем интерфейс для чтения заметки
            ShowNoteReader();

            // Устанавливаем локализованный текст для заголовка и содержимого
            _noteTitleText.text = newspaper.note.GetLocalizedTitle();
            _noteContentText.text = newspaper.note.GetLocalizedContent();

            // Деактивируем заметку на карте
            newspaper.DisableNoteOnMap();

            _playerNotepad.AddItem(newspaper);
        }
    }
}
