using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Images.Queries
{
    public class ImagesQueriesHandler : IRequestHandler<GetImagesByEntityIdQuery, IEnumerable<string>>
    {
        private readonly IApplicationDbContext _context;

        public ImagesQueriesHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        #region Get all entity images

        #region Handler
        public async Task<IEnumerable<string>> Handle(GetImagesByEntityIdQuery request,
            CancellationToken cancellationToken)
        {
            await ChecksHelper.CheckValidation_ThrowExceptionIfQueryIsInvalid<GetImagesByEntityIdQueryValidator,
                  GetImagesByEntityIdQuery>(request, cancellationToken).ConfigureAwait(false);

            await CheckEntityExistence_ThrowExceptionOnNotFound(request.EntityId, request.EntityName)
                .ConfigureAwait(false);

            var images = await _context.FoodBusinessImages.Where(f => f.EntityId == Guid.Parse(request.EntityId))
                .Select(im => im.ImageBytes).ToArrayAsync(cancellationToken).ConfigureAwait(false);

            return images.Select(Convert.ToBase64String);
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

    }
}