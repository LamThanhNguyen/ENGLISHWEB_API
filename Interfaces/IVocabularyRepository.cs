using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_HOCTIENGANH.Entities;
using WEB_HOCTIENGANH.Helpers;

namespace WEB_HOCTIENGANH.Interfaces
{
    public interface IVocabularyRepository
    {
        void AddVocabularyAsync(Vocabulary vocabulary);
        Task<Vocabulary> GetVocabularyById(int id);
        Task<Vocabulary> GetVocabularyByEngName(string engname);
        Task<IEnumerable<Vocabulary>> GetVocabularies();
        void UpdateVocabulary(Vocabulary vocabulary);
        void DeleteVocabulary(Vocabulary vocabulary);
        Task<bool> VocabularyExists(string engname);
    }
}
