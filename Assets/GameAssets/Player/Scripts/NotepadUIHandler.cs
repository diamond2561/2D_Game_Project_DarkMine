using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NotepadUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject notepadPanel; // Панель блокнота
    [SerializeField] private Button buttonPrefab;
    [SerializeField] private Transform contentPanel;
    [SerializeField] private TextMeshProUGUI _noteTitle;
    [SerializeField] private TextMeshProUGUI _noteContent;

    private GamePause _gamePause;

    public void Initialize(GamePause gamePause)
    {
        _gamePause = gamePause;
    }

    public void ToggleNotepad()
    {
        bool isActive = !notepadPanel.activeSelf;
        notepadPanel.SetActive(isActive);

        if (isActive)
            _gamePause.PauseGame();
        else
            _gamePause.UnpauseGame();
    }

    public void UpdateNotesUI(List<NoteData> notes, System.Action<int> onNoteSelected)
    {
        foreach (Transform child in contentPanel)
            Destroy(child.gameObject);

        for (int i = 0; i < notes.Count; i++)
        {
            int index = i;
            Button newButton = Instantiate(buttonPrefab, contentPanel);
            TMP_Text buttonText = newButton.GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
                buttonText.text = "Note " + (i + 1);

            newButton.onClick.AddListener(() => onNoteSelected?.Invoke(index));
        }
    }

    public void DisplayNote(NoteData note)
    {
        _noteTitle.text = LocalizationHelper.Get(note.titleKey);
        _noteContent.text = LocalizationHelper.Get(note.contentKey);
    }
}