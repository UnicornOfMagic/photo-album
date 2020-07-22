using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using photo_album;
using Xunit;

namespace photo_album_test
{
    public class PhotoRetrieverTests
    {
        private IPhotoService _photoService = Substitute.For<IPhotoService>();

        [Fact]
        public async void GivenPhotoRetriever_WhenGetPhotosByAlbumId_PhotoServiceIsCalled()
        {
            var called = false;
            _photoService.GetPhotosByAlbumId(default)
                .ReturnsForAnyArgs(
                new List<Photo>
                {
                    new Photo("My Photo", 100)
                })
                .AndDoes(delegate { called = true; });

            var sut = new PhotoRetriever(_photoService);

            var photos = await sut.GetPhotosByAlbumId(123);

            photos.First().Title.Should().Be("My Photo");
            called.Should().BeTrue();
        }

        [Fact]
        public async void GivenPhotoReceiver_WhenGetAllPhotos_PhotoServiceIsCalled()
        {
            var called = false;
            _photoService.GetAllPhotos()
                .ReturnsForAnyArgs(
                new List<Photo>
                {
                    new Photo("My Photo", 100)
                })
                .AndDoes(delegate { called = true; });

            var sut = new PhotoRetriever(_photoService);

            var photos = await sut.GetAllPhotos();

            photos.First().Title.Should().Be("My Photo");
            called.Should().BeTrue();
        }

        [Fact]
        public async void GivenPhotoReceiver_WhenGetPhotoById_PhotoServiceIsCalled()
        {
            var called = false;
            _photoService.GetPhotoById(default)
                .ReturnsForAnyArgs(new Photo("My Photo", 2500))
                .AndDoes(delegate { called = true; });

            var sut = new PhotoRetriever(_photoService);

            var photos = await sut.GetPhotoById(2500);

            photos.Title.Should().Be("My Photo");
            called.Should().BeTrue();
        }
    }
}