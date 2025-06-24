using Microsoft.ML.Data;

namespace Predict_Alert.Models
{
    public class Income_Data
    {
        [LoadColumn(0)]
        public required string? Person { get; set; }

        [LoadColumn(1)]
        public float Month_01_2024 { get; set; }
         [LoadColumn(2)]
        public float Month_02_2024 { get; set; }

        [LoadColumn(3)]
        public float Month_03_2024 { get; set; }

        [LoadColumn(4)]
        public float Month_04_2024 { get; set; }

        [LoadColumn(5)]
        public float Month_05_2024 { get; set; }

        [LoadColumn(6)]
        public float Month_06_2024 { get; set; }

        [LoadColumn(7)]
        public float Month_07_2024 { get; set; }

        [LoadColumn(8)]
        public float Month_08_2024 { get; set; }

        [LoadColumn(9)]
        public float Month_09_2024 { get; set; }

        [LoadColumn(10)]
        public float Month_10_2024 { get; set; }

        [LoadColumn(11)]
        public float Month_11_2024 { get; set; }

        [LoadColumn(12)]
        public float Month_12_2024 { get; set; }

        [LoadColumn(13)]
        public float Month_01_2025 { get; set; }
    }

    public class Income_Prediction
    {
        public float Predict_income { get; set; }
    }
}