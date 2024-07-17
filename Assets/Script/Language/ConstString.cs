using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ConstString
{
    public static StringLanguage LanguageAdd = 
        new StringLanguage("Вы нашли предмет", "Have you found the item");

    public static StringLanguage LanguageNot = 
        new StringLanguage("Ваш инвентарь заполнен", "Your inventory is full");

    public static StringLanguage PurposeCurrentText =
        new StringLanguage("Текущая цель:", "Current goal:");
}