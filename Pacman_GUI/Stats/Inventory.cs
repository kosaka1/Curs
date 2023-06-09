
namespace Course
{
    internal class Inventory // Інвентар, має фіксований розмір
    {
        public List<Item> Contents { get; private set; }
        public bool ItemIsAdded { get; private set; }
        private int size;

        public Inventory(int size)
        {
            this.size = size;
            ItemIsAdded = false;
            Contents = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (!IsFull())
            {
                Contents.Add(item);
                ItemIsAdded = true;
            }
            else
            {
                ItemIsAdded = false;
            }
        }

        private bool IsFull()
        {
            return size == Contents.Count;
        }
    }
}
