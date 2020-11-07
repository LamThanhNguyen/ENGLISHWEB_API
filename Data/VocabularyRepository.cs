using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_HOCTIENGANH.Entities;
using WEB_HOCTIENGANH.Interfaces;

namespace WEB_HOCTIENGANH.Data
{
    public class VocabularyRepository : IVocabularyRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public VocabularyRepository(DataContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public void AddVocabularyAsync(Vocabulary vocabulary)
        {
            _context.Vocabularies.Add(vocabulary);
        }

        public void DeleteVocabulary(Vocabulary vocabulary)
        {
            _context.Vocabularies.Remove(vocabulary);
        }

        public async Task<IEnumerable<Vocabulary>> GetVocabularies()
        {
            return await _context.Vocabularies.ToListAsync();
        }

        public async Task<Vocabulary> GetVocabularyById(int id)
        {
            return await _context.Vocabularies.FindAsync(id);
        }

        public async Task<Vocabulary> GetVocabularyByEngName(string engname)
        {
            return await _context.Vocabularies.SingleOrDefaultAsync(x => x.EngName == engname.ToLower());
        }

        public void UpdateVocabulary(Vocabulary vocabulary)
        {
            _context.Entry(vocabulary).State = EntityState.Modified;
        }

        public async Task<bool> VocabularyExists(string engname)
        {
            return await _context.Vocabularies.AnyAsync(x => x.EngName == engname.ToLower());
        }
    }
}
