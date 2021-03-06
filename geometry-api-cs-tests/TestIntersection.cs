using NUnit.Framework;

namespace com.esri.core.geometry
{
	public class TestIntersection : NUnit.Framework.TestFixtureAttribute
	{
		internal static com.esri.core.geometry.OperatorFactoryLocal projEnv = com.esri.core.geometry.OperatorFactoryLocal.GetInstance();

		internal static int codeIn = 26910;

		internal static int codeOut = 32610;

		internal static com.esri.core.geometry.SpatialReference inputSR;

		internal static com.esri.core.geometry.SpatialReference outputSR;

		//import java.util.Random;
		// NAD_1983_UTM_Zone_10N : GCS 6269
		// WGS_1984_UTM_Zone_10N; : GCS 4326
		/// <exception cref="System.Exception"/>
		[SetUp]
        protected void SetUp()
		{
			
			projEnv = com.esri.core.geometry.OperatorFactoryLocal.GetInstance();
			inputSR = com.esri.core.geometry.SpatialReference.Create(codeIn);
			outputSR = com.esri.core.geometry.SpatialReference.Create(codeOut);
		}

		/// <exception cref="System.Exception"/>
		protected void TearDown()
		{
			
		}

		[NUnit.Framework.Test]
		public virtual void TestIntersection1()
		{
			// OperatorFactoryLocal projEnv = OperatorFactoryLocal.getInstance();
			// int codeIn = 26910;//NAD_1983_UTM_Zone_10N : GCS 6269
			// int codeOut = 32610;//WGS_1984_UTM_Zone_10N; : GCS 4326
			// int codeIn = SpatialReference::PCS_WGS_1984_UTM_10N;
			// int codeOut = SpatialReference::PCS_WORLD_MOLLWEIDE;
			// int codeOut = 102100;
			inputSR = com.esri.core.geometry.SpatialReference.Create(codeIn);
			NUnit.Framework.Assert.IsTrue(inputSR.GetID() == codeIn);
			outputSR = com.esri.core.geometry.SpatialReference.Create(codeOut);
			NUnit.Framework.Assert.IsTrue(outputSR.GetID() == codeOut);
			com.esri.core.geometry.OperatorIntersection operatorIntersection = (com.esri.core.geometry.OperatorIntersection)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
			com.esri.core.geometry.Polygon poly1 = new com.esri.core.geometry.Polygon();
			com.esri.core.geometry.Envelope env1 = new com.esri.core.geometry.Envelope(855277, 3892059, 855277 + 100, 3892059 + 100);
			// Envelope env1 = new Envelope(-1000000, -1000000, 1000000, 1000000);
			// env1.SetCoords(-8552770, -3892059, 855277 + 100, 3892059 + 100);
			poly1.AddEnvelope(env1, false);
			com.esri.core.geometry.Polygon poly2 = new com.esri.core.geometry.Polygon();
			com.esri.core.geometry.Envelope env2 = new com.esri.core.geometry.Envelope(855277 + 1, 3892059 + 1, 855277 + 30, 3892059 + 20);
			poly2.AddEnvelope(env2, false);
			com.esri.core.geometry.GeometryCursor cursor1 = new com.esri.core.geometry.SimpleGeometryCursor(poly1);
			com.esri.core.geometry.GeometryCursor cursor2 = new com.esri.core.geometry.SimpleGeometryCursor(poly2);
			com.esri.core.geometry.GeometryCursor outputGeoms = operatorIntersection.Execute(cursor1, cursor2, inputSR, null);
			com.esri.core.geometry.Geometry geomr = outputGeoms.Next();
			NUnit.Framework.Assert.IsNotNull(geomr);
			NUnit.Framework.Assert.IsTrue(geomr.GetType() == com.esri.core.geometry.Geometry.Type.Polygon);
			com.esri.core.geometry.Polygon geom = (com.esri.core.geometry.Polygon)geomr;
			NUnit.Framework.Assert.IsTrue(geom.GetPointCount() == 4);
//			com.esri.core.geometry.Point[] points = com.esri.core.geometry.TestCommonMethods.PointsFromMultiPath(geom);
//			// SPtrOfArrayOf(Point2D)
//			// pts =
//			// geom.get.getCoordinates2D();
//			NUnit.Framework.Assert.IsTrue(System.Math.Abs(points[0].GetX() - 855278.000000000) < 1e-7);
//			NUnit.Framework.Assert.IsTrue(System.Math.Abs(points[0].GetY() - 3892060.0000000000) < 1e-7);
//			NUnit.Framework.Assert.IsTrue(System.Math.Abs(points[2].GetX() - 855307.00000000093) < 1e-7);
//			NUnit.Framework.Assert.IsTrue(System.Math.Abs(points[2].GetY() - 3892079.0000000000) < 1e-7);
//			geomr = operatorIntersection.Execute(poly1, poly2, inputSR, null);
//			NUnit.Framework.Assert.IsNotNull(geomr);
//			NUnit.Framework.Assert.IsTrue(geomr.GetType() == com.esri.core.geometry.Geometry.Type.Polygon);
//			com.esri.core.geometry.Polygon outputGeom = (com.esri.core.geometry.Polygon)geomr;
//			NUnit.Framework.Assert.IsTrue(outputGeom.GetPointCount() == 4);
//			points = com.esri.core.geometry.TestCommonMethods.PointsFromMultiPath(outputGeom);
//			NUnit.Framework.Assert.IsTrue(System.Math.Abs(points[0].GetX() - 855278.000000000) < 1e-7);
//			NUnit.Framework.Assert.IsTrue(System.Math.Abs(points[0].GetY() - 3892060.0000000000) < 1e-7);
//			NUnit.Framework.Assert.IsTrue(System.Math.Abs(points[2].GetX() - 855307.00000000093) < 1e-7);
//			NUnit.Framework.Assert.IsTrue(System.Math.Abs(points[2].GetY() - 3892079.0000000000) < 1e-7);
		}

		[NUnit.Framework.Test]
		public virtual void TestSelfIntersecting()
		{
			// Test that we do not fail if there is
			// self-intersection
			// OperatorFactoryLocal projEnv =
			// OperatorFactoryLocal.getInstance();
			com.esri.core.geometry.OperatorIntersection operatorIntersection = (com.esri.core.geometry.OperatorIntersection)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
			com.esri.core.geometry.SpatialReference sr = com.esri.core.geometry.SpatialReference.Create(4326);
			com.esri.core.geometry.Polygon poly1 = new com.esri.core.geometry.Polygon();
			com.esri.core.geometry.Envelope2D env1 = new com.esri.core.geometry.Envelope2D();
			env1.SetCoords(0, 0, 20, 30);
			poly1.AddEnvelope(env1, false);
			com.esri.core.geometry.Polygon poly2 = new com.esri.core.geometry.Polygon();
			poly2.StartPath(0, 0);
			poly2.LineTo(10, 10);
			poly2.LineTo(0, 10);
			poly2.LineTo(10, 0);
			com.esri.core.geometry.Polygon res = (com.esri.core.geometry.Polygon)(operatorIntersection.Execute(poly1, poly2, sr, null));
		}

		// Operator_equals equals =
		// (Operator_equals)projEnv.get_operator(Operator::equals);
		// assertTrue(equals.execute(res, poly2, sr, NULL) == true);
		[NUnit.Framework.Test]
		public virtual void TestMultipoint()
		{
			com.esri.core.geometry.Polygon poly1 = new com.esri.core.geometry.Polygon();
			com.esri.core.geometry.Envelope env1 = new com.esri.core.geometry.Envelope(855277, 3892059, 855277 + 100, 3892059 + 100);
			poly1.AddEnvelope(env1, false);
			com.esri.core.geometry.MultiPoint multiPoint = new com.esri.core.geometry.MultiPoint();
			multiPoint.Add(855277 + 10, 3892059 + 10);
			multiPoint.Add(855277, 3892059);
			multiPoint.Add(855277 + 100, 3892059 + 100);
			multiPoint.Add(855277 + 100, 3892059 + 101);
			multiPoint.Add(855277 + 101, 3892059 + 100);
			multiPoint.Add(855277 + 101, 3892059 + 101);
			com.esri.core.geometry.OperatorIntersection operatorIntersection = (com.esri.core.geometry.OperatorIntersection)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
			com.esri.core.geometry.MultiPoint mpResult = (com.esri.core.geometry.MultiPoint)operatorIntersection.Execute(poly1, multiPoint, inputSR, null);
			NUnit.Framework.Assert.IsTrue(mpResult.GetPointCount() == 3);
			NUnit.Framework.Assert.IsTrue(mpResult.GetPoint(0).GetX() == 855277 + 10 && mpResult.GetPoint(0).GetY() == 3892059 + 10);
			NUnit.Framework.Assert.IsTrue(mpResult.GetPoint(1).GetX() == 855277 && mpResult.GetPoint(1).GetY() == 3892059);
			NUnit.Framework.Assert.IsTrue(mpResult.GetPoint(2).GetX() == 855277 + 100 && mpResult.GetPoint(2).GetY() == 3892059 + 100);
			// Test intersection of Polygon with Envelope (calls Clip)
			com.esri.core.geometry.Polygon poly = new com.esri.core.geometry.Polygon();
			poly.StartPath(0, 0);
			poly.LineTo(10, 10);
			poly.LineTo(20, 0);
			env1.SetXMin(0);
			env1.SetXMax(20);
			env1.SetYMin(5);
			env1.SetYMax(15);
			com.esri.core.geometry.Envelope envelope1 = env1;
			com.esri.core.geometry.Polygon clippedPoly = (com.esri.core.geometry.Polygon)operatorIntersection.Execute(poly, envelope1, inputSR, null);
			double area = clippedPoly.CalculateArea2D();
			NUnit.Framework.Assert.IsTrue(System.Math.Abs(area - 25) < 0.00001);
			// Geometry res = GeometryEngine.difference(poly, envelope1, inputSR);
			com.esri.core.geometry.Envelope env2 = new com.esri.core.geometry.Envelope(855277 + 1, 3892059 + 1, 855277 + 30, 3892059 + 20);
			env2.SetXMin(5);
			env2.SetXMax(10);
			env2.SetYMin(0);
			env2.SetYMax(20);
			com.esri.core.geometry.Envelope envelope2 = env2;
			com.esri.core.geometry.Envelope clippedEnvelope = (com.esri.core.geometry.Envelope)operatorIntersection.Execute(envelope1, envelope2, inputSR, null);
			area = clippedEnvelope.CalculateArea2D();
			NUnit.Framework.Assert.IsTrue(System.Math.Abs(area - 50) < 0.00001);
		}

		[NUnit.Framework.Test]
		public virtual void TestDifferenceOnPolyline()
		{
			com.esri.core.geometry.Polyline basePl = new com.esri.core.geometry.Polyline();
			basePl.StartPath(-117, 20);
			basePl.LineTo(-130, 10);
			basePl.LineTo(-120, 50);
			com.esri.core.geometry.Polyline compPl = new com.esri.core.geometry.Polyline();
			compPl.StartPath(-116, 20);
			compPl.LineTo(-131, 10);
			compPl.LineTo(-121, 50);
			// OperatorFactoryLocal projEnv = OperatorFactoryLocal.getInstance();
			com.esri.core.geometry.OperatorDifference op = (com.esri.core.geometry.OperatorDifference)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Difference);
			com.esri.core.geometry.Polyline diffGeom = (com.esri.core.geometry.Polyline)(op.Execute(basePl, compPl, com.esri.core.geometry.SpatialReference.Create(4326), null));
			int pc = diffGeom.GetPointCount();
			NUnit.Framework.Assert.IsTrue(pc == 5);
		}

		[NUnit.Framework.Test]
		public virtual void TestDifferenceOnPolyline2()
		{
			com.esri.core.geometry.Polyline basePl = new com.esri.core.geometry.Polyline();
			basePl.StartPath(0, 0);
			basePl.LineTo(10, 10);
			basePl.LineTo(20, 20);
			basePl.LineTo(10, 0);
			basePl.LineTo(20, 10);
			com.esri.core.geometry.Polyline compPl = new com.esri.core.geometry.Polyline();
			compPl.StartPath(5, 0);
			compPl.LineTo(5, 10);
			compPl.LineTo(0, 10);
			compPl.LineTo(7.5, 2.5);
			// Operator_factory_local::SaveJSONToTextFileDbg("c:/temp/basePl.txt",
			// *basePl, null);
			// Operator_factory_local::SaveJSONToTextFileDbg("c:/temp/compPl.txt",
			// *compPl, null);
			// OperatorFactoryLocal projEnv = OperatorFactoryLocal.getInstance();
			com.esri.core.geometry.OperatorDifference op = (com.esri.core.geometry.OperatorDifference)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Difference);
			com.esri.core.geometry.Polyline diffGeom = (com.esri.core.geometry.Polyline)(op.Execute(basePl, compPl, com.esri.core.geometry.SpatialReference.Create(4326), null));
			// Operator_factory_local::SaveJSONToTextFileDbg("c:/temp/diffGeom.txt",
			// *diffGeom, null);
			int pathc = diffGeom.GetPathCount();
			NUnit.Framework.Assert.IsTrue(pathc == 1);
			int pc = diffGeom.GetPointCount();
			NUnit.Framework.Assert.IsTrue(pc == 6);
			com.esri.core.geometry.Polyline resPl = new com.esri.core.geometry.Polyline();
			resPl.StartPath(0, 0);
			resPl.LineTo(5, 5);
			resPl.LineTo(10, 10);
			resPl.LineTo(20, 20);
			resPl.LineTo(10, 0);
			resPl.LineTo(20, 10);
			// Operator_factory_local::SaveJSONToTextFileDbg("c:/temp/resPl.txt",
			// *resPl, null);
			NUnit.Framework.Assert.IsTrue(resPl.Equals(diffGeom));
		}

		[NUnit.Framework.Test]
		public virtual void TestDifferencePointPolyline()
		{
			com.esri.core.geometry.Polyline basePl = new com.esri.core.geometry.Polyline();
			basePl.StartPath(0, 0);
			basePl.LineTo(10, 10);
			basePl.LineTo(20, 20);
			basePl.LineTo(10, 0);
			basePl.LineTo(20, 10);
			com.esri.core.geometry.Point compPl = new com.esri.core.geometry.Point(5, 5);
			// OperatorFactoryLocal projEnv = OperatorFactoryLocal.getInstance();
			com.esri.core.geometry.OperatorDifference op = (com.esri.core.geometry.OperatorDifference)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Difference);
			com.esri.core.geometry.Polyline diffGeom = (com.esri.core.geometry.Polyline)(op.Execute(basePl, compPl, com.esri.core.geometry.SpatialReference.Create(4326), null));
			int pathc = diffGeom.GetPathCount();
			NUnit.Framework.Assert.IsTrue(pathc == 1);
			int pc = diffGeom.GetPointCount();
			NUnit.Framework.Assert.IsTrue(pc == 5);
			com.esri.core.geometry.Polyline resPl = new com.esri.core.geometry.Polyline();
			resPl.StartPath(0, 0);
			resPl.LineTo(10, 10);
			resPl.LineTo(20, 20);
			resPl.LineTo(10, 0);
			resPl.LineTo(20, 10);
			NUnit.Framework.Assert.IsTrue(resPl.Equals(diffGeom));
		}

		// no change happens to the original
		// polyline
		[NUnit.Framework.Test]
		public virtual void TestIntersectionPolylinePolygon()
		{
			{
				com.esri.core.geometry.Polygon polygon = new com.esri.core.geometry.Polygon();
				polygon.StartPath(0, 0);
				polygon.LineTo(0, 10);
				polygon.LineTo(20, 10);
				polygon.LineTo(20, 0);
				polygon.AddAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z);
				polygon.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 0, 0, 3);
				polygon.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 3, 0, 3);
				polygon.InterpolateAttributes(0, 0, 3);
				com.esri.core.geometry.Polyline polyline = new com.esri.core.geometry.Polyline();
				polyline.StartPath(0, 10);
				polyline.LineTo(5, 5);
				polyline.LineTo(6, 4);
				polyline.LineTo(7, -1);
				polyline.AddAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 0, 0, 5);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 3, 0, 5);
				polyline.InterpolateAttributes(0, 0, 0, 3);
				// OperatorFactoryLocal projEnv =
				// OperatorFactoryLocal.getInstance();
				com.esri.core.geometry.OperatorIntersection operatorIntersection = (com.esri.core.geometry.OperatorIntersection)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
				com.esri.core.geometry.Geometry geom = operatorIntersection.Execute(polyline, polygon, null, null);
				NUnit.Framework.Assert.IsTrue(!geom.IsEmpty());
				com.esri.core.geometry.Polyline poly = (com.esri.core.geometry.Polyline)(geom);
				for (int i = 0; i < poly.GetPointCount(); i++)
				{
					NUnit.Framework.Assert.IsTrue(poly.GetAttributeAsDbl(com.esri.core.geometry.VertexDescription.Semantics.Z, i, 0) == 5);
				}
			}
			{
				// std::shared_ptr<Operator_export_to_JSON> jsonExport =
				// (Operator_export_to_JSON>)Operator_factory_local::get_instance().get_operator(Operator::Operator_type::export_to_JSON);
				// std::string str = jsonExport.execute(0, geom, null, null);
				// OutputDebugStringA(str.c_str());
				// OutputDebugString(L"\n");
				// assertTrue(str=="{\"paths\":[[[0,10],[5,5],[6,4],[6.7999999999999998,4.4408922169635528e-016]]]}");
				com.esri.core.geometry.Polygon polygon = new com.esri.core.geometry.Polygon();
				polygon.StartPath(0, 0);
				polygon.LineTo(0, 10);
				polygon.LineTo(20, 10);
				polygon.LineTo(20, 0);
				polygon.AddAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z);
				polygon.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 0, 0, 3);
				polygon.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 3, 0, 3);
				polygon.InterpolateAttributes(0, 0, 3);
				com.esri.core.geometry.Polyline polyline = new com.esri.core.geometry.Polyline();
				polyline.StartPath(0, 10);
				polyline.LineTo(20, 0);
				polyline.LineTo(5, 5);
				polyline.AddAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 0, 0, 5);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 1, 0, 5);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 2, 0, 5);
				// OperatorFactoryLocal projEnv =
				// OperatorFactoryLocal.getInstance();
				com.esri.core.geometry.OperatorIntersection operatorIntersection = (com.esri.core.geometry.OperatorIntersection)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
				com.esri.core.geometry.Geometry geom = operatorIntersection.Execute(polyline, polygon, null, null);
				NUnit.Framework.Assert.IsTrue(!geom.IsEmpty());
				com.esri.core.geometry.Polyline poly = (com.esri.core.geometry.Polyline)(geom);
				for (int i = 0; i < poly.GetPointCount(); i++)
				{
					NUnit.Framework.Assert.IsTrue(poly.GetAttributeAsDbl(com.esri.core.geometry.VertexDescription.Semantics.Z, i, 0) == 5);
				}
			}
			{
				// Operator_export_to_JSON> jsonExport =
				// (Operator_export_to_JSON>)Operator_factory_local::get_instance().get_operator(Operator::Operator_type::export_to_JSON);
				// std::string str = jsonExport.execute(0, geom, null, null);
				// OutputDebugStringA(str.c_str());
				// OutputDebugString(L"\n");
				// assertTrue(str=="{\"paths\":[[[0,10],[20,0],[5,5]]]}");
				com.esri.core.geometry.Polygon polygon = new com.esri.core.geometry.Polygon();
				polygon.StartPath(0, 0);
				polygon.LineTo(0, 10);
				polygon.LineTo(20, 10);
				polygon.LineTo(20, 0);
				polygon.AddAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z);
				polygon.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 0, 0, 3);
				polygon.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 3, 0, 3);
				polygon.InterpolateAttributes(0, 0, 3);
				com.esri.core.geometry.Polyline polyline = new com.esri.core.geometry.Polyline();
				polyline.StartPath(0, 0);
				polyline.LineTo(0, 10);
				polyline.LineTo(20, 10);
				polyline.AddAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 0, 0, 5);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 1, 0, 5);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 2, 0, 5);
				// OperatorFactoryLocal projEnv =
				// OperatorFactoryLocal.getInstance();
				com.esri.core.geometry.OperatorIntersection operatorIntersection = (com.esri.core.geometry.OperatorIntersection)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
				com.esri.core.geometry.Geometry geom = operatorIntersection.Execute(polyline, polygon, null, null);
				NUnit.Framework.Assert.IsTrue(!geom.IsEmpty());
				com.esri.core.geometry.Polyline poly = (com.esri.core.geometry.Polyline)(geom);
				for (int i = 0; i < poly.GetPointCount(); i++)
				{
					NUnit.Framework.Assert.IsTrue(poly.GetAttributeAsDbl(com.esri.core.geometry.VertexDescription.Semantics.Z, i, 0) == 5);
				}
			}
			{
				// Operator_export_to_JSON> jsonExport =
				// (Operator_export_to_JSON>)Operator_factory_local::get_instance().get_operator(Operator::Operator_type::export_to_JSON);
				// std::string str = jsonExport.execute(0, geom, null, null);
				// OutputDebugStringA(str.c_str());
				// OutputDebugString(L"\n");
				// assertTrue(str=="{\"paths\":[[[0,0],[0,10],[20,10]]]}");
				com.esri.core.geometry.Polygon polygon = new com.esri.core.geometry.Polygon();
				polygon.StartPath(0, 0);
				polygon.LineTo(0, 10);
				polygon.LineTo(20, 10);
				polygon.LineTo(20, 0);
				com.esri.core.geometry.Polyline polyline = new com.esri.core.geometry.Polyline();
				polyline.StartPath(3, -1);
				polyline.LineTo(17, 1);
				polyline.LineTo(10, 8);
				polyline.LineTo(-1, 5);
				polyline.AddAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 0, 0, 5);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 1, 0, 5);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 2, 0, 5);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 3, 0, 5);
				// OperatorFactoryLocal projEnv =
				// OperatorFactoryLocal.getInstance();
				com.esri.core.geometry.OperatorIntersection operatorIntersection = (com.esri.core.geometry.OperatorIntersection)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
				com.esri.core.geometry.Geometry geom = operatorIntersection.Execute(polyline, polygon, null, null);
				NUnit.Framework.Assert.IsTrue(!geom.IsEmpty());
				com.esri.core.geometry.Polyline poly = (com.esri.core.geometry.Polyline)geom;
				for (int i = 0; i < poly.GetPointCount(); i++)
				{
					NUnit.Framework.Assert.IsTrue(poly.GetAttributeAsDbl(com.esri.core.geometry.VertexDescription.Semantics.Z, i, 0) == 5);
				}
			}
			{
				// Operator_export_to_JSON> jsonExport =
				// (Operator_export_to_JSON>)Operator_factory_local::get_instance().get_operator(Operator::Operator_type::export_to_JSON);
				// std::string str = jsonExport.execute(0, geom, null, null);
				// OutputDebugStringA(str.c_str());
				// OutputDebugString(L"\n");
				// assertTrue(str=="{\"paths\":[[[10,0],[17,1],[10,8],[4.7377092701401439e-024,5.2727272727272734]]]}");
				com.esri.core.geometry.Polygon polygon = new com.esri.core.geometry.Polygon();
				polygon.StartPath(0, 0);
				polygon.LineTo(0, 10);
				polygon.LineTo(20, 10);
				polygon.LineTo(20, 0);
				com.esri.core.geometry.Polyline polyline = new com.esri.core.geometry.Polyline();
				polyline.StartPath(0, 15);
				polyline.LineTo(3, -1);
				polyline.LineTo(17, 1);
				polyline.LineTo(10, 8);
				polyline.LineTo(-1, 5);
				polyline.AddAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 0, 0, 5);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 4, 0, 5);
				polyline.InterpolateAttributes(0, 0, 0, 4);
				com.esri.core.geometry.OperatorIntersection operatorIntersection = (com.esri.core.geometry.OperatorIntersection)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
				com.esri.core.geometry.Geometry geom = operatorIntersection.Execute(polyline, polygon, null, null);
				NUnit.Framework.Assert.IsTrue(!geom.IsEmpty());
				com.esri.core.geometry.Polyline poly = (com.esri.core.geometry.Polyline)geom;
				for (int i = 0; i < poly.GetPointCount(); i++)
				{
					NUnit.Framework.Assert.IsTrue(poly.GetAttributeAsDbl(com.esri.core.geometry.VertexDescription.Semantics.Z, i, 0) == 5);
				}
			}
			{
				// Operator_export_to_JSON> jsonExport =
				// (Operator_export_to_JSON>)Operator_factory_local::get_instance().get_operator(Operator::Operator_type::export_to_JSON);
				// std::string str = jsonExport.execute(0, geom, null, null);
				// OutputDebugStringA(str.c_str());
				// OutputDebugString(L"\n");
				// assertTrue(str=="{\"paths\":[[[0.9375,10],[2.8125,9.476226333847234e-024]],[[10,0],[17,1],[10,8],[4.7377092701401439e-024,5.2727272727272734]]]}");
				com.esri.core.geometry.Polygon polygon = new com.esri.core.geometry.Polygon();
				polygon.StartPath(0, 0);
				polygon.LineTo(0, 10);
				polygon.LineTo(20, 10);
				polygon.LineTo(20, 0);
				com.esri.core.geometry.Polyline polyline = new com.esri.core.geometry.Polyline();
				polyline.StartPath(5, 5);
				polyline.LineTo(1, 1);
				polyline.LineTo(-1, 1);
				polyline.LineTo(-1, 10);
				polyline.LineTo(0, 10);
				polyline.LineTo(6, 6);
				polyline.AddAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 0, 0, 5);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 5, 0, 5);
				polyline.InterpolateAttributes(0, 0, 0, 5);
				// OperatorFactoryLocal projEnv =
				// OperatorFactoryLocal.getInstance();
				com.esri.core.geometry.OperatorIntersection operatorIntersection = (com.esri.core.geometry.OperatorIntersection)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
				com.esri.core.geometry.Geometry geom = operatorIntersection.Execute(polyline, polygon, null, null);
				NUnit.Framework.Assert.IsTrue(!geom.IsEmpty());
				com.esri.core.geometry.Polyline poly = (com.esri.core.geometry.Polyline)geom;
				for (int i = 0; i < poly.GetPointCount(); i++)
				{
					NUnit.Framework.Assert.IsTrue(poly.GetAttributeAsDbl(com.esri.core.geometry.VertexDescription.Semantics.Z, i, 0) == 5);
				}
			}
			{
				// Operator_export_to_JSON> jsonExport =
				// (Operator_export_to_JSON>)Operator_factory_local::get_instance().get_operator(Operator::Operator_type::export_to_JSON);
				// std::string str = jsonExport.execute(0, geom, null, null);
				// OutputDebugStringA(str.c_str());
				// OutputDebugString(L"\n");
				// assertTrue(str=="{\"paths\":[[[5,5],[1,1],[4.738113166923617e-023,1]],[[0,10],[6,6]]]}");
				com.esri.core.geometry.Polygon polygon = new com.esri.core.geometry.Polygon();
				polygon.StartPath(0, 0);
				polygon.LineTo(0, 10);
				polygon.LineTo(20, 10);
				polygon.LineTo(20, 0);
				com.esri.core.geometry.Polyline polyline = new com.esri.core.geometry.Polyline();
				polyline.StartPath(0, 15);
				polyline.LineTo(3, -1);
				polyline.LineTo(17, 1);
				polyline.LineTo(10, 8);
				polyline.LineTo(-1, 5);
				polyline.StartPath(19, 15);
				polyline.LineTo(29, 9);
				polyline.StartPath(19, 15);
				polyline.LineTo(29, 9);
				polyline.StartPath(5, 5);
				polyline.LineTo(1, 1);
				polyline.LineTo(-1, 1);
				polyline.LineTo(-1, 10);
				polyline.LineTo(0, 10);
				polyline.LineTo(6, 6);
				polyline.AddAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 0, 0, 5);
				polyline.SetAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z, 14, 0, 5);
				polyline.InterpolateAttributes(0, 0, 3, 5);
				// OperatorFactoryLocal projEnv =
				// OperatorFactoryLocal.getInstance();
				com.esri.core.geometry.OperatorIntersection operatorIntersection = (com.esri.core.geometry.OperatorIntersection)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
				com.esri.core.geometry.Geometry geom = operatorIntersection.Execute(polyline, polygon, null, null);
				NUnit.Framework.Assert.IsTrue(!geom.IsEmpty());
				com.esri.core.geometry.Polyline poly = (com.esri.core.geometry.Polyline)geom;
				for (int i = 0; i < poly.GetPointCount(); i++)
				{
					NUnit.Framework.Assert.IsTrue(poly.GetAttributeAsDbl(com.esri.core.geometry.VertexDescription.Semantics.Z, i, 0) == 5);
				}
			}
		}

		// Operator_export_to_JSON> jsonExport =
		// (Operator_export_to_JSON>)Operator_factory_local::get_instance().get_operator(Operator::Operator_type::export_to_JSON);
		// std::string str = jsonExport.execute(0, geom, null, null);
		// OutputDebugStringA(str.c_str());
		// OutputDebugString(L"\n");
		// assertTrue(str=="{\"paths\":[[[0.9375,10],[2.8125,9.476226333847234e-024]],[[10,0],[17,1],[10,8],[4.7377092701401439e-024,5.2727272727272734]],[[5,5],[1,1],[4.738113166923617e-023,1]],[[0,10],[6,6]]]}");
		[NUnit.Framework.Test]
		public virtual void TestMultiPointPolyline()
		{
			com.esri.core.geometry.Polyline polyline = new com.esri.core.geometry.Polyline();
			polyline.StartPath(0, 0);
			polyline.LineTo(0, 10);
			polyline.LineTo(20, 10);
			polyline.LineTo(20, 0);
			com.esri.core.geometry.MultiPoint mp = new com.esri.core.geometry.MultiPoint();
			mp.Add(0, 10, 7);
			mp.Add(0, 5, 7);
			mp.Add(1, 5, 7);
			// OperatorFactoryLocal projEnv = OperatorFactoryLocal.getInstance();
			com.esri.core.geometry.OperatorIntersection operatorIntersection = (com.esri.core.geometry.OperatorIntersection)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
			com.esri.core.geometry.OperatorDifference operatorDifference = (com.esri.core.geometry.OperatorDifference)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Difference);
			{
				// intersect
				com.esri.core.geometry.Geometry geom = operatorIntersection.Execute(polyline, mp, null, null);
				com.esri.core.geometry.MultiPoint res = (com.esri.core.geometry.MultiPoint)geom;
				NUnit.Framework.Assert.IsTrue(res.GetPointCount() == 2);
				com.esri.core.geometry.Point2D pt_1 = res.GetXY(0);
				com.esri.core.geometry.Point2D pt_2 = res.GetXY(1);
				NUnit.Framework.Assert.IsTrue(com.esri.core.geometry.Point2D.Distance(pt_1, new com.esri.core.geometry.Point2D(0, 10)) < 1e-10 && com.esri.core.geometry.Point2D.Distance(pt_2, new com.esri.core.geometry.Point2D(0, 5)) < 1e-10 || com.esri.core.geometry.Point2D.Distance(pt_2, new com.esri.core.geometry.Point2D
					(0, 10)) < 1e-10 && com.esri.core.geometry.Point2D.Distance(pt_1, new com.esri.core.geometry.Point2D(0, 5)) < 1e-10);
				NUnit.Framework.Assert.IsTrue(res.GetAttributeAsDbl(com.esri.core.geometry.VertexDescription.Semantics.Z, 0, 0) == 7);
				NUnit.Framework.Assert.IsTrue(res.GetAttributeAsDbl(com.esri.core.geometry.VertexDescription.Semantics.Z, 1, 0) == 7);
			}
			{
				// difference
				com.esri.core.geometry.Geometry geom = operatorDifference.Execute(polyline, mp, null, null);
				// assertTrue(geom.getGeometryType() ==
				// Geometry.GeometryType.Polyline);
				com.esri.core.geometry.Polyline res = (com.esri.core.geometry.Polyline)geom;
				NUnit.Framework.Assert.IsTrue(res.GetPointCount() == 4);
			}
			{
				// difference
				com.esri.core.geometry.Geometry geom = operatorDifference.Execute(mp, polyline, null, null);
				// assertTrue(geom.getType() == Geometry.GeometryType.MultiPoint);
				com.esri.core.geometry.MultiPoint res = (com.esri.core.geometry.MultiPoint)geom;
				NUnit.Framework.Assert.IsTrue(res.GetPointCount() == 1);
				com.esri.core.geometry.Point2D pt_1 = res.GetXY(0);
				NUnit.Framework.Assert.IsTrue(com.esri.core.geometry.Point2D.Distance(pt_1, new com.esri.core.geometry.Point2D(1, 5)) < 1e-10);
			}
			{
				// difference (subtract empty)
				com.esri.core.geometry.Geometry geom = operatorDifference.Execute(mp, new com.esri.core.geometry.Polyline(), null, null);
				// assertTrue(geom.getGeometryType() ==
				// Geometry.GeometryType.MultiPoint);
				com.esri.core.geometry.MultiPoint res = (com.esri.core.geometry.MultiPoint)geom;
				NUnit.Framework.Assert.IsTrue(res.GetPointCount() == 3);
				com.esri.core.geometry.Point2D pt_1 = res.GetXY(0);
				NUnit.Framework.Assert.IsTrue(com.esri.core.geometry.Point2D.Distance(pt_1, new com.esri.core.geometry.Point2D(0, 10)) < 1e-10);
			}
		}

		[NUnit.Framework.Test]
		public virtual void TestPointPolyline()
		{
			com.esri.core.geometry.Polyline polyline = new com.esri.core.geometry.Polyline();
			polyline.StartPath(0, 0);
			polyline.LineTo(0, 10);
			polyline.LineTo(20, 10);
			polyline.LineTo(20, 0);
			com.esri.core.geometry.Point p_1 = new com.esri.core.geometry.Point(0, 5, 7);
			com.esri.core.geometry.Point p_2 = new com.esri.core.geometry.Point(0, 10, 7);
			com.esri.core.geometry.Point p3 = new com.esri.core.geometry.Point(1, 5, 7);
			// OperatorFactoryLocal projEnv = OperatorFactoryLocal.getInstance();
			com.esri.core.geometry.OperatorIntersection operatorIntersection = (com.esri.core.geometry.OperatorIntersection)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
			com.esri.core.geometry.OperatorDifference operatorDiff = (com.esri.core.geometry.OperatorDifference)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Difference);
			com.esri.core.geometry.OperatorUnion operatorUnion = (com.esri.core.geometry.OperatorUnion)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Union);
			com.esri.core.geometry.OperatorSymmetricDifference operatorSymDiff = (com.esri.core.geometry.OperatorSymmetricDifference)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.SymmetricDifference);
			{
				// intersect case1
				com.esri.core.geometry.Geometry geom = operatorIntersection.Execute(polyline, p_1, null, null);
				// assertTrue(geom.getType() == Geometry::enum_point);
				com.esri.core.geometry.Point res = (com.esri.core.geometry.Point)geom;
				com.esri.core.geometry.Point2D pt_1 = res.GetXY();
				NUnit.Framework.Assert.IsTrue(com.esri.core.geometry.Point2D.Distance(pt_1, new com.esri.core.geometry.Point2D(0, 5)) < 1e-10);
				NUnit.Framework.Assert.IsTrue(res.GetAttributeAsDbl(com.esri.core.geometry.VertexDescription.Semantics.Z, 0) == 7);
			}
			{
				// intersect case2
				com.esri.core.geometry.Geometry geom = operatorIntersection.Execute(polyline, p_2, null, null);
				// assertTrue(geom.getType() == Geometry::enum_point);
				com.esri.core.geometry.Point res = (com.esri.core.geometry.Point)geom;
				com.esri.core.geometry.Point2D pt_1 = res.GetXY();
				NUnit.Framework.Assert.IsTrue(com.esri.core.geometry.Point2D.Distance(pt_1, new com.esri.core.geometry.Point2D(0, 10)) < 1e-10);
				NUnit.Framework.Assert.IsTrue(res.GetAttributeAsDbl(com.esri.core.geometry.VertexDescription.Semantics.Z, 0) == 7);
			}
			{
				// intersect case3
				com.esri.core.geometry.Geometry geom = operatorIntersection.Execute(polyline, p3, null, null);
				// assertTrue(geom.getType() == Geometry::enum_point);
				NUnit.Framework.Assert.IsTrue(geom.IsEmpty());
				NUnit.Framework.Assert.IsTrue(geom.HasAttribute(com.esri.core.geometry.VertexDescription.Semantics.Z));
			}
			{
				// difference case1
				com.esri.core.geometry.Geometry geom = operatorDiff.Execute(polyline, p_1, null, null);
				// assertTrue(geom.getType() == Geometry.GeometryType.Polyline);
				com.esri.core.geometry.Polyline res = (com.esri.core.geometry.Polyline)geom;
				NUnit.Framework.Assert.IsTrue(res.GetPointCount() == 4);
			}
			{
				// difference case2
				com.esri.core.geometry.Geometry geom = operatorDiff.Execute(p_1, polyline, null, null);
				// assertTrue(geom.getType() == Geometry::enum_point);
				com.esri.core.geometry.Point res = (com.esri.core.geometry.Point)geom;
				NUnit.Framework.Assert.IsTrue(res.IsEmpty());
			}
			{
				// difference case3
				com.esri.core.geometry.Geometry geom = operatorDiff.Execute(p_2, polyline, null, null);
				// assertTrue(geom.getType() == Geometry::enum_point);
				com.esri.core.geometry.Point res = (com.esri.core.geometry.Point)geom;
				NUnit.Framework.Assert.IsTrue(res.IsEmpty());
			}
			{
				// difference case4
				com.esri.core.geometry.Geometry geom = operatorDiff.Execute(p3, polyline, null, null);
				// assertTrue(geom.getType() == Geometry::enum_point);
				com.esri.core.geometry.Point res = (com.esri.core.geometry.Point)geom;
				com.esri.core.geometry.Point2D pt_1 = res.GetXY();
				NUnit.Framework.Assert.IsTrue(com.esri.core.geometry.Point2D.Distance(pt_1, new com.esri.core.geometry.Point2D(1, 5)) < 1e-10);
			}
			{
				// union case1
				com.esri.core.geometry.Geometry geom = operatorUnion.Execute(p_1, polyline, null, null);
				// assertTrue(geom.getType() == Geometry.GeometryType.Polyline);
				com.esri.core.geometry.Polyline res = (com.esri.core.geometry.Polyline)geom;
				NUnit.Framework.Assert.IsTrue(!res.IsEmpty());
			}
			{
				// union case2
				com.esri.core.geometry.Geometry geom = operatorUnion.Execute(polyline, p_1, null, null);
				// assertTrue(geom.getType() == Geometry.GeometryType.Polyline);
				com.esri.core.geometry.Polyline res = (com.esri.core.geometry.Polyline)geom;
				NUnit.Framework.Assert.IsTrue(!res.IsEmpty());
			}
			{
				// symmetric difference case1
				com.esri.core.geometry.Geometry geom = operatorSymDiff.Execute(polyline, p_1, null, null);
				NUnit.Framework.Assert.IsTrue(geom.GetType().Value() == com.esri.core.geometry.Geometry.GeometryType.Polyline);
				com.esri.core.geometry.Polyline res = (com.esri.core.geometry.Polyline)(geom);
				NUnit.Framework.Assert.IsTrue(!res.IsEmpty());
			}
			{
				// symmetric difference case2
				com.esri.core.geometry.Geometry geom = operatorSymDiff.Execute(p_1, polyline, null, null);
				NUnit.Framework.Assert.IsTrue(geom.GetType().Value() == com.esri.core.geometry.Geometry.GeometryType.Polyline);
				com.esri.core.geometry.Polyline res = (com.esri.core.geometry.Polyline)(geom);
				NUnit.Framework.Assert.IsTrue(!res.IsEmpty());
			}
		}

		[NUnit.Framework.Test]
		public virtual void TestPolylinePolylineIntersectionExtended()
		{
			{
				// crossing intersection
				com.esri.core.geometry.Polyline basePl = new com.esri.core.geometry.Polyline();
				basePl.StartPath(0, 10);
				basePl.LineTo(100, 10);
				com.esri.core.geometry.Polyline compPl = new com.esri.core.geometry.Polyline();
				compPl.StartPath(50, 0);
				compPl.LineTo(50, 100);
				com.esri.core.geometry.OperatorIntersection op = (com.esri.core.geometry.OperatorIntersection)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
				com.esri.core.geometry.GeometryCursor result_cursor = op.Execute(new com.esri.core.geometry.SimpleGeometryCursor(basePl), new com.esri.core.geometry.SimpleGeometryCursor(compPl), com.esri.core.geometry.SpatialReference.Create(4326), null, 3);
				// dimension is 3, means it has to return a point and a polyline
				com.esri.core.geometry.Geometry geom1 = result_cursor.Next();
				NUnit.Framework.Assert.IsTrue(geom1 != null);
				NUnit.Framework.Assert.IsTrue(geom1.GetDimension() == 0);
				NUnit.Framework.Assert.IsTrue(geom1.GetType().Value() == com.esri.core.geometry.Geometry.GeometryType.MultiPoint);
				NUnit.Framework.Assert.IsTrue(((com.esri.core.geometry.MultiPoint)geom1).GetPointCount() == 1);
				com.esri.core.geometry.Geometry geom2 = result_cursor.Next();
				NUnit.Framework.Assert.IsTrue(geom2 != null);
				NUnit.Framework.Assert.IsTrue(geom2.GetDimension() == 1);
				NUnit.Framework.Assert.IsTrue(geom2.GetType().Value() == com.esri.core.geometry.Geometry.GeometryType.Polyline);
				NUnit.Framework.Assert.IsTrue(((com.esri.core.geometry.Polyline)geom2).GetPointCount() == 0);
				com.esri.core.geometry.Geometry geom3 = result_cursor.Next();
				NUnit.Framework.Assert.IsTrue(geom3 == null);
			}
			{
				// crossing + overlapping intersection
				com.esri.core.geometry.Polyline basePl = new com.esri.core.geometry.Polyline();
				basePl.StartPath(0, 10);
				basePl.LineTo(100, 10);
				com.esri.core.geometry.Polyline compPl = new com.esri.core.geometry.Polyline();
				compPl.StartPath(50, 0);
				compPl.LineTo(50, 100);
				compPl.LineTo(70, 10);
				compPl.LineTo(100, 10);
				com.esri.core.geometry.OperatorIntersection op = (com.esri.core.geometry.OperatorIntersection)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
				com.esri.core.geometry.GeometryCursor result_cursor = op.Execute(new com.esri.core.geometry.SimpleGeometryCursor(basePl), new com.esri.core.geometry.SimpleGeometryCursor(compPl), com.esri.core.geometry.SpatialReference.Create(4326), null, 3);
				// dimension is 3, means it has to return a point and a polyline
				com.esri.core.geometry.Geometry geom1 = result_cursor.Next();
				NUnit.Framework.Assert.IsTrue(geom1 != null);
				NUnit.Framework.Assert.IsTrue(geom1.GetDimension() == 0);
				NUnit.Framework.Assert.IsTrue(geom1.GetType().Value() == com.esri.core.geometry.Geometry.GeometryType.MultiPoint);
				NUnit.Framework.Assert.IsTrue(((com.esri.core.geometry.MultiPoint)geom1).GetPointCount() == 1);
				com.esri.core.geometry.Geometry geom2 = result_cursor.Next();
				NUnit.Framework.Assert.IsTrue(geom2 != null);
				NUnit.Framework.Assert.IsTrue(geom2.GetDimension() == 1);
				NUnit.Framework.Assert.IsTrue(geom2.GetType().Value() == com.esri.core.geometry.Geometry.GeometryType.Polyline);
				NUnit.Framework.Assert.IsTrue(((com.esri.core.geometry.Polyline)geom2).GetPathCount() == 1);
				NUnit.Framework.Assert.IsTrue(((com.esri.core.geometry.Polyline)geom2).GetPointCount() == 2);
				com.esri.core.geometry.Geometry geom3 = result_cursor.Next();
				NUnit.Framework.Assert.IsTrue(geom3 == null);
			}
		}

		[NUnit.Framework.Test]
		public virtual void TestPolygonPolygonIntersectionExtended()
		{
			{
				// crossing intersection
				com.esri.core.geometry.Polygon basePl = new com.esri.core.geometry.Polygon();
				basePl.StartPath(0, 0);
				basePl.LineTo(100, 0);
				basePl.LineTo(100, 100);
				basePl.LineTo(0, 100);
				com.esri.core.geometry.Polygon compPl = new com.esri.core.geometry.Polygon();
				compPl.StartPath(100, 100);
				compPl.LineTo(200, 100);
				compPl.LineTo(200, 200);
				compPl.LineTo(100, 200);
				com.esri.core.geometry.OperatorIntersection op = (com.esri.core.geometry.OperatorIntersection)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
				com.esri.core.geometry.GeometryCursor result_cursor = op.Execute(new com.esri.core.geometry.SimpleGeometryCursor(basePl), new com.esri.core.geometry.SimpleGeometryCursor(compPl), com.esri.core.geometry.SpatialReference.Create(4326), null, 7);
				com.esri.core.geometry.Geometry geom1 = result_cursor.Next();
				NUnit.Framework.Assert.IsTrue(geom1 != null);
				NUnit.Framework.Assert.IsTrue(geom1.GetDimension() == 0);
				NUnit.Framework.Assert.IsTrue(geom1.GetType().Value() == com.esri.core.geometry.Geometry.GeometryType.MultiPoint);
				NUnit.Framework.Assert.IsTrue(((com.esri.core.geometry.MultiPoint)geom1).GetPointCount() == 1);
				com.esri.core.geometry.Geometry geom2 = result_cursor.Next();
				NUnit.Framework.Assert.IsTrue(geom2 != null);
				NUnit.Framework.Assert.IsTrue(geom2.GetDimension() == 1);
				NUnit.Framework.Assert.IsTrue(geom2.GetType().Value() == com.esri.core.geometry.Geometry.GeometryType.Polyline);
				NUnit.Framework.Assert.IsTrue(((com.esri.core.geometry.Polyline)geom2).GetPointCount() == 0);
				com.esri.core.geometry.Geometry geom3 = result_cursor.Next();
				NUnit.Framework.Assert.IsTrue(geom3 != null);
				NUnit.Framework.Assert.IsTrue(geom3.GetDimension() == 2);
				NUnit.Framework.Assert.IsTrue(geom3.GetType().Value() == com.esri.core.geometry.Geometry.GeometryType.Polygon);
				NUnit.Framework.Assert.IsTrue(((com.esri.core.geometry.Polygon)geom3).GetPointCount() == 0);
				com.esri.core.geometry.Geometry geom4 = result_cursor.Next();
				NUnit.Framework.Assert.IsTrue(geom4 == null);
			}
			{
				// crossing + overlapping intersection
				com.esri.core.geometry.Polygon basePl = new com.esri.core.geometry.Polygon();
				basePl.StartPath(0, 0);
				basePl.LineTo(100, 0);
				basePl.LineTo(100, 100);
				basePl.LineTo(0, 100);
				com.esri.core.geometry.Polygon compPl = new com.esri.core.geometry.Polygon();
				compPl.StartPath(100, 100);
				compPl.LineTo(200, 100);
				compPl.LineTo(200, 200);
				compPl.LineTo(100, 200);
				compPl.StartPath(100, 20);
				compPl.LineTo(200, 20);
				compPl.LineTo(200, 40);
				compPl.LineTo(100, 40);
				compPl.StartPath(-10, -10);
				compPl.LineTo(-10, 10);
				compPl.LineTo(10, 10);
				compPl.LineTo(10, -10);
				com.esri.core.geometry.OperatorIntersection op = (com.esri.core.geometry.OperatorIntersection)projEnv.GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
				com.esri.core.geometry.GeometryCursor result_cursor = op.Execute(new com.esri.core.geometry.SimpleGeometryCursor(basePl), new com.esri.core.geometry.SimpleGeometryCursor(compPl), com.esri.core.geometry.SpatialReference.Create(4326), null, 7);
				// dimension is 3, means it has to return a point and a polyline
				com.esri.core.geometry.Geometry geom1 = result_cursor.Next();
				NUnit.Framework.Assert.IsTrue(geom1 != null);
				NUnit.Framework.Assert.IsTrue(geom1.GetDimension() == 0);
				NUnit.Framework.Assert.IsTrue(geom1.GetType().Value() == com.esri.core.geometry.Geometry.GeometryType.MultiPoint);
				NUnit.Framework.Assert.IsTrue(((com.esri.core.geometry.MultiPoint)geom1).GetPointCount() == 1);
				com.esri.core.geometry.Geometry geom2 = result_cursor.Next();
				NUnit.Framework.Assert.IsTrue(geom2 != null);
				NUnit.Framework.Assert.IsTrue(geom2.GetDimension() == 1);
				NUnit.Framework.Assert.IsTrue(geom2.GetType().Value() == com.esri.core.geometry.Geometry.GeometryType.Polyline);
				NUnit.Framework.Assert.IsTrue(((com.esri.core.geometry.Polyline)geom2).GetPathCount() == 1);
				NUnit.Framework.Assert.IsTrue(((com.esri.core.geometry.Polyline)geom2).GetPointCount() == 2);
				com.esri.core.geometry.Geometry geom3 = result_cursor.Next();
				NUnit.Framework.Assert.IsTrue(geom3 != null);
				NUnit.Framework.Assert.IsTrue(geom3.GetDimension() == 2);
				NUnit.Framework.Assert.IsTrue(geom3.GetType().Value() == com.esri.core.geometry.Geometry.GeometryType.Polygon);
				NUnit.Framework.Assert.IsTrue(((com.esri.core.geometry.Polygon)geom3).GetPathCount() == 1);
				NUnit.Framework.Assert.IsTrue(((com.esri.core.geometry.Polygon)geom3).GetPointCount() == 4);
				com.esri.core.geometry.Geometry geom4 = result_cursor.Next();
				NUnit.Framework.Assert.IsTrue(geom4 == null);
			}
		}

		[NUnit.Framework.Test]
		public virtual void TestFromProjection()
		{
			com.esri.core.geometry.MultiPoint multiPointInitial = new com.esri.core.geometry.MultiPoint();
			multiPointInitial.Add(-20037508.342789244, 3360107.7777777780);
			multiPointInitial.Add(-18924313.434856508, 3360107.7777777780);
			multiPointInitial.Add(-18924313.434856508, -3360107.7777777780);
			multiPointInitial.Add(-20037508.342789244, -3360107.7777777780);
			com.esri.core.geometry.Geometry geom1 = ((com.esri.core.geometry.MultiPoint)multiPointInitial);
			com.esri.core.geometry.SpatialReference sr = com.esri.core.geometry.SpatialReference.Create(102100);
			com.esri.core.geometry.Envelope2D env = new com.esri.core.geometry.Envelope2D();
			env.SetCoords(-20037508.342788246, -30240971.958386172, 20037508.342788246, 30240971.958386205);
			/* xmin */
			/* ymin */
			/* xmax */
			/* ymax */
			// /*xmin*/ -20037508.342788246
			// /*ymin*/ -30240971.958386172
			// /*xmax*/ 20037508.342788246
			// /*ymax*/ 30240971.958386205
			com.esri.core.geometry.Polygon poly = new com.esri.core.geometry.Polygon();
			poly.StartPath(env.xmin, env.ymin);
			poly.LineTo(env.xmin, env.ymax);
			poly.LineTo(env.xmax, env.ymax);
			poly.LineTo(env.xmax, env.ymin);
			com.esri.core.geometry.Geometry geom2 = new com.esri.core.geometry.Envelope(env);
			// Geometry geom2 = poly;
			com.esri.core.geometry.OperatorIntersection operatorIntersection = (com.esri.core.geometry.OperatorIntersection)com.esri.core.geometry.OperatorFactoryLocal.GetInstance().GetOperator(com.esri.core.geometry.Operator.Type.Intersection);
			com.esri.core.geometry.MultiPoint multiPointOut = (com.esri.core.geometry.MultiPoint)(operatorIntersection.Execute(geom1, geom2, sr, null));
			NUnit.Framework.Assert.IsTrue(multiPointOut.GetCoordinates2D().Length == 2);
			NUnit.Framework.Assert.IsTrue(multiPointOut.GetCoordinates2D()[0].x == -18924313.434856508);
			NUnit.Framework.Assert.IsTrue(multiPointOut.GetCoordinates2D()[0].y == 3360107.7777777780);
			NUnit.Framework.Assert.IsTrue(multiPointOut.GetCoordinates2D()[1].x == -18924313.434856508);
			NUnit.Framework.Assert.IsTrue(multiPointOut.GetCoordinates2D()[1].y == -3360107.7777777780);
		}

		[NUnit.Framework.Test]
		public virtual void TestIssue258128()
		{
			com.esri.core.geometry.Polygon poly1 = new com.esri.core.geometry.Polygon();
			poly1.StartPath(0, 0);
			poly1.LineTo(0, 10);
			poly1.LineTo(10, 10);
			poly1.LineTo(10, 0);
			com.esri.core.geometry.Polygon poly2 = new com.esri.core.geometry.Polygon();
			poly2.StartPath(10.5, 4);
			poly2.LineTo(10.5, 8);
			poly2.LineTo(14, 10);
			try
			{
				com.esri.core.geometry.GeometryCursor result_cursor = com.esri.core.geometry.OperatorIntersection.Local().Execute(new com.esri.core.geometry.SimpleGeometryCursor(poly1), new com.esri.core.geometry.SimpleGeometryCursor(poly2), com.esri.core.geometry.SpatialReference.Create(4326), null, 1);
				while (result_cursor.Next() != null)
				{
				}
			}
			catch (System.Exception)
			{
				NUnit.Framework.Assert.IsTrue(false);
			}
		}

		[NUnit.Framework.Test]
		public virtual void TestUnionTickTock()
		{
			com.esri.core.geometry.Polygon poly1 = new com.esri.core.geometry.Polygon();
			poly1.StartPath(0, 0);
			poly1.LineTo(0, 10);
			poly1.LineTo(10, 10);
			poly1.LineTo(10, 0);
			com.esri.core.geometry.Polygon poly2 = new com.esri.core.geometry.Polygon();
			poly2.StartPath(10.5, 4);
			poly2.LineTo(10.5, 8);
			poly2.LineTo(14, 10);
			com.esri.core.geometry.Transformation2D trans = new com.esri.core.geometry.Transformation2D();
			com.esri.core.geometry.Polygon poly3 = (com.esri.core.geometry.Polygon)poly1.Copy();
			trans.SetShift(2, 3);
			poly3.ApplyTransformation(trans);
			com.esri.core.geometry.Polygon poly4 = (com.esri.core.geometry.Polygon)poly1.Copy();
			trans.SetShift(-2, -3);
			poly4.ApplyTransformation(trans);
			// Create
			com.esri.core.geometry.ListeningGeometryCursor gc = new com.esri.core.geometry.ListeningGeometryCursor();
			com.esri.core.geometry.GeometryCursor ticktock = com.esri.core.geometry.OperatorUnion.Local().Execute(gc, null, null);
			// Use tick-tock to push a geometry and do a piece of work.
			gc.Tick(poly1);
			ticktock.Tock();
			gc.Tick(poly2);
			gc.Tick(poly3);
			// skiped one tock just for testing.
			ticktock.Tock();
			gc.Tick(poly4);
			ticktock.Tock();
			// Get the result
			com.esri.core.geometry.Geometry result = ticktock.Next();
			// Use ListeningGeometryCursor to put all geometries in.
			com.esri.core.geometry.ListeningGeometryCursor gc2 = new com.esri.core.geometry.ListeningGeometryCursor();
			gc2.Tick(poly1);
			gc2.Tick(poly2);
			gc2.Tick(poly3);
			gc2.Tick(poly4);
			com.esri.core.geometry.GeometryCursor res = com.esri.core.geometry.OperatorUnion.Local().Execute(gc2, null, null);
			// Calling next will process all geometries at once.
			com.esri.core.geometry.Geometry result2 = res.Next();
			NUnit.Framework.Assert.IsTrue(result.Equals(result2));
		}

		[NUnit.Framework.Test]
		public virtual void TestIntersectionIssueLinePoly1()
		{
			string wkt1 = "polygon((0 0, 10 0, 10 10, 0 10, 0 0))";
			string wkt2 = "linestring(9 5, 10 5, 9 4, 8 3)";
			com.esri.core.geometry.Geometry g1 = com.esri.core.geometry.OperatorImportFromWkt.Local().Execute(0, com.esri.core.geometry.Geometry.Type.Unknown, wkt1, null);
			com.esri.core.geometry.Geometry g2 = com.esri.core.geometry.OperatorImportFromWkt.Local().Execute(0, com.esri.core.geometry.Geometry.Type.Unknown, wkt2, null);
			com.esri.core.geometry.Geometry res = com.esri.core.geometry.OperatorIntersection.Local().Execute(g1, g2, null, null);
			NUnit.Framework.Assert.IsTrue(((com.esri.core.geometry.Polyline)res).GetPathCount() == 1);
			NUnit.Framework.Assert.IsTrue(((com.esri.core.geometry.Polyline)res).GetPointCount() == 4);
		}

//		[NUnit.Framework.Test]
//		public virtual void TestSharedEdgeIntersection_13()
//		{
//			string s1 = "{\"rings\":[[[0.099604024000029767,0.2107958250000479],[0.14626826900007472,0.2107958250000479],[0.14626826900007472,0.18285316400005058],[0.099604024000029767,0.18285316400005058],[0.099604024000029767,0.2107958250000479]]]}";
//			string s2 = "{\"paths\":[[[0.095692051000071388,0.15910190100004229],[0.10324853600002371,0.18285316400004228],[0.12359292700006108,0.18285316400004228],[0.12782611200003657,0.1705583920000322],[0.13537063000007138,0.18285316400004228]]]}";
//			com.esri.core.geometry.Polygon polygon = (com.esri.core.geometry.Polygon)com.esri.core.geometry.TestCommonMethods.FromJson(s1).GetGeometry();
//			com.esri.core.geometry.Polyline polyline = (com.esri.core.geometry.Polyline)com.esri.core.geometry.TestCommonMethods.FromJson(s2).GetGeometry();
//			com.esri.core.geometry.SpatialReference sr = com.esri.core.geometry.SpatialReference.Create(4326);
//			com.esri.core.geometry.Geometry g = com.esri.core.geometry.OperatorIntersection.Local().Execute(polygon, polyline, sr, null);
//			NUnit.Framework.Assert.IsTrue(!g.IsEmpty());
//		}
//
//		[NUnit.Framework.Test]
//		public virtual void TestIntersectionIssue2()
//		{
//			string s1 = "{\"rings\":[[[-97.174860352323378,48.717174479818425],[-97.020624513410553,58.210155436624177],[-94.087641114245969,58.210155436624177],[-94.087641114245969,48.639781902013226],[-97.174860352323378,48.717174479818425]]]}";
//			string s2 = "{\"rings\":[[[-94.08764111399995,52.68342763000004],[-94.08764111399995,56.835188018000053],[-90.285921520999977,62.345706350000057],[-94.08764111399995,52.68342763000004]]]}";
//			com.esri.core.geometry.Polygon polygon1 = (com.esri.core.geometry.Polygon)com.esri.core.geometry.TestCommonMethods.FromJson(s1).GetGeometry();
//			com.esri.core.geometry.Polygon polygon2 = (com.esri.core.geometry.Polygon)com.esri.core.geometry.TestCommonMethods.FromJson(s2).GetGeometry();
//			com.esri.core.geometry.SpatialReference sr = com.esri.core.geometry.SpatialReference.Create(4326);
//			com.esri.core.geometry.GeometryCursor res = com.esri.core.geometry.OperatorIntersection.Local().Execute(new com.esri.core.geometry.SimpleGeometryCursor(polygon1), new com.esri.core.geometry.SimpleGeometryCursor(polygon2), sr, null, 2);
//			com.esri.core.geometry.Geometry g = res.Next();
//			NUnit.Framework.Assert.IsTrue(g != null);
//			NUnit.Framework.Assert.IsTrue(!g.IsEmpty());
//			com.esri.core.geometry.Geometry g2 = res.Next();
//			NUnit.Framework.Assert.IsTrue(g2 == null);
//			string ss = "{\"paths\":[[[-94.08764111412296,52.68342763000004],[-94.08764111410767,56.83518801800005]]]}";
//			com.esri.core.geometry.Polyline polyline = (com.esri.core.geometry.Polyline)com.esri.core.geometry.TestCommonMethods.FromJson(ss).GetGeometry();
//			bool eq = com.esri.core.geometry.OperatorEquals.Local().Execute(g, polyline, sr, null);
//			NUnit.Framework.Assert.IsTrue(eq);
//		}
	}
}
