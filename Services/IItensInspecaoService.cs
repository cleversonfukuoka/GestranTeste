using GestranTeste.DTO;

namespace GestranTeste.Services
{
    public interface IItensInspecaoService
    {
        void Create(ItemInspecaoDTO itemInspecao);
        void Update(ItemInspecaoDTO itemInspecao);
        ItemInspecaoDTO FindById(long Id);
        List<ItemInspecaoDTO> FindAll();
        void Delete(long id);

    }
}
