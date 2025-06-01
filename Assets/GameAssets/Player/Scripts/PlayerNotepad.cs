using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNotepad : MonoBehaviour
{
    public List<NewspaperArticle> Items = new List<NewspaperArticle>();

    private static PlayerNotepad _instance;
    public static PlayerNotepad Instance => _instance;

    [SerializeField] private GameObject notepadPanel; // Ссылка на UI-панель блокнота

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject); // Сохраняем объект при переходе между сценами
        }
        else
        {
            Destroy(gameObject); // Уничтожаем дубликаты
        }
    }

    private void Start()
    {
        // Деактивируем панель блокнота при старте
        notepadPanel.SetActive(false);
    }

    private void Update()
    {
        // Открываем/закрываем блокнот по нажатию клавиши N
        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNotepad();
        }
    }

    public void AddItem(NewspaperArticle newspaperArticle)
    {
        Items.Add(newspaperArticle);
        Debug.Log("Заметка добавлена в блокнот");
    }

    public void ToggleNotepad()
    {
        // Переключаем состояние панели блокнота
        notepadPanel.SetActive(!notepadPanel.activeSelf);

        if (notepadPanel.activeSelf)
        {
            PopulateNotepad(); // Заполняем блокнот данными
        }
    }

    private void PopulateNotepad()
    {
        //// Очищаем старые заметки
        //foreach (Transform child in contentPanel)
        //{
        //    Destroy(child.gameObject);
        //}

        //// Создаем новые заметки
        //foreach (var item in Items)
        //{
        //    GameObject noteInstance = Instantiate(notePrefab, contentPanel);
        //    NoteDisplay noteDisplay = noteInstance.GetComponent<NoteDisplay>();
        //    noteDisplay.SetNote(item);
        //}
    }
}