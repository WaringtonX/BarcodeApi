using BarCodeApi.Models;
using BarCodeApi.Wrappers;

namespace BarCodeApi.Interface
{
    public interface IBarCode
    {
        public Response<List<Barcode>> GetAllBarCode();

        public Task<Response<string>> AddBarcodeAsync(Barcode request);

        public Response<Barcode> GetSingleBarcode(int id);

        public  Task<Response<int>> UpdateItemEntry(int itemcount, int id);
    }
}
