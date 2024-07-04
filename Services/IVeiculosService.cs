using GestranTeste.DTO;

namespace GestranTeste.Services
{
    public interface IVeiculosService
    {
        void Create(VeiculoDTO veiculo);
        void Update(VeiculoDTO veiculo);
        VeiculoDTO FindById(long Id);
        List<VeiculoDTO> FindAll();
        void Delete(long id);

    }
}
