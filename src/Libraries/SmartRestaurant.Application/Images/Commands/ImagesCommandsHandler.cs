using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Images.Commands
{
    public class ImagesCommandsHandler :
       IRequestHandler<UploadListOfImagesCommand, Created>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ImagesCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Upload list of images

        #region Handler
        public async Task<Created> Handle(UploadListOfImagesCommand request, CancellationToken cancellationToken)
        {

            await ChecksHelper.CheckValidation_ThrowExceptionIfQueryIsInvalid<UploadListOfImagesCommandValidator,
                    UploadListOfImagesCommand>(request, cancellationToken).ConfigureAwait(false);

            await CheckEntityExistence_ThrowExceptionOnNotFound(request).ConfigureAwait(false);

            AddImagesToFoodBusinessImages(request);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
        #endregion

        #region Add images to FoodBusinessImages
        private void AddImagesToFoodBusinessImages(UploadListOfImagesCommand request)
        {
            foreach (var image in request.Images)
            {
                using (var ms = new MemoryStream())
                {
                    image.CopyTo(ms);
                    var foodBusinessImage = new FoodBusinessImage
                    {
                        EntityId = Guid.Parse(request.EntityId),
                        ImageBytes = ms.ToArray(),
                        ImageTitle = image.FileName,
                        IsLogo = false
                    };
                    _context.FoodBusinessImages.Add(foodBusinessImage);
                }
            }
        }
        #endregion

        #region Check entity existence
        private async Task CheckEntityExistence_ThrowExceptionOnNotFound(UploadListOfImagesCommand request)
        {
            switch (request.EntityName)
            {
                case UploadImagesEntities.FoodBusiness:
                    var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.EntityId)).ConfigureAwait(false);
                    if (foodBusiness == null)
                        throw new NotFoundException(nameof(FoodBusiness), request.EntityId);
                    break;

                case UploadImagesEntities.Zone:
                    var zone = await _context.Zones.FindAsync(Guid.Parse(request.EntityId)).ConfigureAwait(false);
                    if (zone == null)
                        throw new NotFoundException(nameof(Zones), request.EntityId);
                    break;

                case UploadImagesEntities.Table:
                    var table = await _context.Tables.FindAsync(Guid.Parse(request.EntityId)).ConfigureAwait(false);
                    if (table == null)
                        throw new NotFoundException(nameof(Tables), request.EntityId);
                    break;

                case UploadImagesEntities.Menu:
                    var menu = await _context.Menus.FindAsync(Guid.Parse(request.EntityId)).ConfigureAwait(false);
                    if (menu == null)
                        throw new NotFoundException(nameof(Menus), request.EntityId);
                    break;

                case UploadImagesEntities.SubSection:
                    var subSection = await _context.SubSections.FindAsync(Guid.Parse(request.EntityId)).ConfigureAwait(false);
                    if (subSection == null)
                        throw new NotFoundException(nameof(SubSections), request.EntityId);
                    break;

                default:
                    throw new NotFoundException(request.EntityName, request.EntityId);
            }
        }
        #endregion

        #endregion
    }
}