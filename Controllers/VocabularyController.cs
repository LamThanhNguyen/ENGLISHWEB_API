using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEB_HOCTIENGANH.Entities;
using WEB_HOCTIENGANH.Interfaces;

namespace WEB_HOCTIENGANH.Controllers
{
    public class VocabularyController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public VocabularyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [Authorize(Policy = "RequireAdminRole")]
        [HttpPost("create")]
        public async Task<ActionResult<Vocabulary>> CreateVocabulary(Vocabulary vocabulary)
        {
            if (await _unitOfWork.VocabularyRepository.VocabularyExists(vocabulary.EngName))
            {
                return BadRequest("Đã tồn tại.");
            }

            vocabulary.EngName = vocabulary.EngName.ToLower();

            _unitOfWork.VocabularyRepository.AddVocabularyAsync(vocabulary);

            if (await _unitOfWork.Complete())
            {
                return Ok();
            }

            return BadRequest("Failed to add");
        }
    }
}
