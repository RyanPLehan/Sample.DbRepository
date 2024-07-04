using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.DbRepository.Api.Models;
using TracksAggregate = Sample.DbRepository.Domain.Aggregate.Albums.Requests;
using AggregateModels = Sample.DbRepository.Domain.Aggregate.Models;
using SearchModels = Sample.DbRepository.Domain.Search.Models;
using AlbumSearch = Sample.DbRepository.Domain.Search.Albums.Requests;
using Microsoft.AspNetCore.Authorization;

namespace Sample.DbRepository.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class AlbumsController : ControllerBase
    {
        private readonly ILogger<AlbumsController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AlbumsController(ILogger<AlbumsController> logger,
                                IMediator mediator,
                                IMapper mapper)
        {
            _logger = logger;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Album>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAll([FromQuery] int skip = 0,
                                                [FromQuery] int take = 10)
        {
            var albumArtistsRequest = new AlbumSearch.GetAll() { Skip = skip, Take = take, };
            var albumArtists = await _mediator.Send(albumArtistsRequest);

            if (albumArtists == null || !albumArtists.Any())
                return NoContent();
            else
                return Ok(albumArtists.Select(x => new { AlbumId = x.AlbumId, Title = x.AlbumTitle }));
        }

        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(IEnumerable<Album>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            if (id <= 0)
                return NotFound();


            Task<Album> taskAlbum = GetAlbum(id);
            Task<AggregateModels.AlbumStatistic> taskAlbumStat = GetAlbumStatistic(id);
            await Task.WhenAll(taskAlbum, taskAlbumStat);

            var album = await taskAlbum;
            var albumStat = await taskAlbumStat;

            if (album == null)
                return NoContent();
            else
                return Ok(_mapper.Map<AggregateModels.AlbumStatistic, Album>(albumStat, album));
        }


        private async Task<Album> GetAlbum(int id)
        {
            var request = new AlbumSearch.FindByAlbum() { AlbumId = id };
            var response = await _mediator.Send(request);
            return _mapper.Map<SearchModels.AlbumArtist, Album>(response);
        }


        private async Task<AggregateModels.AlbumStatistic> GetAlbumStatistic(int albumId)
        {
            var request = new TracksAggregate.CalcStatisticByAlbum() { AlbumId = albumId };
            return await _mediator.Send(request);
        }
    }
}
