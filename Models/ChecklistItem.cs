namespace Models
{
    public class ChecklistItem
    {
        public int Id { get; set; }
        public int Checklist_Id { get; set; }        
        public int Item_Inspecao_Id { get; set; }        
        public bool Conforme { get; set; }
        public string Observacao { get; set; }
    }
}
