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
       IRequestHandler<UploadListOfImagesCommand, Created>,
       IRequestHandler<UploadLogoCommand, Created>

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

            await CheckEntityExistence_ThrowExceptionOnNotFound(request.EntityId,request.EntityName).ConfigureAwait(false);

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
        private async Task CheckEntityExistence_ThrowExceptionOnNotFound(string entityId, string entityName)
        {
            switch (entityName)
            {
                case UploadImagesEntities.FoodBusiness:
                    var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(entityId)).ConfigureAwait(false);
                    if (foodBusiness == null)
                        throw new NotFoundException(nameof(FoodBusiness), entityId);
                    break;

                case UploadImagesEntities.Zone:
                    var zone = await _context.Zones.FindAsync(Guid.Parse(entityId)).ConfigureAwait(false);
                    if (zone == null)
                        throw new NotFoundException(nameof(Zones), entityId);
                    break;

                case UploadImagesEntities.Table:
                    var table = await _context.Tables.FindAsync(Guid.Parse(entityId)).ConfigureAwait(false);
                    if (table == null)
                        throw new NotFoundException(nameof(Tables), entityId);
                    break;

                case UploadImagesEntities.Menu:
                    var menu = await _context.Menus.FindAsync(Guid.Parse(entityId)).ConfigureAwait(false);
                    if (menu == null)
                        throw new NotFoundException(nameof(Menus), entityId);
                    break;

                case UploadImagesEntities.SubSection:
                    var subSection = await _context.SubSections.FindAsync(Guid.Parse(entityId)).ConfigureAwait(false);
                    if (subSection == null)
                        throw new NotFoundException(nameof(SubSections), entityId);
                    break;

                default:
                    throw new NotFoundException(entityName, entityId);
            }
        }
        #endregion

        #endregion



        #region Handler
        public async Task<Created> Handle(UploadLogoCommand request, CancellationToken cancellationToken)
        {
            await ChecksHelper.CheckValidation_ThrowExceptionIfQueryIsInvalid<UploadLogoCommandValidator,
                    UploadLogoCommand>(request, cancellationToken).ConfigureAwait(false);

            await CheckEntityExistence_ThrowExceptionOnNotFound(request.EntityId, request.EntityName).ConfigureAwait(false);

            AddLogoToFoodBusinessImages(request);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
        #endregion

        #region Add logo to FoodBusinessImages
        private void AddLogoToFoodBusinessImages(UploadLogoCommand request)
        {            
                using (var ms = new MemoryStream())
                {
                    request.logo.CopyTo(ms);
                    var foodBusinessImage = new FoodBusinessImage
                    {
                        EntityId = Guid.Parse(request.EntityId),
                        ImageBytes = ms.ToArray(),
                        ImageTitle = request.logo.FileName,
                        IsLogo = true
                    };
                    _context.FoodBusinessImages.Add(foodBusinessImage);
                }
        }
        #endregion
    }
}