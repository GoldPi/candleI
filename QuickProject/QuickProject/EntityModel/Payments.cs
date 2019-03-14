namespace EntityModel
{
    public class Payments:BaseEntity<string>
    {
        public string TranscationId { get; set; }
        public string StudentId { get; set; }
        public Student Student { get; set; }
        public double PaidAmount { get; set; }
        public Transcation Transcation { get; set; }
        
        public PaymentType PaymentType { get; set; }
    }
    /*

PaidAmount	double
Transaction	Transaction
Summary	string
PaymentType	FEE-PAID,OTHER,FEE-REFUND,APPLICATION

     */


}
