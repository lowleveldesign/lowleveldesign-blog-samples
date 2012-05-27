using System;
using System.Diagnostics;
using System.ServiceModel;
using LowLevelDesign.Samples;

namespace TinyWcf
{
    [ServiceContract]
    internal interface ITinyService
    {
        [OperationContract]
        int PlaceOrder(String username, String product, decimal cash);
    }

    class TinyService : ITinyService
    {        
        public int PlaceOrder(String username, String product, decimal cash) {
            return new OrderingSystem().PlaceOrder(username, product, cash);
        }
    }
}