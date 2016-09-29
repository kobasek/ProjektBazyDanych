using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BazyDanych
{
    /// <summary>
    /// Pomocnicza klasa służąca do wypełniania tabeli z listą szablonów
    /// </summary>
    class TemplateTableElement
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TemplateTableElement(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
