namespace training.DB.model
{
    class Song : IRecord
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
    }
}
