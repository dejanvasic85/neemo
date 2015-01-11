namespace Neemo.Store
{
    public class Category
    {
        public int CategoryId { get; set; }
        public int? ParentId { get; set; }
        public Category ParentCategory { get; set; }
        
        // CategoryTable -> Category
        public string Title { get; set; }
    }
}