using Ras.BLL.DTO;

namespace Ras.BLL
{
    public interface IDictionariesStudentService
    {
        DictionariesStudentDTO GetStudentDictionaries(int groupId);
    }
}