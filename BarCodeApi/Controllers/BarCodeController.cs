using Azure.Core;
using BarCodeApi.Interface;
using BarCodeApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace BarCodeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BarCodeController : Controller
    {
        private readonly CoreDbContext barcodeContext;
        private IBarCode ibarcode;
        public BarCodeController(CoreDbContext barcodeContext, IBarCode ibarcode)
        {
            this.barcodeContext = barcodeContext;
            this.ibarcode = ibarcode;
        }

        //get all users
        [HttpGet("GetAllBarCodes")]
        public async Task<ActionResult> GetAllBarCodes()
        {
            try
            {
                var barcode = ibarcode.GetAllBarCode();
                if (barcode.Succeeded)
                {
                    return Ok(barcode.Data);
                }
                return NotFound("barcodes not found");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        [HttpPost("UpdateItemEntry")]
        public async Task<ActionResult> UpdateItemTyEntry(int count, int id)
        {
            try
            {
                var _upd = await ibarcode.UpdateItemEntry(count, id);
                if (_upd.Succeeded)
                {
                    return Ok(_upd.Data);
                }
                else
                {
                    return Ok(_upd);
                }
                throw new Exception(_upd.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return NotFound("problem with update");
        }

        [HttpGet("GetSingleBarcode")]
        public async Task<ActionResult> GetSingleBarcode(int barid)
        {
            try{

                var comp = ibarcode.GetSingleBarcode(barid);
                if (comp.Succeeded)
                {
                    return Ok(comp.Data);
                }
                return NotFound("User not found");
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           

        }

        [HttpPost("AddBarcode")]
        public async Task<ActionResult> AddBarcode(Barcode request)
        {
            try
            {

                var _com = await ibarcode.AddBarcodeAsync(request);
                if (_com.Succeeded)
                {
                    return Ok(_com);
                }
                else
                {
                    return Ok(_com);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }


            return NotFound();
        }
    }


}


