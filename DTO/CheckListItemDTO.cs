namespace GestranTeste.DTO
{
    public class CheckListItemDTO
    {
        public int Id { get; set; }

        public int ChecklistId { get; set; }
        public CheckListDTO checklistDTO { get; set; }
        public int ItemInspecaoId { get; set; }
        public ItemInspecaoDTO itemInspecaoDTO { get; set; }
        public bool Conforme { get; set; }
        public string Observacao { get; set; }
    }
}
