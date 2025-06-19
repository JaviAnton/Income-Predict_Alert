namespace Predict_Alert.Models
{
    public class Income_Data
    {
        public required string Person { get; set; }
        public float Month { get; set; }
        public float Income { get; set; }
    }

    public class Prediction
    {
        public float Predict_income { get; set; }
    }
}