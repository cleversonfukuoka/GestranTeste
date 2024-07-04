using Models;

namespace GestranTeste.DTO
{
    public class CheckListDTO
    {
        public int Id { get; set; }
        public int veiculoId { get; set; }
        public VeiculoDTO veiculo { get; set; }
        public int usuarioExecutorId { get; set; }
        public UsuarioDTO usuarioExecutor { get; set; }
        public DateTime Data_Inicio { get; set; }
        public DateTime? Data_Fim { get; set; }
        public bool Finalizado { get; set; }
        public bool? Aprovado { get; set; }
        public int? usuarioSupervisorId { get; set; }
        public UsuarioDTO usuarioSupervisor { get; set; }
        public List<CheckListItemDTO> checklistItems { get; set; }
    }
}
