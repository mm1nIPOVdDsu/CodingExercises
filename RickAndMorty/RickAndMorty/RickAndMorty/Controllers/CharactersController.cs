namespace RickAndMorty.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using RickAndMorty.Controllers.Models.Characters;
    using RickAndMorty.Domain.Interfaces;
    using RickAndMorty.Services.Interfaces;

    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public sealed class CharactersController : Controller
    {
        private readonly ICharacterService _characterService;
        private readonly ILoggingService _loggingService;

        /// <summary>
        ///     
        /// </summary>
        /// <param name="loggingService"></param>
        /// <param name="characterService"></param>
        public CharactersController(
            ILoggingService loggingService,
            ICharacterService characterService)
        {
            this._loggingService = loggingService;
            this._characterService = characterService;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(GetAllResponse), 200)]
        public async Task<IActionResult> Get()
        {
            var all = await this._characterService.GetAllAsync();
            return this.Ok(all);
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(typeof(CharacterDetailResponse), 200)]
        public async Task<IActionResult> Get(int id)
        {
            var one = await this._characterService.GetByIdAsync(id);
            if (one != null)
            {
                return this.Ok(one);
            }

            return this.NotFound();
        }
    }
}

//namespace RickAndMorty.Controllers
//{
//    using System.Collections.Generic;
//    using System.Reflection;
//    using System.Threading.Tasks;

//    using Microsoft.AspNetCore.Mvc;

//    using RickAndMorty.Controllers.Models.Characters;
//    using RickAndMorty.Domain.Models;
//    using RickAndMorty.Utils;

//    [ApiVersion("1.0")]
//    [Route("api/v{version:apiVersion}/[controller]")]
//    [ApiController]
//    [Produces("application/json")]
//    public sealed class CharactersController : Controller
//    {
//        public CharactersController(
//            IGet<IEnumerable<CharacterModel>> getAll,
//            IGet<int, Character> getOne)
//        {
//            this.GetAll = getAll;
//            this.GetOne = getOne;
//        }

//        public IGet<IEnumerable<Character>> GetAll { get; }

//        public IGet<int, Character> GetOne { get; }

//        [HttpGet]
//        [ProducesResponseType(typeof(GetAllResponse), 200)]
//        public async Task<IActionResult> Get()
//        {
//            var currentMethod = MethodBase.GetCurrentMethod();
//            using (var bench = new ExecutionTimer())
//            {
//                var all = await this.GetAll.Get();
//                return this.Ok(all.ToGetAllResponse());
//            }
//        }

//        [HttpGet("{id}")]
//        [ProducesResponseType(typeof(CharacterDetailResponse), 200)]
//        public async Task<IActionResult> Get(int id)
//        {
//            using (var bench = new ExecutionTimer())
//            {
//                var all = await this.GetOne.Get(id);

//                if (all != null)
//                {
//                    return this.Ok(all.ToCharacterDetailResponse());
//                }

//                return this.NotFound();
//            }
//        }
//    }
//}