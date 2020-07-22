using System.Linq;
using FluentAssertions;
using photo_album;
using Xunit;

namespace photo_album_test
{
    public class JSonPlaceHolderPhotoServiceTests
    {
        private JSonPlaceHolderPhotoService _sut;
        public JSonPlaceHolderPhotoServiceTests()
        {
            _sut = new JSonPlaceHolderPhotoService();
        }
        
        [Fact]
        public async void GivenPhotoService_WhenGetPhoto1_ThenReturnsPhoto1()
        {
            var photos = await _sut.GetPhotosByAlbumId(1);

            photos.Count().Should().Be(50);
            photos.First().Title.Should().Be("accusamus beatae ad facilis cum similique qui sunt");
            photos.First().Id.Should().Be(1);
            photos.Last().Title.Should().Be("et inventore quae ut tempore eius voluptatum");
            photos.Last().Id.Should().Be(50);
        }
        
        [Fact]
        public async void GivenPhotoService_WhenGetPhotosByAlbumId100_ThenReturnsPhotosInAlbum2()
        {
            var photos = await _sut.GetPhotosByAlbumId(2);

            photos.Count().Should().Be(50);
            photos.First().Title.Should().Be("non sunt voluptatem placeat consequuntur rem incidunt");
            photos.First().Id.Should().Be(51);
            photos.Last().Title.Should().Be("et qui rerum");
            photos.Last().Id.Should().Be(100);
        }

        [Fact]
        public async void GivenPhotoService_WhenGetAllPhotos_ThenReturns5000Photos()
        {
            var photos = await _sut.GetAllPhotos();

            photos.Count().Should().Be(5000);
        }

        [Fact]
        public async void GivenPhotoService_WhenGetPhotoById1_ThenReturnsSinglePhoto()
        {
            var photo = await _sut.GetPhotoById(1);

            photo.Title.Should().Be("accusamus beatae ad facilis cum similique qui sunt");
            photo.Id.Should().Be(1);
        }
    }
}