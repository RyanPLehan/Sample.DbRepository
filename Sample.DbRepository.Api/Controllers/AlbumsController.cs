using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sample.DbRepository.Api.Models;
using TracksAggregation = Sample.DbRepository.Domain.Aggregation.Tracks.Requests;
using AggregationModels = Sample.DbRepository.Domain.Aggregation.Models;
using ManageModels = Sample.DbRepository.Domain.Management.Models;
using SearchModels = Sample.DbRepository.Domain.Search.Models;
using AlbumSearch = Sample.DbRepository.Domain.Search.Albums.Requests;
using AlbumManage = Sample.DbRepository.Domain.Management.Albums.Requests;
using ArtistManage = Sample.DbRepository.Domain.Management.Artists.Requests;
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
            var albumsRequest = new AlbumSearch.Get()
            {
                Skip = skip,
                Take = take,
            };

            var albumsResponse = await _mediator.Send(albumsRequest);

            if (albumsResponse == null ||
                !albumsResponse.Any())
                return NoContent();
            else
            {
                var response = _mapper.Map<IEnumerable<SearchModels.Album>, IEnumerable<Album>>(albumsResponse);
                return Ok(response.Select(x => new { AlbumId = x.AlbumId, Title = x.Title }));
            }
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
            Task<AggregationModels.AlbumStatistic> taskAlbumStat = GetAlbumStatistic(id);
            await Task.WhenAll(taskAlbum, taskAlbumStat);

            var album = await taskAlbum;

            if (album == null)
                return NoContent();
            else
            {
                var artist = await GetArtist(album.ArtistId);
                _mapper.Map<ManageModels.Artist, Album>(artist, album);
                return Ok(_mapper.Map<AggregationModels.AlbumStatistic, Album>(await taskAlbumStat, album));
            }
        }


        private async Task<Album> GetAlbum(int id)
        {
            var request = new AlbumManage.Get() { Id = id };
            var response = await _mediator.Send(request);
            return _mapper.Map<ManageModels.Album, Album>(response);
        }


        private async Task<AggregationModels.AlbumStatistic> GetAlbumStatistic(int albumId)
        {
            var request = new TracksAggregation.GetAlbumStatistic() { AlbumId = albumId };
            return await _mediator.Send(request);
        }

        private async Task<ManageModels.Artist> GetArtist(int artistId)
        {
            var request = new ArtistManage.Get() { Id = artistId };
            return await _mediator.Send(request);
        }
    }
}
