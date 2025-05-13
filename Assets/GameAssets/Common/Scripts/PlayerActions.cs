using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private NoteReader _noteReader;   


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _noteReader.HideNoteReader();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        if (_player != null)
        {
            _player.PickUpNotes.AddListener(OnItemPickedUp);
        }
    }

    private void OnDisable()
    {
        if (_player != null)
        {
            _player.PickUpNotes.RemoveListener(OnItemPickedUp);
        }
    }

    private void OnItemPickedUp()
    {
        _noteReader.GetNewspaperArticle();
    }
}
