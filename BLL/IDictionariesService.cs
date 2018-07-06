using Ras.BLL.DTO;

namespace Ras.BLL
{
    public interface IDictionariesService
    {
        DictionariesGroupDTO GetGroupInfoDictionaries();
        DictionariesStudentDTO GetStudentDictionaries();
        DictionariesFeedbackDTO GetFeedbackDictionaries();
    }
}
