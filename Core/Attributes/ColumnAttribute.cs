using System;

namespace Core.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute(string title = "", bool visible = true)
        {
            Title = title;
            Visible = visible;
        }

        public string Title { get; private set; }

        public bool Visible { get; private set; }
    }
}
