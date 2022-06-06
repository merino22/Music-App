namespace AssistantManager.API.DataTransferObjects
{
    public class ListIngredientsDTO
    {
        public string ListName { get; set; }

        public IEnumerable<string> Ingredients { get; set; }
    }
}
