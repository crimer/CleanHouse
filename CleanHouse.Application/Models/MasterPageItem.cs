
using System;

namespace CleanHouse.Application.Models
{
    public class MasterPageItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Type Type { get; set; }
        public string IconSource { get; set; }
    }
}
