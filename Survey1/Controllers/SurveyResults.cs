using System;
using Dapper;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey1.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;

namespace Survey1.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    [ApiController]
    [Route("[controller]")]


    public class SurveyResults : ControllerBase
    {
        private readonly IConfiguration _config;

        public SurveyResultsController(IConfiguration config)
        {
            _config = config;
        }

        private readonly ILogger<SurveyResults> _logger;

        public SurveyResults(ILogger<SurveyResults> logger)
        {
            _logger = logger;
        }

        [HttpPost]


        public async Task<ActionResult<List<SurveyObject>>> CerateUser(SurveyObject surveyobect)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            await connection.ExecuteAsync("insert into surveyobject ( title, sart, end, description, createdBy) values (@title, @start, @end, @description,@createdBy  )", SurveyObject);
            return Ok(await SelectAllUsers(connection));

        }
        [HttpPut]
        public async Task<ActionResult<List<SurveyObject>>> UpdateUser(SurveyObject surveyobject)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            await connection.ExecuteAsync("update surveyobject set title = @title, stard = @start, end = @end, description = @description, createdBy = @createdBy  where id = @id   ", SurveyObject);
            return Ok(await SelectAllUsers(connection));

        }

        private Task<SurveyObject> SelectAllUsers(SqlConnection connection)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("SurveyID")]


        public async Task<ActionResult<List<SurveyObject>>> DeleteUser(int SurveyID)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            await connection.ExecuteAsync("delete from surveyobjecet  where id = @Id   ", new { Id = SurveyID });
            return Ok(await SelectAllUsers(connection));

        }
        [HttpGet]
        public async Task<ActionResult<List<SurveyQuestions>>> GetAllUsers()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var user = await connection.QueryAsync<SurveyQuestions>("select * from surveyquestions");

            return Ok(surveyquestions);

        }
    }
}
