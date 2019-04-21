namespace RestTestProject.Data
{
    public class ItemTemplate
    {
        public string Item { get; private set; }
        public string Index { get; private set; }
        public const string SPACE_SEPARATOR = " ";
        public const string TABULATION_SEPARATOR = "\t";
        public const string NEW_ROW_SEPARATOR = "\n";

        public ItemTemplate(string item, string index)
        {
            Item = item;
            Index = index;
        }

        public override string ToString()
        {
            return Index + SPACE_SEPARATOR + TABULATION_SEPARATOR + Item + NEW_ROW_SEPARATOR;
        }

        public string GetIndex()
        {
            return Index + SPACE_SEPARATOR;
        }

    }
}
