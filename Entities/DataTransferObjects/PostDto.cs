namespace Entities.DataTransferObjects
{
    public record PostDto
    {
        public int Id { get; init; }  // Blog yazısı ID'si (Primary Key)
        public string Title { get; init; }  // Blog başlığı
        public string Content { get; init; }  // Blog içeriği
    }
}
