using Sharpen;

namespace com.esri.core.geometry
{
	public class TestContains : NUnit.Framework.TestCase
	{
		/// <exception cref="System.Exception"/>
		protected override void SetUp()
		{
			base.SetUp();
		}

		/// <exception cref="System.Exception"/>
		protected override void TearDown()
		{
			base.TearDown();
		}

		/// <exception cref="org.codehaus.jackson.JsonParseException"/>
		/// <exception cref="System.IO.IOException"/>
		[NUnit.Framework.Test]
		public static void TestContainsFailureCR186456()
		{
			string str = "{\"rings\":[[[406944.399999999,287461.450000001],[406947.750000011,287462.299999997],[406946.44999999,287467.450000001],[406943.050000005,287466.550000005],[406927.799999992,287456.849999994],[406926.949999996,287456.599999995],[406924.800000005,287455.999999998],[406924.300000007,287455.849999999],[406924.200000008,287456.099999997],[406923.450000011,287458.449999987],[406922.999999987,287459.800000008],[406922.29999999,287462.099999998],[406921.949999991,287463.449999992],[406921.449999993,287465.050000011],[406920.749999996,287466.700000004],[406919.800000001,287468.599999996],[406919.050000004,287469.99999999],[406917.800000009,287471.800000008],[406916.04999999,287473.550000001],[406915.449999993,287473.999999999],[406913.700000001,287475.449999993],[406913.300000002,287475.899999991],[406912.050000008,287477.250000011],[406913.450000002,287478.150000007],[406915.199999994,287478.650000005],[406915.999999991,287478.800000005],[406918.300000007,287479.200000003],[406920.649999997,287479.450000002],[406923.100000013,287479.550000001],[406925.750000001,287479.450000002],[406928.39999999,287479.150000003],[406929.80000001,287478.950000004],[406932.449999998,287478.350000006],[406935.099999987,287477.60000001],[406938.699999998,287476.349999989],[406939.649999994,287473.949999999],[406939.799999993,287473.949999999],[406941.249999987,287473.75],[406942.700000007,287473.250000002],[406943.100000005,287473.100000003],[406943.950000001,287472.750000004],[406944.799999998,287472.300000006],[406944.999999997,287472.200000007],[406946.099999992,287471.200000011],[406946.299999991,287470.950000012],[406948.00000001,287468.599999996],[406948.10000001,287468.399999997],[406950.100000001,287465.050000011],[406951.949999993,287461.450000001],[406952.049999993,287461.300000001],[406952.69999999,287459.900000007],[406953.249999987,287458.549999987],[406953.349999987,287458.299999988],[406953.650000012,287457.299999992],[406953.900000011,287456.349999996],[406954.00000001,287455.300000001],[406954.00000001,287454.750000003],[406953.850000011,287453.750000008],[406953.550000012,287452.900000011],[406953.299999987,287452.299999988],[406954.500000008,287450.299999996],[406954.00000001,287449.000000002],[406953.399999987,287447.950000006],[406953.199999988,287447.550000008],[406952.69999999,287446.850000011],[406952.149999992,287446.099999988],[406951.499999995,287445.499999991],[406951.149999996,287445.249999992],[406950.449999999,287444.849999994],[406949.600000003,287444.599999995],[406949.350000004,287444.549999995],[406948.250000009,287444.499999995],[406947.149999987,287444.699999994],[406946.849999989,287444.749999994],[406945.899999993,287444.949999993],[406944.999999997,287445.349999991],[406944.499999999,287445.64999999],[406943.650000003,287446.349999987],[406942.900000006,287447.10000001],[406942.500000008,287447.800000007],[406942.00000001,287448.700000003],[406941.600000011,287449.599999999],[406941.350000013,287450.849999994],[406941.350000013,287451.84999999],[406941.450000012,287452.850000012],[406941.750000011,287453.850000007],[406941.800000011,287454.000000007],[406942.150000009,287454.850000003],[406942.650000007,287455.6],[406943.150000005,287456.299999997],[406944.499999999,287457.299999992],[406944.899999997,287457.599999991],[406945.299999995,287457.949999989],[406944.399999999,287461.450000001],[406941.750000011,287461.999999998],[406944.399999999,287461.450000001]],[[406944.399999999,287461.450000001],[406947.750000011,287462.299999997],[406946.44999999,287467.450000001],[406943.050000005,287466.550000005],[406927.799999992,287456.849999994],[406944.399999999,287461.450000001]]]}";
			org.codehaus.jackson.JsonFactory jsonFactory = new org.codehaus.jackson.JsonFactory();
			org.codehaus.jackson.JsonParser jsonParser = jsonFactory.CreateJsonParser(str);
			com.esri.core.geometry.MapGeometry mg = com.esri.core.geometry.GeometryEngine.JsonToGeometry(jsonParser);
			bool res = com.esri.core.geometry.GeometryEngine.Contains(mg.GetGeometry(), mg.GetGeometry(), null);
			NUnit.Framework.Assert.IsTrue(res);
		}
	}
}
