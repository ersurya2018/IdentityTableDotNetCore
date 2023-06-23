using IdentityTable.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsAppApi;

namespace IdentityTable.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhatshopNotificationController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendMessage(WhatshopModel model)
        {
            try
            {
                string from = "6386513958";
                WhatsApp wa = new WhatsApp(from, "863802068773501/73", model.Name);
                wa.OnConnectSuccess += () =>
                {
                    wa.SendMessage(model.MobileNo, model.Message);
                };
                return Ok("Sended");
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
            
        }
    }
}
