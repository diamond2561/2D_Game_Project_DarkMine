using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class LanguageData 
{
    public static string CURRENT_LANGUAGE = "English";

    public static Dictionary<string, Dictionary<string, string>> LOCALIZATION =
        new Dictionary<string, Dictionary<string, string>>()
        {
            // Main Menu
            { "new_game_button", new Dictionary<string, string>()
            {
                {"English", "New game" },
                {"Русский", "Новая игра" }
            }
            },
            { "continue_game_button", new Dictionary<string, string>()
            {
                {"English", "Continue" },
                {"Русский", "Продолжить" }
            }
            },
            { "options_button", new Dictionary<string, string>()
            {
                {"English", "Options" },
                {"Русский", "Настройки" }
            }
            },
            { "authors_button", new Dictionary<string, string>()
            {
                {"English", "Authors" },
                {"Русский", "Авторы" }
            }
            },
            { "quit_button", new Dictionary<string, string>()
            {
                {"English", "Quit" },
                {"Русский", "Выход" }
            }
            },

            // Options 
            { "language_text", new Dictionary<string, string>()
            {
                {"English", "Language:" },
                {"Русский", "Язык:" }
            }
            },
            { "back_to_main_menu", new Dictionary<string, string>()
            {
                {"English", "Back" },
                {"Русский", "Назад" }
            }
            },

            // Prehistory
            { "start_new_game_button", new Dictionary<string, string>()
            {
                {"English", "New game" },
                {"Русский", "Новая игра" }
            }
            },
            { "back_to_menu_button", new Dictionary<string, string>()
            {
                {"English", "Back" },
                {"Русский", "Назад" }
            }
            },
            { "next_page_button", new Dictionary<string, string>()
            {
                {"English", "Next" },
                {"Русский", "Дальше" }
            }
            },

            { "prehistory_page_1", new Dictionary<string, string>()
            {
                {"English", "Prehistory text page 1" },
                {"Русский", "Текст предыстории страница 1" }
            }
            },
            { "prehistory_page_2", new Dictionary<string, string>()
            {
                {"English", "Prehistory text page 2" },
                {"Русский", "Текст предыстории страница 2" }
            }
            },

            // GUI
            { "light_button", new Dictionary<string, string>()
            {
                {"English", "Light" },
                {"Русский", "Свет" }
            }
            },
            { "pick_up_button", new Dictionary<string, string>()
            {
                {"English", "Pick up" },
                {"Русский", "Поднять" }
            }
            },
            { "hide_button", new Dictionary<string, string>()
            {
                {"English", "Hide" },
                {"Русский", "Спрятаться" }
            }
            },
            { "notepad_button", new Dictionary<string, string>()
            {
                {"English", "Notepad" },
                {"Русский", "Блокнот" }
            }
            },
            { "pause_text", new Dictionary<string, string>()
            {
                {"English", "Pause" },
                {"Русский", "Пауза" }
            }
            },




            // Notes
            { "note_1_title", new Dictionary<string, string>()
            {
                {"English", "Last warning... Or how to survive a little longer in this hell" },
                {"Русский", "Последнее предупреждение... или как продержаться чуть дольше в этом аду" }
            }
            },
            { "note_1_content", new Dictionary<string, string>()
            {
                {"English", "Dear... or rather, an unhappy friend. If you're reading this, I'm gone. Like you, I once believed that I could get out. Like you, I was wrong.\r\n\r\nThis is a trap dungeon. And its inhabitants are not just creatures. They are death itself. It's pointless to fight. They can't be killed. You can only hide... until it's too late.\r\n\r\nBut maybe my miserable fate will help you hold out a little longer. There are others here... amorphous, shapeless. They can't see. But they hear perfectly. A step, a sigh, even a gnash of teeth in fear — and they will attack.\r\n\r\nSo remember: if you notice them, freeze. Move, and... however, you'll figure it out for yourself.\r\n\r\nGoodbye. Or see you soon... in oblivion." },
                {"Русский", "Дорогой... или скорее несчастный друг. Если ты читаешь эти строки — меня уже нет. Как и ты, я когда-то верил, что смогу выбраться. Как и ты, я ошибался.\r\n\r\nЭто подземелье — ловушка. И его обитатели — не просто твари. Они — сама смерть. Бессмысленно сражаться. Их нельзя убить. Можно только прятаться... пока не станет слишком поздно.\r\n\r\nНо, возможно, моя жалкая участь поможет тебе продержаться чуть дольше. Здесь есть другие... аморфные, бесформенные. Они не видят. Но слышат идеально. Шаг, вздох, даже скрип зубов от страха — и они нападут.\r\n\r\nТак что запомни: заметил их — замри. Шевельнешься — и... впрочем, ты сам всё поймешь.\r\n\r\nПрощай. Или до скорой встречи... в небытии." }
            }
            },

            { "note_2_title", new Dictionary<string, string>()
            {
                {"English", "Note 2 Title" },
                {"Русский", "Заметка 2" }
            }
            },
            { "note_2_content", new Dictionary<string, string>()
            {
                {"English", " Text note 2" },
                {"Русский", "Текст второй заметки" },
            }
            },

            { "note_3_title", new Dictionary<string, string>()
            {
                {"English", "Note 3 Title" },
                {"Русский", "Заметка 3" }
            }
            },
            { "note_3_content", new Dictionary<string, string>()
            {
                {"English", " Text note 3" },
                {"Русский", "Текст 3 заметки" },
            }
            },
        };


    public static string[] LANGUAGES = new string[] { "English", "Русский" };

    private static UnityEvent _OnLanguageChanged;
    public static UnityEvent OnLanguageChanged
    {
        get
        {
            if (_OnLanguageChanged == null)
                _OnLanguageChanged = new UnityEvent();

            return _OnLanguageChanged;
        }
    }
}
