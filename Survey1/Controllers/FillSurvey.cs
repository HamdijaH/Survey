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
    [Authorize(Roles = UserRoles.User)]
    [ApiController]
    [Route("[controller]")]


    public class FillSurvey : ControllerBase
    {
        private readonly IConfiguration _config;

        public FillSurveyController(IConfiguration config)
        {
            _config = config;
        }

        private readonly ILogger<FillSurvey> _logger;
        private object? surveyobject;

        public FillSurvey(ILogger<FillSurvey> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<SurveyObject>>> GetAllUsers()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var user = await connection.QueryAsync<SurveyObject>("select text from surveyobject");

            return Ok(surveyobject);

        } 
        [HttpPost]


        public async Task<ActionResult<List<SurveyQuestions>>> CerateUser(SurveyQuestions surveyquestions)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            await connection.ExecuteAsync("insert into surveyquestions ( text ) values ( @text   )", SurveyQuestions);
            return Ok(await SelectAllUsers(connection));

        }

        private Task<SurveyQuestions> SelectAllUsers(SqlConnection connection)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<ActionResult<List<SurveyQuestions>>> UpdateUser(SurveyQuestions surveyquestions, object surveyQuestions)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            await connection.ExecuteAsync("update surveyquestions set text = @text  where id = @id   ", surveyQuestions);
            return Ok(await SelectAllUsers(connection));

        }

        [HttpDelete("AnswerID")]


        public async Task<ActionResult<List<SurveyQuestions>>> DeleteUser(int AnswerID)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));

            await connection.ExecuteAsync("delete from surveyoquestions  where id = @Id   ", new { Id = AnswerID });
            return Ok(await SelectAllUsers(connection));

        }
        
    }
}
