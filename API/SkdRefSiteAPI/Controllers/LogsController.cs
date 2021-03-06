﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkdRefSiteAPI.DAO;
using SkdRefSiteAPI.DAO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkdRefSiteAPI.Controllers
{
    /// <summary>
    /// API for working with logs
    /// </summary>
    public class LogsController : BaseController
    {
        private Logger _dao;

        /// <summary>
        /// Constructor
        /// </summary>
        public LogsController()
        {
            _dao = new Logger("LogsController");
        }

        /// <summary>
        /// Gets all the logs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("admin")]
        [Route("api/Logs")]
        public async Task<List<Log>> Get()
        {
            return await _dao.GetAllLogs();
        }

        /// <summary>
        /// Delete a log
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Authorize("admin")]
        [Route("api/Logs/{id}")]
        public bool Delete(string id)
        {
            return _dao.DeleteLog(id);
        }

        /// <summary>
        /// Counts all the logs
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize("admin")]
        [Route("api/Logs/Count")]
        public async Task<int> GetCount()
        {
            return await _dao.CountLogs();
        }
    }
}
