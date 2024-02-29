using System;
using System.Collections.Generic;

namespace MauiAppLaba.Utils
{
    public class ModeQuery
    {
        private static ModeQuery instance;

        private Dictionary<Mode, string> Query = new Dictionary<Mode, string>
        {
            { Mode.None, "none" },
            { Mode.Load, "load" },
            { Mode.Save, "save" },
            { Mode.Delete, "delete" }
        };

        // Приватный конструктор для Singleton
        private ModeQuery() { }

        // Статический метод для получения экземпляра синглтона
        public static ModeQuery Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ModeQuery();
                }
                return instance;
            }
        }

        public string this[Mode mode] => Query.TryGetValue(mode, out var result) ? result : "unknown";
    }

    public enum Mode
    {
        None,
        Load,
        Save,
        Delete
    }

    public static class Extension
    {
        public static string GetString(this Mode mode)
        {
            return ModeQuery.Instance[mode];
        }
    }
}
