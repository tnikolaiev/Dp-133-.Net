using Ras.BLL.DTO;

namespace Ras.BLL
{
    interface IDictionariesStudentService
    {
        DictionariesStudentDTO GetStudentDictionaries(int groupId);
    }
}
