using System.Drawing;

namespace Dapper.Net.Models
{
    public class Categories
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public Image Picture { get; set; }
    }
}
