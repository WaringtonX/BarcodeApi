using BarCodeApi.Interface;
using BarCodeApi.Models;
using BarCodeApi.Wrappers;

namespace BarCodeApi.Implementation
{
    public class BarcodeService : IBarCode
    {
        private readonly CoreDbContext barcodeContext;
        public BarcodeService(CoreDbContext barcodeContext)
        {
            this.barcodeContext = barcodeContext;
        }

        public Response<List<Barcode>> GetAllBarCode()
        {
            List<Barcode> barcode = new List<Barcode>();
            barcode.AddRange(barcodeContext.Barcodes.OrderByDescending(x => x.BarId).ToList());

            if (barcode != null)
            {
                return new Response<List<Barcode>>(barcode);
            }
            return new Response<List<Barcode>>(barcode);
        }

        public async Task<Response<string>> AddBarcodeAsync(Barcode request)
        {
            var barcode = new Barcode
            {
                BarCode1 = request.BarCode1,
                BarName = request.BarName,
                BarItemcount = request.BarItemcount,
                BarCreatedate = DateTime.Now
            };

            var _barcode = await barcodeContext.Barcodes.AddAsync(barcode);
            await barcodeContext.SaveChangesAsync();

            var _barcode_id = barcodeContext.Barcodes.Where(x => x.BarId == barcode.BarId).FirstOrDefault();

            return new Response<string>(_barcode_id.BarId+"", $"Barcode Added");
        }

        public Response<Barcode> GetSingleBarcode(int id)
        {
            Barcode barcode = new Barcode();
            var compvar = barcodeContext.Barcodes.
                Where(x => x.BarId == id).FirstOrDefault();

            barcode = compvar;
            if (barcode != null)
            {
                return new Response<Barcode>(barcode);
            }
            return new Response<Barcode>(barcode);
        }

        public async Task<Response<int>> UpdateItemEntry(int itemcount, int id)
        {
            try
            {
                var _barcode = await barcodeContext.Barcodes.FindAsync(id);
                if (_barcode == null) { throw new Exception("barcode does not exist"); }
                _barcode.BarItemcount = itemcount;

                barcodeContext.Update(_barcode);
                barcodeContext.SaveChanges();

                return new Response<int>(id, "barcodupdated");
            }
            catch (Exception ex)
            {
                return new Response<int>(ex.Message, ex.Message);
            }
            throw new Exception("error while saving");
        }

    }
}
