using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.DbRepository.Api.Models;
using SearchModels = Sample.DbRepository.Domain.Search.Models;
using GenreSearch = Sample.DbRepository.Domain.Search.Genres.Requests;
using TracksSearch = Sample.DbRepository.Domain.Search.Tracks.Requests;
using Microsoft.AspNetCore.Authorization;

namespace Sample.DbRepository.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class GenresController : ControllerBase
    {
        private readonly ILogger<GenresController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GenresController(ILogger<GenresController> logger,
                                IMediator mediator,
                                IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Genre>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll([FromQuery] int skip = 0,
                                                [FromQuery] int take = 10)
        {
            var genres = await GetGenres(skip, take);
            var tracks = await GetTracks(genres);

            if (genres == null ||
                !genres.Any())
                return NoContent();
            else
                return Ok(AppendTrackCount(genres, tracks));
        }

        private async Task<IEnumerable<Genre>> GetGenres(int skip, int take)
        {
            var request = new GenreSearch.GetAll()
            {
                Skip = skip,
                Take = take,
            };

            var response = await _mediator.Send(request);
            return _mapper.Map<IEnumerable<SearchModels.Genre>, IEnumerable<Genre>>(response);
        }

        private async Task<IEnumerable<SearchModels.AlbumTrack>> GetTracks(IEnumerable<Genre> genres)
        {
            var request = new TracksSearch.FindByGenres() { GenreIds = genres.Select(x => x.GenreId).ToArray() };
            return await _mediator.Send(request);
        }


        private IEnumerable<Genre> AppendTrackCount(IEnumerable<Genre> genres, IEnumerable<SearchModels.AlbumTrack> tracks)
        {
            foreach (Genre genre in genres)
            {
                genre.Tracks = tracks.Where(x => x.GenreId == genre.GenreId).Count();
            }

            return genres;
        }
    }
}
