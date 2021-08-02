using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TATA.Business.Interface;
using TATA.Infraestructure.DTO;
using TATA.UI.Models;

namespace TATA.UI.Controllers
{
    public class HomeController : Controller
    {
        #region Member
        private readonly ILogger<HomeController> _logger;
        private readonly ILogResultBusiness _business;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public HomeController(ILogger<HomeController> logger,
                             ILogResultBusiness business,
                             IMapper mapper)
        {
            _logger = logger;
            _business = business;
            _mapper = mapper;
        }
        #endregion

        #region Methods
        public IActionResult Index() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LogResultViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["message"] = "sucedio un inconveniente con los datos";
                return View();
            }
            //LogResultDTO logResultDTO = _mapper.Map<LogResultDTO>(model);
            LogResultDTO logResultDTO = new LogResultDTO(){
            Sentence = model.Sentence
            };
            List<DetailsLogDTO> detailsLogs = _business.GetDuplicates(logResultDTO);
            model.details = detailsLogs;
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        } 
        #endregion
    }
}
