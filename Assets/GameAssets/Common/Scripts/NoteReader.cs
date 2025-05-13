using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NoteReader : MonoBehaviour
{
    [SerializeField] private PlayerCollisionDetector _playerCollisionDetector;
    [SerializeField] private TextMeshProUGUI _noteTitleText;
    [SerializeField] private TextMeshProUGUI _noteContentText;

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
        BasePickableItem _currentPickItem = _playerCollisionDetector.GetPickableItem();

        if (_currentPickItem is NewspaperArticle newspaper)
        {
            ShowNoteReader();
            _noteTitleText.text = newspaper.note.title;
            _noteContentText.text = newspaper.note.content;
            newspaper.DisableNoteOnMap();
        }
    }
}
