using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.DbRepository.Api.Models;
using TracksAggregation = Sample.DbRepository.Domain.Aggregation.Tracks.Requests;
using SearchModels = Sample.DbRepository.Domain.Search.Models;
using GenreSearch = Sample.DbRepository.Domain.Search.Genres.Requests;
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
            Task<IEnumerable<Genre>> taskGenre = GetGenres(skip, take);
            Task<IDictionary<int, int>> taskTrackCount = GetTrackCountByGenre();
            await Task.WhenAll(taskGenre, taskTrackCount);

            var genres = await taskGenre;
            var trackCounts = await taskTrackCount;

            if (genres == null ||
                !genres.Any())
                return NoContent();
            else
                return Ok(AppendTrackCount(genres, trackCounts));
        }

        private async Task<IEnumerable<Genre>> GetGenres(int skip, int take)
        {
            var request = new GenreSearch.Get()
            {
                Skip = skip,
                Take = take,
            };

            var response = await _mediator.Send(request);
            return _mapper.Map<IEnumerable<SearchModels.Genre>, IEnumerable<Genre>>(response);
        }

        private async Task<IDictionary<int, int>> GetTrackCountByGenre()
        {
            var request = new TracksAggregation.GetCountByGenre();
            return await _mediator.Send(request);
        }


        private IEnumerable<Genre> AppendTrackCount(IEnumerable<Genre> genres, IDictionary<int, int> trackCounts)
        {
            foreach(Genre genre in genres)
            {
                genre.Tracks = trackCounts[genre.GenreId];
            }

            return genres;
        }
    }
}
