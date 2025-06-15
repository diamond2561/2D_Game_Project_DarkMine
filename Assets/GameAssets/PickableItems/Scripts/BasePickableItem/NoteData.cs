[System.Serializable]
public class NoteData
{
    public string titleKey;
    public string contentKey;

    public NoteData(string titleKey, string contentKey)
    {
        this.titleKey = titleKey;
        this.contentKey = contentKey;
    }
}