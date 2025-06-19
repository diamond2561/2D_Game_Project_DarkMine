using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class NoteSaver
{
    private string SavePath => Path.Combine(Application.persistentDataPath, "notepad_save.json");

    public void Save(List<NoteData> notes)
    {
        string dataJson = JsonUtility.ToJson(new NoteDataListWrapper { notes = notes });
        File.WriteAllText(SavePath, dataJson);
        Debug.Log("Заметки сохранены!");
    }

    public List<NoteData> Load()
    {
        if (!File.Exists(SavePath))
        {
            Debug.Log("Файл сохранения не найден.");
            return new List<NoteData>();
        }

        string dataJson = File.ReadAllText(SavePath);
        var wrapper = JsonUtility.FromJson<NoteDataListWrapper>(dataJson);
        return wrapper.notes;
    }
}