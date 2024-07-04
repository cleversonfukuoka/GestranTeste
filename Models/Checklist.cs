namespace Models
{
    public class Checklist
    {
        public int Id { get; set; }
        public int Veiculo_Id { get; set; }
        public int Usuario_Executor_Id { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime? Data_Fim { get; set; }
        public bool Finalizado { get; set; }
        public bool? Aprovado { get; set; }
        public int? Usuario_Supervisor_Id { get; set; }

        public List<ChecklistItem> Items { get; set; }
    }
}
