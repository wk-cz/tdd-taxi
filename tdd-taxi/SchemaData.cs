namespace tdd_taxi
{
    public class SchemaData
    {
        public string Type { get; set; }
        public string Value { get; set; }

        public SchemaData(string Type, string Value)
        {
            this.Type = Type;
            this.Value = Value;
        }
    }
}
