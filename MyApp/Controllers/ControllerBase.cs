using API.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Utility;

namespace API.Controllers
{
    protected async Task<ActionResult> getResponse(object Data, string Message = "")
    {
        CommonResponseDto response = new CommonResponseDto();
        response.Status = "OK";
        response.Message = Message;
        response.Data = Data;

        return Content(new JSONSerialize().getJSONSFromObject(response, true), "application/json");

        //return Json(response);
    }
}
