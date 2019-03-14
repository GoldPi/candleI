using System;

namespace EntityModel
{
    public class Transcation : BaseEntity<string>
    {
        public string PaymentGateWay { get; set; }
        public DateTime TranscationDate { get; set; }
        public double Amount { get; set; }
        public string Response { get; set; }
        public bool Succeeded { get; set; }
        public bool IsRefund { get; set; }

    }



}
