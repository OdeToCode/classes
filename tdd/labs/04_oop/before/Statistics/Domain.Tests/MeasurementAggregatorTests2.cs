using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Domain.Tests
{
    //[TestClass]
    //public class When_aggregating_four_measurements2
    //{
    //    [TestMethod]
    //    public void grouping_by_4_should_produce_single_result()
    //    {
    //        var aggregator = new MeasurementAggregator2(_data);
    //        var result = aggregator.Aggregate(new SizeGroupingStrategy(4), 
    //                                          new AveragingCalculator());
    //        Assert.AreEqual(1, result.Count());
    //    }

    //    [TestMethod]
    //    public void grouping_by_2_should_produce_two_results()
    //    {
    //        var aggregator = new MeasurementAggregator2(_data);
    //        var result = aggregator.Aggregate(new SizeGroupingStrategy(2),
    //                                          new AveragingCalculator());
    //        Assert.AreEqual(2, result.Count());
    //    }

    //    [TestMethod]
    //    public void averaging_should_calculate_average_high_andlow_values()
    //    {
    //        var aggregator = new MeasurementAggregator2(_data);
    //        var result = aggregator.Aggregate(new SizeGroupingStrategy(2),
    //                                          new AveragingCalculator());

    //        var first = result.ElementAt(0);
    //        Assert.AreEqual(7.5, first.HighValue, 0.005);
    //        Assert.AreEqual(1.5, first.LowValue, 0.005);

    //        var second = result.ElementAt(1);
    //        Assert.AreEqual(6.0, second.HighValue, 0.005);
    //        Assert.AreEqual(2.5, second.LowValue, 0.005);
    //    }

    //    [TestMethod]
    //    public void mode_should_calculate_average_high_and_low_values()
    //    {
    //        var aggregator = new MeasurementAggregator2(_data);
    //        var result = aggregator.Aggregate(new SizeGroupingStrategy(4),
    //                                          new ModalCalculator());

    //        var first = result.ElementAt(0);
    //        Assert.AreEqual(10.0, first.HighValue, 0.005);
    //        Assert.AreEqual(1.0, first.LowValue, 0.005);
    //    }

    //    private readonly List<Measurement> _data = new List<Measurement>
    //                   {
    //                       new Measurement() {HighValue = 10.0, LowValue = 1.0},
    //                       new Measurement() {HighValue = 5.0, LowValue = 2.0},
    //                       new Measurement() {HighValue = 2.0, LowValue = 1.0},
    //                       new Measurement() {HighValue = 10.0, LowValue = 4.0}
    //                   };
    //}
}