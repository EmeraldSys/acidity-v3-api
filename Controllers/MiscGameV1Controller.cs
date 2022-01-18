/*
 * Acidity V3 Backend - MiscGame V1 Controller
 * Copyright (c) 2022 EmeraldSys, all rights reserved.
*/

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using MongoDB.Bson;
using MongoDB.Driver;

namespace AcidityV3Backend.Controllers
{
    [Route("v1/miscgame")]
    [ApiController]
    public class MiscGameV1Controller : ControllerBase
    {
        private MongoClient client;

        public MiscGameV1Controller()
        {
            MongoClientSettings settings = MongoClientSettings.FromConnectionString(Environment.GetEnvironmentVariable("MONGODB_AUTH_STR"));
            client = new MongoClient(settings);
        }

        [HttpPost("rbxuser/batch")]
        public async Task<IActionResult> RBXUserBatch([FromBody]int[] users)
        {
            IMongoDatabase database = client.GetDatabase("aciditydb");
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("rbx");

            List<dynamic> userList = new List<dynamic>();

            using (HttpClient client = new HttpClient())
            {
                for (int i = 0; i < users.Length; i++)
                {
                    int user = users[i];
                    try
                    {
                        client.BaseAddress = new Uri("https://users.roblox.com");
                        string ret = await client.GetStringAsync($"/v1/users/{user}");
                        MemoryStream mem = new MemoryStream();
                        StreamWriter writer = new StreamWriter(mem);
                        writer.Write(ret);
                        writer.Flush();
                        Models.RBXUserModel rbxUser = await JsonSerializer.DeserializeAsync<Models.RBXUserModel>(mem);
                        writer.Close();

                        BsonDocument result = collection.Find(new BsonDocument { { "id", user } }).FirstOrDefault();

                        dynamic userObj = new ExpandoObject();
                        userObj.Id = user;
                        userObj.Name = rbxUser.Name;
                        userObj.Dev = result != null && result.Contains("dev") && result["dev"].IsBoolean ? result["dev"].AsBoolean : false;
                        userObj.Admin = result != null && result.Contains("admin") && result["admin"].IsBoolean ? result["dev"].AsBoolean : false;

                        userList.Add(userObj);
                    }
                    catch (Exception)
                    {
                        client.Dispose();
                        return StatusCode(500);
                    }
                }

                client.Dispose();
            }

            return Ok(new { Status = "OK", Data = userList });
        }
    }
}
