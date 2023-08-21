using Microsoft.AspNetCore.Mvc;
using RedMango_API.Data;
using RedMango_API.Models;
using RedMango_API.Models.Dto;
using RedMango_API.Services;
using RedMango_API.Utility;
using System.Net;

namespace RedMango_API.Controllers
{
    //if you change the controller name, the route doesn't need to change. 
    [Route("api/MenuItem")]
    [ApiController]
    public class MenuItemController : ControllerBase
    {
        //working with the DB so you need this here
        private readonly ApplicationDBContext _db;
        // "_db" is the var for the db
        //private readonly because you will only be using _db within this controller / class
       

        private ApiResponse _response;
        private readonly IBlobService _blobService;

        public MenuItemController(ApplicationDBContext db, IBlobService blobService)
        {//used dependency injection to access the DBContext
            _db = db;
            //reference the database

            _blobService = blobService;
            //reference the blobservice for file upload

            _response = new ApiResponse();
            //reference the api response class
        }
        //get method to get all menu items
        [HttpGet]

        public async Task<IActionResult> GetMenuItems()
        {
            _response.Result = _db.MenuItems;
            //the result is : get the menu items
            _response.StatusCode = HttpStatusCode.OK;
            //create a 200 ok status
            return Ok(_response);
            //return Ok and respond with the menu Items
        }


        [HttpGet("{id}", Name = "GetMenuItem")]
        //this is the get request by ID
        public async Task<IActionResult> GetItemById(int id)

        {
            if (id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            //create instance of MenuItem called menuItem, go to db, MenuItems, and look for the first result that matches the ID of the menu item or "default" one if none matches the request.  Set this equal to menuItem
            MenuItem menuItem = _db.MenuItems.FirstOrDefault(x => x.Id == id);

            if (menuItem == null)
            {
                //if nothing is passed into the required api call then it returns a 404 not found
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }


            _response.Result = menuItem;
            //the result is : get the menu items
            _response.StatusCode = HttpStatusCode.OK;
            //create a 200 ok status
            return Ok(_response);
            //return Ok and respond with the menu Items  
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveItemById(int id)

        {
            if (id == 0)
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                return BadRequest(_response);
            }

            //create instance of MenuItem called menuItem, go to db, MenuItems, and look for the first result that matches the ID of the menu item or "default" one if none matches the request.  Set this equal to menuItem
            MenuItem menuItem = _db.MenuItems.FirstOrDefault(x => x.Id == id);

            if (menuItem == null)
            {
                //if nothing is passed into the required api call then it returns a 404 not found
                _response.StatusCode = HttpStatusCode.NotFound;
                return NotFound(_response);
            }


            _response.Result = menuItem;
            //the result is : get the menu items
            _response.StatusCode = HttpStatusCode.OK;
            //create a 200 ok status
            return Ok(_response);
            //return Ok and respond with the menu Items  
        }


        [HttpPost]
        //Working with Azure storage and using FromForm becz need to upload menu Item
        public async Task<ActionResult<ApiResponse>> CreateMenuItem([FromForm] MenuItemCreateDTO menuItemCreateDTO)//working with Azure Blob so using async,FromForm - using the azure files for images, CreateDTO since I don't want my api domain objects to directly be seen by external api's
        {
            try
            {
                if (ModelState.IsValid)//required,range,required validates if endpoints are valid
                {
                    //check if uploaded when creating
                    if (menuItemCreateDTO == null || menuItemCreateDTO.File.Length == 0)
                    {
                        return BadRequest("File is required");
                    }

                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(menuItemCreateDTO.File.FileName)}";

                    // need to convert menuItemCreateDTO to MenuItem
                    MenuItem menuItemToCreate = new()
                    {
                        Name = menuItemCreateDTO.Name,
                        Price = menuItemCreateDTO.Price,
                        Category = menuItemCreateDTO.Category,
                        SpecialTag = menuItemCreateDTO.SpecialTag,
                        Description = menuItemCreateDTO.Description,
                        Image = await _blobService.UploadBlob(fileName, SD.SD_Storage_Container, menuItemCreateDTO.File)
                    };
                    _db.MenuItems.Add(menuItemToCreate);
                    //this adds the menu item that is created to the database
                    _db.SaveChanges();
                    //Actually saves the changes made
                    _response.Result = menuItemToCreate;
                    //api response for the menu item created
                    _response.StatusCode = HttpStatusCode.Created;
                    //this item was created
                    return CreatedAtRoute("GetMenuItem", new { id = menuItemToCreate.Id }, _response);

                }
                else
                {
                    _response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }

        /// <summary>
        /// Work on the update portion of API
        /// </summary>
        /// <param name="id"></param>
        /// <param name="menuItemUpdateDTO"></param>
        /// <returns></returns>
        [HttpPut("{id:int}")]
        //Working with Azure storage and using FromForm becz need to upload menu Item
        public async Task<ActionResult<ApiResponse>> UpdateMenuItem(int id, [FromForm] MenuItemUpdateDTO menuItemUpdateDTO)//working with Azure Blob so using async,FromForm - using the azure files for images, CreateDTO since I don't want my api domain objects to directly be seen by external api's
        {
            try
            {
                if (ModelState.IsValid)//required,range,required validates if endpoints are valid
                {
                    //check if uploaded when creating
                    if (menuItemCreateDTO == null || menuItemCreateDTO.File.Length == 0)
                    {
                        return BadRequest("File is required");
                    }

                    string fileName = $"{Guid.NewGuid()}{Path.GetExtension(menuItemCreateDTO.File.FileName)}";

                    // need to convert menuItemCreateDTO to MenuItem
                    MenuItem menuItemToCreate = new()
                    {
                        Name = menuItemCreateDTO.Name,
                        Price = menuItemCreateDTO.Price,
                        Category = menuItemCreateDTO.Category,
                        SpecialTag = menuItemCreateDTO.SpecialTag,
                        Description = menuItemCreateDTO.Description,
                        Image = await _blobService.UploadBlob(fileName, SD.SD_Storage_Container, menuItemCreateDTO.File)
                    };
                    _db.MenuItems.Add(menuItemToCreate);
                    //this adds the menu item that is created to the database
                    _db.SaveChanges();
                    //Actually saves the changes made
                    _response.Result = menuItemToCreate;
                    //api response for the menu item created
                    _response.StatusCode = HttpStatusCode.Created;
                    //this item was created
                    return CreatedAtRoute("GetMenuItem", new { id = menuItemToCreate.Id }, _response);

                }
                else
                {
                    _response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };

            }
            return _response;
        }
    }
}