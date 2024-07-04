using GestranTeste.DTO;

namespace GestranTeste.Services
{
    public interface IChecklistService
    {
        void Create(CheckListDTO checklist);
        void Update(CheckListDTO checklist);
        CheckListDTO FindById(long Id);
        List<CheckListDTO> FindAll();
        void Delete(long id);
        
    }
}
