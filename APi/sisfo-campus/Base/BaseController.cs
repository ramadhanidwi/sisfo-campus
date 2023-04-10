using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace sisfo_campus.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Key, Entity, Repository> : ControllerBase
        where Entity : class
        where Repository : IRepository<Key, Entity>
    {
        private readonly Repository repository;
        public BaseController(Repository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var result = await repository.GetAll();
                /*return result.Count() is 0
                ? NotFound(new { statusCode = 404, message = "Data Not Found!" })
                : Ok(new { statusCode = 201, message = "Success", data = result });*/
                if (result is null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "Data kosong!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 201,
                        Message = "Data ada!",
                        Data = result
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Something Wrong " + ex.Message,
                });
            }
        }

        //GetById
        [HttpGet]
        [Route("{key}")]
        public async Task<ActionResult> GetById(Key key)
        {
            try
            {
                var result = await repository.GetById(key);
                /*return result is null
                ? NotFound(new { statusCode = 404, message = $"Data With Id {key} Not Found!" })
                : Ok(new { statusCode = 200, message = $"Data Found!", data = result });*/
                if (result is null)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = $"Data With Id {key} Not Found!",
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data ditemukan!",
                        Data = result
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 500,
                    Message = "Something Wrong " + ex.Message,
                });
            }
        }

        [HttpPost]
        public async Task<ActionResult> Insert(Entity entity)
        {
            try
            {
                var result = await repository.Insert(entity);
                /*return result is 0
                ? Conflict(new { statusCode = 409, message = "Data fail to Insert!" })
                : Ok(new { statusCode = 200, message = "Data Saved Succesfully!" });*/
                if (result == null)
                {
                    return Conflict(new
                    {
                        StatusCode = 409,
                        Message = "Data gagal disimpan!"
                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data berhasil disimpan!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Something Wrong " + ex.Message,
                });
            }
        }

        //Update
        [HttpPut]
        public async Task<ActionResult> Update(Entity entity)
        {
            try
            {
                var result = await repository.Update(entity);
                /*return result is 0
                ? NotFound(new { statusCode = 404, message = $"Id not found!" })
                : Ok(new { statusCode = 200, message = "Update Succesfully!" });*/
                if (result == 0)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = "Data gagal diupdate!"
                    });

                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data berhasil diupdate!"
                    });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 500,
                    Message = "Something Wrong " + ex.Message,
                });
            }
        }

        //Delete
        [HttpDelete("{key}")]
        public async Task<ActionResult> Delete(Key key)
        {
            try
            {
                var result = await repository.Delete(key);
                /*return result is 0
                ? NotFound(new { statusCode = 404, message = $"Id {key} Data Not Found" })
                : Ok(new { statusCode = 200, message = "Data Delete Succesfully!" });*/
                if (result is 0)
                {
                    return NotFound(new
                    {
                        StatusCode = 404,
                        Message = $"Id {key} Data tidak ditemukan!"

                    });
                }
                else
                {
                    return Ok(new
                    {
                        StatusCode = 200,
                        Message = "Data berhasil dihapus!",
                    });

                }
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    StatusCode = 400,
                    Message = "Something Wrong " + ex.Message,
                });
            }
        }
    }
}
