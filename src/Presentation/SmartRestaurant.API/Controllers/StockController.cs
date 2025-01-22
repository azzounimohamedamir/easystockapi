using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Swagger.Exception;
using SmartRestaurant.Application.Common.Dtos;
using Swashbuckle.AspNetCore.Annotations;
using System;
using SmartRestaurant.Application.Stock.Commands;
using SmartRestaurant.Application.Stock.Queries;
using Microsoft.AspNetCore.Http;
using System.IO;
using SmartRestaurant.Application.GestionStock.Stock.Commands;
using SmartRestaurant.Application.Rapports.MvtStock.Queries;
using System.Collections.Generic;
using SmartRestaurant.Application.Menus.Queries;
using System.Linq;
using Newtonsoft.Json;
using SmartRestaurant.Application.GestionVentes.VenteParBl.Queries;
using SmartRestaurant.Application.GestionStock.Stock.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/stocks")]
    [ApiController]
    [SwaggerTag("List of actions that can be applied on Stock")]
    public class StockController : ApiController
    {
        /// <summary> GetAllStock() </summary>
        /// <remarks>This endpoint allows us to fetch list of Buildings of Current Hotel </remarks>
        /// <response code="200"> Buildings list has been successfully fetched.<br></br></response>
        /// <response code="400">The payload data sent to the backend-server in order to fetch building list is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpGet]
        public async Task<IActionResult> GetAllStockList(
        string currentFilter,
        string filterCategory,
        int page,
        int pageSize,
        string filterCriteriaData) // Accept as a JSON string
        {
            // Parse filterCriteriaData from JSON string
            var parsedFilterCriteriaData = !string.IsNullOrEmpty(filterCriteriaData)
                ? JsonConvert.DeserializeObject<List<AttributesWithTheirValuesDto>>(filterCriteriaData)
                : new List<AttributesWithTheirValuesDto>();

            return await SendWithErrorsHandlingAsync(new GetStockListQuery
            {
                Page = page,
                PageSize = pageSize,
                CurrentFilter = currentFilter,
                FilterCategory = filterCategory,
                FilterCriteriaData = parsedFilterCriteriaData
            });
        }






        [HttpGet]
        [Route("allproduits")]
        public async Task<IActionResult> GetAllStockListNoPagine()
        {
            return await SendWithErrorsHandlingAsync(new GetAllStockListQuery
            {

               
            });
        }


      

        [HttpGet("{categoryId}/attributes")]
        public async Task<ActionResult<List<ProductAttributeDto>>> GetAttributesByCategory(Guid categoryId)
        {
            var result = await SendWithErrorsHandlingAsync(new GetProductAttributesByIdCatQuery(categoryId));
            return Ok(result);
        }

        [HttpGet]
        [Route("caisseStats/{startDate:datetime}/{endDate:datetime}")]
        public async Task<IActionResult> GetCaisseStats([FromRoute] DateTime? startDate, [FromRoute] DateTime? endDate)
        {
            return await SendWithErrorsHandlingAsync(new GetCaisseStatsQuery
            {
                StartDate = startDate ?? DateTime.MinValue,
                EndDate = endDate ?? DateTime.Now
            });
        }

        [HttpGet]
        [Route("mvtstocks")]
        public async Task<IActionResult> GetAllMvtStockList(string currentFilter, int page, int pageSize , int type , DateTime dateDebut , DateTime dateFin)
        {
            return await SendWithErrorsHandlingAsync(new GetMvtStockListQuery
            {

                Page = page,
                PageSize = pageSize,
                CurrentFilter = currentFilter,
                 Type = type ,
                 DateDebut=dateDebut,
                 DateFin=dateFin
                
            });
        }

        /// <summary> AddNewProduct To Stock() </summary>
        /// <remarks>
        /// </remarks> 
        /// <param name="command">This is payload object used to create a new building</param>
        /// <response code="204">The building has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [ProducesResponseType(typeof(ExceptionResponse), 400)]
        [HttpPost]
       // [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SuperAdmin,SupportAgent")]
        public async Task<IActionResult> Create([FromForm] CreateProductOnStockCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }


        /// <summary> Import Data To Stock() </summary>
        /// <remarks>
        /// </remarks> 
        /// <param name="command">This is payload object used to create a new building</param>
        /// <response code="204">The building has been successfully created.</response>
        /// <response code="400">The payload data sent to the backend-server in order to create a new building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [HttpPost("import")]
        public async Task<IActionResult> ImportStocks(IFormFile file)
        {
            if (file == null || file.Length <= 0)
            {
                return BadRequest("Invalid file");
            }

            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var command = new ImportStockFromExcelCommand
            {
                ExcelFileData = memoryStream.ToArray()
            };

            return await SendWithErrorsHandlingAsync(command);

        }
            /// <summary> UpdateBuilding() </summary>
            /// <remarks>
            ///     This endpoint allows SM user to update building.<br></br>
            /// </remarks>
            /// <param name="id">id of the building that would be updated</param>
            /// <param name="command">This is the payload object used to update building</param>
            /// <response code="204">The building has been successfully updated.</response>
            /// <response code="400">The payload data sent to the backend-server in order to update a building is invalid.</response>
            /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
            /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
            [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> Update([FromForm] UpdateProductOnStockCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
        [HttpPut]
        [Route("addToFav/{id:guid}")]
        public async Task<IActionResult> AddToFavoris([FromForm] AddProductToFavorite command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
        /// <summary> DeleteBuilding() </summary>
        /// <remarks>This endpoint allows <b>Food Business Manager</b> to delete Building.</remarks>
        /// <param name="id">id of the building that would be deleted</param>
        /// <response code="204">The building has been successfully deleted.</response>
        /// <response code="400">The payload data sent to the backend-server in order to delete a building is invalid.</response>
        /// <response code="401">The cause of 401 error is one of two reasons: Either the user is not logged into the application or authentication token is invalid or expired.</response>
        /// <response code="403"> The user account you used to log into the application, does not have the necessary privileges to execute this request.</response>
        [Route("{id:guid}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteProductFromStockCommand { Id = id });
        }

        [HttpGet("{codeBar}")]
        public async Task<IActionResult> GetFacByid([FromRoute] string codeBar)
        {
            return await SendWithErrorsHandlingAsync(new GetProductByCodebarQuery { CodeBar = codeBar });
        }
    }
}