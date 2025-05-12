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
