using UnityEngine;
using UnityEngine.UI;

public class NoteDisplay : MonoBehaviour
{
    [SerializeField] private Text titleText;
    [SerializeField] private Text contentText;

    public void SetNote(NewspaperArticle newspaperArticle)
    {
        // Используем поле note из NewspaperArticle для получения локализованных данных
        titleText.text = newspaperArticle.note.GetLocalizedTitle();
        contentText.text = newspaperArticle.note.GetLocalizedContent();
    }
}