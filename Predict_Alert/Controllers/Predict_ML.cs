using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ML;
using Predict_Alert.Models;
using System;
using System.IO;

namespace Predict_Alert.Controllers 
{
    [ApiController]
    [Route("api/[controller]")]
    public class MLPredict : ControllerBase
    {
        // Define Data routes
        private string data_path = Path.Combine(Environment.CurrentDirectory, "Data", "income_sample.csv");
        private ITransformer model;
        private MLContext mlContext;
        private PredictionEngine<Income_Data, Income_Prediction> prediction_Engine;

        //Class constructor - Initialization
        public MLPredict()
        {
            mlContext = new MLContext(seed: 0);
            model = Train(mlContext, data_path);
            prediction_Engine = mlContext.Model.CreatePredictionEngine<Income_Data, Income_Prediction>(model);
        }

        // HTTP Action-based Prediction
        //[HttpPost("predict")]
        // public ActionResult<float> Predict([FromBody] Income_Data input)
        // {

        //     var prediction = prediction_Engine.Predict(input);
        //     return Ok(new { PredictedIncome = Math.Round(prediction.Predict_income, 2) });
        // }

        [HttpGet("predict")]
        public ActionResult<float> Predict(
            [FromQuery] string person,
            [FromQuery] float month_01_2024,
            [FromQuery] float month_02_2024,
            [FromQuery] float month_03_2024,
            [FromQuery] float month_04_2024,
            [FromQuery] float month_05_2024,
            [FromQuery] float month_06_2024,
            [FromQuery] float month_07_2024,
            [FromQuery] float month_08_2024,
            [FromQuery] float month_09_2024,
            [FromQuery] float month_10_2024,
            [FromQuery] float month_11_2024,
            [FromQuery] float month_12_2024
        )
        {
            var input = new Income_Data
            {
                Person = person,
                Month_01_2024 = month_01_2024,
                Month_02_2024 = month_02_2024,
                Month_03_2024 = month_03_2024,
                Month_04_2024 = month_04_2024,
                Month_05_2024 = month_05_2024,
                Month_06_2024 = month_06_2024,
                Month_07_2024 = month_07_2024,
                Month_08_2024 = month_08_2024,
                Month_09_2024 = month_09_2024,
                Month_10_2024 = month_10_2024,
                Month_11_2024 = month_11_2024,
                Month_12_2024 = month_12_2024
            };

            var prediction = prediction_Engine.Predict(input);
            return Ok(new { PredictedIncome = Math.Round(prediction.Predict_income, 2) });
}
        //ML Training
        ITransformer Train(MLContext mlContext, string DataPath)
        {
            IDataView dataView = mlContext.Data.LoadFromTextFile<Income_Data>(DataPath, hasHeader: true, separatorChar: ',');
            var pipeline = mlContext.Transforms.Concatenate("Features", 
                nameof(Income_Data.Month_01_2024),
                nameof(Income_Data.Month_02_2024),
                nameof(Income_Data.Month_03_2024),
                nameof(Income_Data.Month_04_2024),
                nameof(Income_Data.Month_05_2024),
                nameof(Income_Data.Month_06_2024),
                nameof(Income_Data.Month_07_2024),
                nameof(Income_Data.Month_08_2024),
                nameof(Income_Data.Month_09_2024),
                nameof(Income_Data.Month_10_2024),
                nameof(Income_Data.Month_11_2024),
                nameof(Income_Data.Month_12_2024))
            .Append(mlContext.Regression.Trainers.Sdca(labelColumnName: nameof(Income_Data.Month_01_2025), featureColumnName: "Features"));
            var model = pipeline.Fit(dataView);
            return model;
        }
    }
    
}
