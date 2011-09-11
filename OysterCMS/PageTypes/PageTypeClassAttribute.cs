using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OysterCMS.PageTypes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class PageTypeAttribute : Attribute
    {
        public PageTypeAttribute() { }
        public PageTypeAttribute(string name, string fileName, string description, string thumbnailUrl, int sortOrder)
        {
            Name = name;
            SortOrder = sortOrder;
            FileName = fileName;
            Description = description;
            ThumbnailUrl = thumbnailUrl;
        }

        public string Name { get; set; }
        public int SortOrder { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }

    }
}
