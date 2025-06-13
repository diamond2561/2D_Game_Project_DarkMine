using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNotepad : MonoBehaviour
{
    public List<NewspaperArticle> Items = new List<NewspaperArticle>();

    private static PlayerNotepad _instance;
    public static PlayerNotepad Instance => _instance;

    [SerializeField] private GamePause _gamePause;

    [SerializeField] private GameObject notepadPanel; // Панель блокнота (ScrollView)
    [SerializeField] private Button buttonPrefab;      // Префаб кнопки заметки
    [SerializeField] private Transform contentPanel;   // Объект Content внутри Scroll View

    [SerializeField] private TextMeshProUGUI _noteTitle;
    [SerializeField] private TextMeshProUGUI _noteContent;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        notepadPanel.SetActive(false);
        CreateNotesButton(); // Создаём кнопки при старте
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNotepad();
        }
    }

    public void AddItem(NewspaperArticle newspaperArticle)
    {
        Items.Add(newspaperArticle);
        Debug.Log("Заметка добавлена в блокнот");
        CreateNotesButton(); // Пересоздаём кнопки после добавления новой
    }

    public void ToggleNotepad()
    {
        notepadPanel.SetActive(!notepadPanel.activeSelf);

        if (notepadPanel.activeSelf)
        {
            _gamePause.PauseGame();   // Ставим игру на паузу
        }
        else
        {
            _gamePause.UnpauseGame(); // Снимаем с паузы
        }
    }

    private void CreateNotesButton()
    {
        // Очистка предыдущих кнопок
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }

        int noteIndex = 0; // Счётчик для нумерации заметок

        foreach (NewspaperArticle article in Items)
        {
            Button newButton = Instantiate(buttonPrefab, contentPanel);

            // Увеличиваем счётчик перед использованием: начнём с 1
            noteIndex++;

            // Устанавливаем текст кнопки как "Note X"
            TMP_Text buttonText = newButton.GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
            {
                buttonText.text = "Note " + noteIndex;
            }
            else
            {
                Debug.LogError("Компонент TMP_Text не найден на кнопке!");
            }

            // Сохраняем ссылку на статью для обработчика
            NewspaperArticle localCopy = article;

            newButton.onClick.AddListener(() =>
            {
                OpenNote(localCopy);
            });
        }
    }

    private void OpenNote(NewspaperArticle article)
    {
        Debug.Log("Открыта заметка: " + article.note.GetLocalizedTitle());
        // Здесь реализуй логику отображения самой заметки
        _noteTitle.text = article.note.GetLocalizedTitle();
        _noteContent.text = article.note.GetLocalizedContent();
    }
}