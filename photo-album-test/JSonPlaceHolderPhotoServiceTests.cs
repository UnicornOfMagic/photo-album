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
            var photos = (await _sut.GetPhotosByAlbumId(1)).ToList();

            photos.Count.Should().Be(50);
            photos.First().Title.Should().Be("accusamus beatae ad facilis cum similique qui sunt");
            photos.First().Id.Should().Be(1);
            photos.Last().Title.Should().Be("et inventore quae ut tempore eius voluptatum");
            photos.Last().Id.Should().Be(50);
        }
        
        [Fact]
        public async void GivenPhotoService_WhenGetPhotosByAlbumId100_ThenReturnsPhotosInAlbum2()
        {
            var photos = (await _sut.GetPhotosByAlbumId(2)).ToList();

            photos.Count.Should().Be(50);
            photos.First().Title.Should().Be("non sunt voluptatem placeat consequuntur rem incidunt");
            photos.First().Id.Should().Be(51);
            photos.Last().Title.Should().Be("et qui rerum");
            photos.Last().Id.Should().Be(100);
        }
    }
}